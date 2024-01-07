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

    private void StartTurn()
    {
        print("Start Turn");

        // Draw cards to hand
        DrawCardsToHand();

        // Start count down
        CountDownTimer.StartTimer(10.1f);

        // Allow players to select cards or perform any other turn-specific actions
        // You can enable card selection logic here
        // For example, enable card selection by enabling colliders or interaction scripts on the cards
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

    private void EndTurn()
    {
        print("End Turn");

        // Disable card selection logic here
        // For example, disable colliders or interaction scripts on the cards

        // Compare selected cards and determine the winner for this turn

        // Show the winner on the UI or perform any necessary actions

        // Check game end conditions
        bool isGameOver = CheckGameOverCondition();

        if (isGameOver)
        {
            // Perform game end actions
        }
        else
        {
            // Start the next turn
            StartTurn();
        }
    }

    private bool CheckGameOverCondition()
    {
        // Implement your game end condition logic here
        // Return true if the game should end, false otherwise
        return false;
    }

    List<int> GetPlayerDeck()
    {
        return new List<int> { 0, 1, 2, 3, 4, 20, 21, 22, 23, 24, 40, 41, 42, 43, 44 };
    }
}
