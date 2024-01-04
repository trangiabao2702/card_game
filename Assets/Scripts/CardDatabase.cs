    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> CardsList = new List<Card>();

    private void Awake()
    {
        CardsList.Add(new Card(0, "fire", "orange", 1));
        CardsList.Add(new Card(0, "fire", "grey", 2));
        CardsList.Add(new Card(0, "fire", "yellow", 3));
        CardsList.Add(new Card(0, "fire", "blue", 4));
        CardsList.Add(new Card(0, "fire", "green", 5));
        CardsList.Add(new Card(0, "fire", "orange", 6));
        CardsList.Add(new Card(0, "fire", "grey", 7));
        CardsList.Add(new Card(0, "fire", "yellow", 8));
        CardsList.Add(new Card(0, "fire", "blue", 9));
        CardsList.Add(new Card(0, "fire", "green", 10));
        CardsList.Add(new Card(0, "fire", "orange", 11));
        CardsList.Add(new Card(0, "fire", "grey", 12));
        CardsList.Add(new Card(0, "fire", "yellow", 13));
        CardsList.Add(new Card(0, "fire", "blue", 14));
        CardsList.Add(new Card(0, "fire", "green", 15));
        CardsList.Add(new Card(0, "fire", "orange", 16));
        CardsList.Add(new Card(0, "fire", "grey", 17));
        CardsList.Add(new Card(0, "fire", "yellow", 18));
        CardsList.Add(new Card(0, "fire", "blue", 19));
        CardsList.Add(new Card(0, "fire", "green", 20));

        CardsList.Add(new Card(0, "water", "orange", 1));
        CardsList.Add(new Card(0, "water", "grey", 2));
        CardsList.Add(new Card(0, "water", "yellow", 3));
        CardsList.Add(new Card(0, "water", "blue", 4));
        CardsList.Add(new Card(0, "water", "green", 5));
        CardsList.Add(new Card(0, "water", "orange", 6));
        CardsList.Add(new Card(0, "water", "grey", 7));
        CardsList.Add(new Card(0, "water", "yellow", 8));
        CardsList.Add(new Card(0, "water", "blue", 9));
        CardsList.Add(new Card(0, "water", "green", 10));
        CardsList.Add(new Card(0, "water", "orange", 11));
        CardsList.Add(new Card(0, "water", "grey", 12));
        CardsList.Add(new Card(0, "water", "yellow", 13));
        CardsList.Add(new Card(0, "water", "blue", 14));
        CardsList.Add(new Card(0, "water", "green", 15));
        CardsList.Add(new Card(0, "water", "orange", 16));
        CardsList.Add(new Card(0, "water", "grey", 17));
        CardsList.Add(new Card(0, "water", "yellow", 18));
        CardsList.Add(new Card(0, "water", "blue", 19));
        CardsList.Add(new Card(0, "water", "green", 20));

        CardsList.Add(new Card(0, "wood", "orange", 1));
        CardsList.Add(new Card(0, "wood", "grey", 2));
        CardsList.Add(new Card(0, "wood", "yellow", 3));
        CardsList.Add(new Card(0, "wood", "blue", 4));
        CardsList.Add(new Card(0, "wood", "green", 5));
        CardsList.Add(new Card(0, "wood", "orange", 6));
        CardsList.Add(new Card(0, "wood", "grey", 7));
        CardsList.Add(new Card(0, "wood", "yellow", 8));
        CardsList.Add(new Card(0, "wood", "blue", 9));
        CardsList.Add(new Card(0, "wood", "green", 10));
        CardsList.Add(new Card(0, "wood", "orange", 11));
        CardsList.Add(new Card(0, "wood", "grey", 12));
        CardsList.Add(new Card(0, "wood", "yellow", 13));
        CardsList.Add(new Card(0, "wood", "blue", 14));
        CardsList.Add(new Card(0, "wood", "green", 15));
        CardsList.Add(new Card(0, "wood", "orange", 16));
        CardsList.Add(new Card(0, "wood", "grey", 17));
        CardsList.Add(new Card(0, "wood", "yellow", 18));
        CardsList.Add(new Card(0, "wood", "blue", 19));
        CardsList.Add(new Card(0, "wood", "green", 20));
    }
}
