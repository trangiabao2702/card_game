using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer timer;

    private void Start()
    {
        StartTurn();
    }

    private void Update()
    {
        if (timer.remainingDuration <= 0)
        {
            EndTurn();
        }
    }

    private void StartTurn()
    {
        print("Start Turn");

        timer.StartTimer(4.1f);

        // Allow players to select cards or perform any other turn-specific actions
        // You can enable card selection logic here
        // For example, enable card selection by enabling colliders or interaction scripts on the cards
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
}
