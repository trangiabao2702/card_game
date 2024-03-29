using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[System.Serializable]

public class Card
{
    public int Id;
    public int Power;
    public string Element;
    public string Color;
    public Sprite SpriteImage;
    public bool IsSelected;

    public Card() { }

    public Card(int id, string element, string color, int power, Sprite spriteImage)
    {
        Id = id;
        Element = element;
        Color = color;
        Power = power;
        SpriteImage = spriteImage;
        IsSelected = false;
    }
}
