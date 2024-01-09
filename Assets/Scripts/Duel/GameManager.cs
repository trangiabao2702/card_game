using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Timer CountDownTimer;
    public Deck PlayerDeck;
    public List<int> CardsOnHand = new List<int>();
    public List<GameObject> DisplayCardsOnHand;
    public List<GameObject> DisplayPlayerSignals;
    public List<GameObject> DisplayOpponentSignals;
    public Dictionary<string, List<string>> PlayerSignals = new Dictionary<string, List<string>>
    {
        { "fire", new List<string>() },
        { "water", new List<string>() },
        { "wood", new List<string>() }
    };
    public Dictionary<string, List<string>> OpponentSignals = new Dictionary<string, List<string>>
    {
        { "fire", new List<string>() },
        { "water", new List<string>() },
        { "wood", new List<string>() }
    };

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

        // Remove opponent's card
        Vector3 opponentCardPosition = new Vector3(-1000, 650, 1);
        GameObject.FindGameObjectWithTag("OpponentCard").GetComponent<DisplayCard>().SetDisplayCard(0, opponentCardPosition);

        // Deselect all player's on hand cards
        DeselectAllPlayerCards();

        // Draw player's cards to hand
        DrawCardsToHand();
        RenderSignals();
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
            print("Players draw");
        }
        else if (IsPlayerWin(playerCard, opponentCard))
        {
            // Show player won
            print("Player won");

            // Add signal
            PlayerSignals[playerCard.Element].Add(playerCard.Color);
        }
        else
        {
            // Show opponent won
            print("Opponent won");

            // Add signal
            OpponentSignals[opponentCard.Element].Add(opponentCard.Color);
        }
        print("---------------------------------------------------------------");
        PrintSignals();
        RenderSignals();
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
        Vector3 playerPlayCardPosition = new Vector3 (1500, 650, 1);
        card.GetComponent<DisplayCard>().PlayCard(playerPlayCardPosition);

        // Render opponent's card
        print("Show opponent card");
        //GameObject.FindGameObjectWithTag("OpponentCard").SetActive(true);
    }

    private Card GetOpponentSelectedCard(List<int> opponentDeck)
    {
        Card opponentCard = CardDatabase.CardsList[opponentDeck[0]];
        opponentDeck.RemoveAt(0);

        Vector3 opponentCardPosition = new Vector3(420, 650, 1);
        GameObject.FindGameObjectWithTag("OpponentCard").GetComponent<DisplayCard>().SetDisplayCard(opponentCard.Id, opponentCardPosition);

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

    private void PrintSignals()
    {
        string playerSignals = "PlayerSignals: [";
        foreach (var PlayerSignal in PlayerSignals)
        {
            foreach (var color in PlayerSignal.Value)
            {
                playerSignals += $"{PlayerSignal.Key}-{color}, ";
            }
        }
        playerSignals += "]";
        print(playerSignals);

        string opponentSignals = "OpponentSignals: [";
        foreach (var OpponentSignal in OpponentSignals)
        {
            foreach (var color in OpponentSignal.Value)
            {
                opponentSignals += $"{OpponentSignal.Key}-{color}, ";
            }
        }
        opponentSignals += "]";
        print(opponentSignals);
    }

    private void RenderSignals()
    {
        /*
         * Maxium signals for each element is 5 because a player will win with 3 different signals
         */

        SignalDatabase signalDatabase = new SignalDatabase();

        // Render player's signals
        int indexSignal = 0;
        foreach (var element in PlayerSignals)
        {
            for (int indexElement = 0; indexElement < PlayerSignals[element.Key].Count; indexElement++)
            {
                string color = PlayerSignals[element.Key][indexElement];
                int signalId = signalDatabase.FindSignal(element.Key, color);
                Vector3 signalPosition = new Vector3(1600f, 970f - indexElement * 20f, 0 - indexElement);

                if (element.Key == "water")
                {
                    signalPosition.x += 110f;
                }
                else if (element.Key == "wood")
                {
                    signalPosition.x += 220f;
                }
                else { }
                print("render signal " + signalId + " - " + element.Key + " - " + color + $" (100, {970 - indexElement * 10}, 0)");
                DisplayPlayerSignals[indexSignal].GetComponent<DisplaySignal>().SetDisplaySignal(signalId, signalPosition);

                indexSignal++;
            }
        }

        // Render opponent's signals
        indexSignal = 0;
        foreach (var element in OpponentSignals)
        {
            for (int indexElement = 0; indexElement < OpponentSignals[element.Key].Count; indexElement++)
            {
                string color = OpponentSignals[element.Key][indexElement];
                int signalId = signalDatabase.FindSignal(element.Key, color);
                Vector3 signalPosition = new Vector3(100f, 970f - indexElement * 20f, 0 - indexElement);

                if (element.Key == "water")
                {
                    signalPosition.x += 110f;
                }
                else if (element.Key == "wood")
                {
                    signalPosition.x += 220f;
                }
                else { }
                print("render signal " + signalId + " - " + element.Key + " - " + color + $" (100, {970 - indexElement * 10}, 0)");
                DisplayOpponentSignals[indexSignal].GetComponent<DisplaySignal>().SetDisplaySignal(signalId, signalPosition);

                indexSignal++;
            }
        }
    }
}
