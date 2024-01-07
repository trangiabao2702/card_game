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
        // Draw player's cards to hand
        DrawCardsToHand();

        // Start count down
        CountDownTimer.StartTimer(10.1f);

        // Get players' selected card
        Card playerCard = GetPlayerSelectedCard();

        // Get opponent's selected card
        Card opponentCard = GetOpponentSelectedCard(GetOpponentDeck());

        // Compare cards and show the winner
        if (IsPlayerDraw(playerCard, opponentCard))
        {
            // Show player drawed
        }
        else if (IsPlayerWin(playerCard, opponentCard))
        {
            // Show player won & add signal

        }
        else
        {
            // Show opponent won & add signal

        }

        // End turn
        EndTurn();
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
        // Delete all exist cards
        //GameObject[] existingCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        //foreach (GameObject card in existingCards)
        //{
        //    Destroy(card);
        //}

        for (int position = 0; position < 5; position++)
        {
            //GameObject playerCard = Instantiate(DisplayCardsOnHand[position], Vector3.zero, Quaternion.identity);

            float x = 690f + 165f * position;
            float y = 165f;
            float z = 0f;
            Vector3 cardPosition = new Vector3(x, y, z);

            DisplayCardsOnHand[position].GetComponent<DisplayCard>().SetDisplayCard(CardsOnHand[position], cardPosition);
            //playerCard.transform.rotation = Quaternion.identity;
            //playerCard.transform.localScale = Vector3.one;
        }
    }

    private Card GetPlayerSelectedCard()
    {
        int selectedCard = -1;

        GameObject[] playerOnHandCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (GameObject card in playerOnHandCards)
        {
            if (card.GetComponent<DisplayCard>().IsSelected)
            {

            }
        }
        return null;
    }

    private static Card GetOpponentSelectedCard(List<int> opponentDeck)
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

    private void EndTurn()
    {
        // Check game end conditions
        bool isGameOver = CheckGameOverCondition();

        if (isGameOver)
        {
            // Perform game end actions
        }
        else
        {
            // Continue with a new turn
            StartTurn();
        }
    }

    private bool CheckGameOverCondition()
    {
        // Implement your game end condition logic here
        // Return true if the game should end, false otherwise
        return false;
    }
}
