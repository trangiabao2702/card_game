using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public int Id;
    public string Name;
    public int Experience;
    public string Level;
    public List<int> OwnerDeck;
    public List<int> OwnerCards;
    public int Money;

    public PlayerState(int id, string name, int experience, string level, List<int> ownerCards)
    {
        Id = id;
        Name = name;
        Experience = experience;
        Level = level;
        OwnerDeck = new List<int> { 0, 1, 2, 3, 4, 20, 21, 22, 23, 24, 40, 41, 42, 43, 44 };
        OwnerCards = ownerCards;
        Money = 0;
    }
}
