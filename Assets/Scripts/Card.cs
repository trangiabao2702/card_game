using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
    public int Id;
    public string Element;
    public string Color;
    public int Power;

    public Card() { }

    public Card(int id, string element, string color, int power)
    {
        Id = id;
        Element = element;
        Color = color;
        Power = power;
    }
}
