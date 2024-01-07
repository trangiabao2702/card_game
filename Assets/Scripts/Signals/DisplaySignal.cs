using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySignal : MonoBehaviour
{
    public List<Signal> DisplaySignals = new List<Signal>();
    public int DisplayId;

    public int SignalId;
    public string SignalElement;
    public string SignalColor;
    public Sprite SignalSpriteImage;

    public Image SignalImage;

    void Start()
    {
        DisplaySignals.Clear();
        DisplaySignals.Add(SignalDatabase.SignalsList[DisplayId]);
    }

    void Update()
    {
        SignalId = DisplaySignals[0].Id;
        SignalElement = DisplaySignals[0].Element;
        SignalColor = DisplaySignals[0].Color;
        SignalSpriteImage = DisplaySignals[0].SpriteImage;

        SignalImage.sprite = SignalSpriteImage;
    }
}
