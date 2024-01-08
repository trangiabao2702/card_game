using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Timer CountDownTimer;
    public Deck PlayerDeck;
    public List<int> CardsOnHand = new List<int>();
    public List<GameObject> DisplayCardsOnHand;

    private void Start()
    {
        PlayerDeck.InitializePlayerDeck(GetPlayerDeck());
        StartTurn();
    }

    private void Update()
    {
        if (CountDownTimer.remainingDuration <= 0)
        {
            EndTurn();
        }
    }

    List<int> GetPlayerDeck()
    {
        // TODO: get the exact deck of player
        return new List<int> { 0, 1, 2, 3, 4, 20, 21, 22, 23, 24, 40, 41, 42, 43, 44 };
    }
    
    List<int> GetOpponentDeck()
    {
        List<int> opponentDeck =  new List<int> { 0, 1, 2, 3, 4, 20, 21, 22, 23, 24, 40, 41, 42, 43, 44 };

        int n = opponentDeck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = opponentDeck[k];
            opponentDeck[k] = opponentDeck[n];
            opponentDeck[n] = value;
        }

        return opponentDeck;
    }

    private void StartTurn()
    {
        // Check game end conditions
        if (CheckGameOverCondition())
        {
            // Perform game end actions
            return;
        }

        // Deselect all player's on hand cards
        DeselectAllPlayerCards();

        // Draw player's cards to hand
        DrawCardsToHand();

        //// Start count down
        //CountDownTimer.StartTimer(10.1f);
    }

    private void DrawCardsToHand()
    {
        while (CardsOnHand.Count < 5)
        {
            int drewCardId = PlayerDeck.Draw();
            if (drewCardId == -1)
            {
                break;
            }

            CardsOnHand.Add(drewCardId);
        }

        RenderCardsOnHand();
    }

    private void RenderCardsOnHand()
    {
        for (int position = 0; position < 5; position++)
        {
            float x = 690f + 165f * position;
            float y = 165f;
            float z = 0f;
            Vector3 cardPosition = new Vector3(x, y, z);
            
            DisplayCardsOnHand[position].GetComponent<DisplayCard>().SetDisplayCard(CardsOnHand[position], cardPosition);
            //playerCard.transform.rotation = Quaternion.identity;
        }
    }

    private void EndTurn()
    {
        // Get players' selected card
        Card playerCard = GetPlayerSelectedCard();

        // Get opponent's selected card
        Card opponentCard = GetOpponentSelectedCard(GetOpponentDeck());

        // Compare cards and show the winner
        print("---------------------------------------------------------------");
        print("Player: " + playerCard.Power + " - " + playerCard.Element);
        print("Opponent: " + opponentCard.Power + " - " + opponentCard.Element);
        if (IsPlayerDraw(playerCard, opponentCard))
        {
            // Show player drawed
            print("player draw");
        }
        else if (IsPlayerWin(playerCard, opponentCard))
        {
            // Show player won & add signal
            print("player won ");
        }
        else
        {
            // Show opponent won & add signal
            print("opponent won");
        }
        print("---------------------------------------------------------------");

        CountDownTimer.PauseTimer();
        StartCoroutine(PauseForSeconds(10f));

        CountDownTimer.StartTimer(10.1f);
    }

    private Card GetPlayerSelectedCard()
    {
        int maxPower = 0;
        GameObject cardHasMaxPower = null;

        // If player selected a card
        GameObject[] playerOnHandCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (GameObject card in playerOnHandCards)
        {
            if (card.GetComponent<DisplayCard>().IsSelected)
            {
                RenderSelectedCards(card);
                return CardDatabase.CardsList[card.GetComponent<DisplayCard>().CardId];
            }

            if (card.GetComponent<DisplayCard>().CardPower > maxPower)
            {
                cardHasMaxPower = card;
                maxPower = cardHasMaxPower.GetComponent<DisplayCard>().CardPower;
            }
        }

        // If player hasn't selected a card -> Get the card has the max power in player's hand
        RenderSelectedCards(cardHasMaxPower);
        return CardDatabase.CardsList[cardHasMaxPower.GetComponent<DisplayCard>().CardId];
    }

    private void RenderSelectedCards(GameObject card)
    {
        // Render player's card
        card.GetComponent<DisplayCard>().PlayCard();

        // Render opponent's card

    }

    private Card GetOpponentSelectedCard(List<int> opponentDeck)
    {
        Card opponentCard = CardDatabase.CardsList[opponentDeck[0]];
        opponentDeck.RemoveAt(0);

        return opponentCard;
    }

    private bool IsPlayerDraw(Card playerCard, Card opponentCard)
    {
        return playerCard.Id == opponentCard.Id;
    }

    private bool IsPlayerWin(Card playerCard, Card opponentCard)
    {
        switch (CompareElements(playerCard.Element, opponentCard.Element))
        {
            case 1:
                return true;
            case -1:
                return false;
            case 0:
                return playerCard.Power > opponentCard.Power;
            default:
                return false;
        }
    }

    private int CompareElements(string first_element, string second_element)
    {
        // Same elements
        if (first_element == second_element)
        {
            return 0;
        }

        // Weaker element
        if (first_element == "fire" && second_element == "water")
        {
            return -1;
        }

        if (first_element == "water" && second_element == "wood")
        {
            return -1;
        }

        if (first_element == "wood" && second_element == "fire")
        {
            return -1;
        }

        // Stronger element
        if (first_element == "fire" && second_element == "wood")
        {
            return 1;
        }

        if (first_element == "water" && second_element == "fire")
        {
            return 1;
        }

        if (first_element == "wood" && second_element == "water")
        {
            return 1;
        }

        return 2;
    }

    private bool CheckGameOverCondition()
    {
        // Implement your game end condition logic here
        // Return true if the game should end, false otherwise
        return false;
    }

    private IEnumerator PauseForSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        CountDownTimer.ResumeTimer();
        StartTurn();
    }

    private void DeselectAllPlayerCards()
    {
        GameObject[] playerOnHandCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (GameObject card in playerOnHandCards)
        {
            card.GetComponent<DisplayCard>().IsSelected = false;
        }
    }
}
