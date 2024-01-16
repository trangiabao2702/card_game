using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
    public int OpponentLevel = 1;
    public Deck OpponentDeck;
    public List<int> OpponentCardsOnHand = new List<int>();

    private void Start()
    {
        PlayerDeck.InitializePlayerDeck(GetPlayerDeck());
        print(PlayerDeck);
        OpponentDeck.InitializePlayerDeck(GetOpponentDeck());
        print(OpponentDeck);
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
        switch (OpponentLevel) {
            case 1:
                return new List<int> { 0, 1, 2, 3, 4, 20, 21, 22, 23, 24, 40, 41, 42, 43, 44 };
            case 2:
                return new List<int> { 1, 2, 3, 4, 5, 21, 22, 23, 24, 25, 41, 42, 43, 44, 45 };
            case 3:
                return new List<int> { 3, 4, 5, 6, 7, 23, 24, 25, 26, 27, 43, 44, 45, 46, 47 };
            case 4:
                return new List<int> { 4, 5, 6, 7, 8, 24, 25, 26, 27, 28, 44, 45, 46, 47, 48 };
            case 5:
                return new List<int> { 5, 6, 7, 8, 9, 25, 26, 27, 28, 29, 45, 46, 47, 48, 49 };
            default:
                return new List<int> { 5, 6, 7, 8, 9, 25, 26, 27, 28, 29, 45, 46, 47, 48, 49 };
        }
    }

    private void StartTurn()
    {
        // Remove opponent's card
        Vector3 opponentCardPosition = new Vector3(-1000, 650, 1);
        GameObject.FindGameObjectWithTag("OpponentCard").GetComponent<DisplayCard>().SetDisplayCard(0, opponentCardPosition);

        // Deselect all player's on hand cards
        DeselectAllPlayerCards();
        AllowToSelectCards();

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

        while (OpponentCardsOnHand.Count < 5)
        {
            int drewCardId = OpponentDeck.Draw();
            if (drewCardId == -1)
            {
                break;
            }

            OpponentCardsOnHand.Add(drewCardId);
        }

        GameObject.FindGameObjectWithTag("OpponentFaceDownCard").transform.position = new Vector3(94, 100, 0);
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
        Card opponentCard = GetOpponentSelectedCard();

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
        print("---------------------------------------------------------------");

        CountDownTimer.PauseTimer();
        PreventToSelectCards();
        CardsOnHand.Remove(playerCard.Id);
        StartCoroutine(PauseForSeconds(5f));

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

    private Card GetOpponentSelectedCard()
    {
        print("Opponent Lv: " + OpponentLevel);
        switch (OpponentLevel)
        {
            case 1:
                // min power card
                OpponentCardsOnHand.Sort((a, b) => CardDatabase.CardsList[a].Power.CompareTo(CardDatabase.CardsList[b].Power));

                break;
            case 2:
                // max power card
                OpponentCardsOnHand.Sort((a, b) => CardDatabase.CardsList[a].Power.CompareTo(CardDatabase.CardsList[b].Power));
                OpponentCardsOnHand.Reverse();

                break;
            case 3:
                // order the priority of signals
                List<string> prioritySignals = OpponentSignals.OrderBy(kv => kv.Value.Count).Select(kv => kv.Key).ToList();

                // add missing signals
                prioritySignals = AddMissingSignals(prioritySignals);

                // order the cards on hand by priority signals and power desc
                OpponentCardsOnHand = OrderOpponentCardsByPrioritySignal(prioritySignals);

                break;
            case 4:
                // check the opponent's need signal
                List<string> opponentNeedSignals = GetOpponentNeedSignals();

                // order the priority of signals by power
                if (opponentNeedSignals.Count == 2)
                {
                    if (MaxPowerOpponentOnHandCardsOfElement(opponentNeedSignals[0]) < MaxPowerOpponentOnHandCardsOfElement(opponentNeedSignals[1]))
                    {
                        string tempSignal = opponentNeedSignals[0];
                        opponentNeedSignals[0] = opponentNeedSignals[1];
                        opponentNeedSignals[1] = tempSignal;
                    }
                }

                // add the missing signals
                opponentNeedSignals = AddMissingSignals(opponentNeedSignals);

                // order the cards on hand by priority signals and power desc
                OpponentCardsOnHand = OrderOpponentCardsByPrioritySignal(opponentNeedSignals);

                break;
            case 5:
                // check the player's need signal
                List<string> playerNeedSignals = GetPlayerNeedSignals();

                // order the priority of signals by power
                if (playerNeedSignals.Count == 2)
                {
                    if (MaxPowerOpponentOnHandCardsOfElement(playerNeedSignals[0]) < MaxPowerOpponentOnHandCardsOfElement(playerNeedSignals[1]))
                    {
                        string tempSignal = playerNeedSignals[0];
                        playerNeedSignals[0] = playerNeedSignals[1];
                        playerNeedSignals[1] = tempSignal;
                    }
                }

                // add the missing signals
                playerNeedSignals = AddMissingSignals(playerNeedSignals);

                // order the cards on hand by priority signals and power desc
                OpponentCardsOnHand = OrderOpponentCardsByPrioritySignal(playerNeedSignals);

                break;
        }

        Card opponentCard = CardDatabase.CardsList[OpponentCardsOnHand[0]];
        OpponentCardsOnHand.RemoveAt(0);

        Vector3 opponentCardPosition = new Vector3(420, 650, 1);
        GameObject.FindGameObjectWithTag("OpponentCard").GetComponent<DisplayCard>().SetDisplayCard(opponentCard.Id, opponentCardPosition);

        // Random disable a face down card
        GameObject.FindGameObjectWithTag("OpponentFaceDownCard").transform.position = new Vector3(-1000, -1000, 0);

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
        // Check if player has 3 different elements
        bool allListsNotEmpty = true;

        foreach (var item in PlayerSignals)
        {
            if (item.Value.Count == 0)
            {
                allListsNotEmpty = false;
                break;
            }
        }

        if (allListsNotEmpty)
        {
            print("Player win with three different elements");
            return true;
        }

        // Check if player has 3 different colors in an element
        foreach (var item in PlayerSignals)
        {
            if (item.Value.Distinct().Count() >= 3)
            {
                print($"Player win with three different colors of element {item.Key}");
                return true;
            }
        }

        // Check if opponent has 3 different elements
        allListsNotEmpty = true;

        foreach (var item in PlayerSignals)
        {
            if (item.Value.Count == 0)
            {
                allListsNotEmpty = false;
                break;
            }
        }

        if (allListsNotEmpty)
        {
            print("Opponent win with three different elements");
            return true;
        }

        // Check if opponent has 3 different colors in an element
        foreach (var item in OpponentSignals)
        {
            if (item.Value.Distinct().Count() >= 3)
            {
                print($"Player win with three different colors of element {item.Key}");
                return true;
            }
        }

        return false;
    }

    private IEnumerator PauseForSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        CountDownTimer.ResumeTimer();
        RenderSignals();

        // Check game end conditions
        if (CheckGameOverCondition())
        {
            // Perform game end actions
            print("End game");
        }
        else
        {
            StartTurn();
        }
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

    private void AllowToSelectCards()
    {
        DisplayCardsOnHand.ForEach((card) =>
        {
            card.GetComponent<DisplayCard>().AllowToSelectCard();
        });
    }

    private void PreventToSelectCards()
    {
        DisplayCardsOnHand.ForEach((card) =>
        {
            card.GetComponent<DisplayCard>().PreventToSelectCard();
        });
    }

    private List<int> OrderOpponentCardsByPrioritySignal(List<string> prioritySignals)
    {
        // order the cards on hand by ordered signals and power desc
        OpponentCardsOnHand.Sort((a, b) => b.CompareTo(a));
        List<int> orderedCards = new List<int>();
        for (int i = 0; i < prioritySignals.Count; i++)
        {
            for (int j = 0; j < OpponentCardsOnHand.Count; j++)
            {
                if (CardDatabase.CardsList[OpponentCardsOnHand[j]].Element == prioritySignals[i])
                {
                    orderedCards.Add(OpponentCardsOnHand[j]);
                }
            }
        }

        return orderedCards;
    }

    private List<string> GetPlayerNeedSignals()
    {
        List<string> signals = new List<string>();

        if (PlayerSignals["fire"].Count > 0 && PlayerSignals["water"].Count > 0)
        {
            signals.Add("wood");
        }
        else if (PlayerSignals["water"].Count > 0 && PlayerSignals["wood"].Count > 0)
        {
            signals.Add("fire");
        }
        else if (PlayerSignals["wood"].Count > 0 && PlayerSignals["fire"].Count > 0)
        {
            signals.Add("water");
        }
        else { }
        
        if (PlayerSignals["fire"].Count > 1)
        {
            signals.Add("fire");
        }
        else if (PlayerSignals["water"].Count > 1)
        {
            signals.Add("water");
        }
        else if (PlayerSignals["wood"].Count > 1)
        {
            signals.Add("wood");
        }
        else { }

        return signals;
    }

    private List<string> GetOpponentNeedSignals()
    {
        List<string> signals = new List<string>();

        if (OpponentSignals["fire"].Count > 0 && OpponentSignals["water"].Count > 0)
        {
            signals.Add("wood");
        }
        else if (OpponentSignals["water"].Count > 0 && OpponentSignals["wood"].Count > 0)
        {
            signals.Add("fire");
        }
        else if (OpponentSignals["wood"].Count > 0 && OpponentSignals["fire"].Count > 0)
        {
            signals.Add("water");
        }
        else { }

        if (OpponentSignals["fire"].Count > 1)
        {
            signals.Add("fire");
        }
        else if (OpponentSignals["water"].Count > 1)
        {
            signals.Add("water");
        }
        else if (OpponentSignals["wood"].Count > 1)
        {
            signals.Add("wood");
        }
        else { }

        return signals;
    }

    private int MaxPowerOpponentOnHandCardsOfElement(string element)
    {
        int maxPower = 0;
        for (int i = 0; i < OpponentCardsOnHand.Count; i++)
        {
            if (CardDatabase.CardsList[OpponentCardsOnHand[i]].Power > maxPower)
            {
                maxPower = CardDatabase.CardsList[OpponentCardsOnHand[i]].Power;
            }
        }

        return maxPower;
    }

    private List<string> AddMissingSignals(List<string> signals)
    {
        List<string> fullSignals = new List<string>();
        for (int i = 0;i < signals.Count;i++)
        {
            fullSignals.Add(signals[i]);
        }

        if (!fullSignals.Contains("fire"))
        {
            fullSignals.Add("fire");
        }
        if (!fullSignals.Contains("water"))
        {
            fullSignals.Add("water");
        }
        if (!fullSignals.Contains("wood"))
        {
            fullSignals.Add("wood");
        }

        return fullSignals;
    }
}
