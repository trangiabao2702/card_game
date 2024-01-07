using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Signal
{
    public int Id;
    public string Element;
    public string Color;
    public Sprite SpriteImage;

    public Signal() { }

    public Signal(int id, string element, string color, Sprite spriteImage)
    {
        Id = id;
        Element = element;
        Color = color;
        SpriteImage = spriteImage;
    }
}
