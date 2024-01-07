using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalDatabase : MonoBehaviour
{
    public static List<Signal> SignalsList = new List<Signal>();

    void Awake()
    {
        SignalsList.Add(new Signal(0,   "fire", "blue",   Resources.Load<Sprite>("Cards/Signal/fire_blue")));
        SignalsList.Add(new Signal(1,   "fire", "green",  Resources.Load<Sprite>("Cards/Signal/fire_green")));
        SignalsList.Add(new Signal(2,   "fire", "grey",   Resources.Load<Sprite>("Cards/Signal/fire_grey")));
        SignalsList.Add(new Signal(3,   "fire", "orange", Resources.Load<Sprite>("Cards/Signal/fire_orange")));
        SignalsList.Add(new Signal(4,   "fire", "yellow", Resources.Load<Sprite>("Cards/Signal/fire_yellow")));
        
        SignalsList.Add(new Signal(5,   "water", "blue",   Resources.Load<Sprite>("Cards/Signal/water_blue")));
        SignalsList.Add(new Signal(6,   "water", "green",  Resources.Load<Sprite>("Cards/Signal/water_green")));
        SignalsList.Add(new Signal(7,   "water", "grey",   Resources.Load<Sprite>("Cards/Signal/water_grey")));
        SignalsList.Add(new Signal(8,   "water", "orange", Resources.Load<Sprite>("Cards/Signal/water_orange")));
        SignalsList.Add(new Signal(9,   "water", "yellow", Resources.Load<Sprite>("Cards/Signal/water_yellow")));
        
        SignalsList.Add(new Signal(10,  "wood", "blue",   Resources.Load<Sprite>("Cards/Signal/wood_blue")));
        SignalsList.Add(new Signal(11,  "wood", "green",  Resources.Load<Sprite>("Cards/Signal/wood_green")));
        SignalsList.Add(new Signal(12,  "wood", "grey",   Resources.Load<Sprite>("Cards/Signal/wood_grey")));
        SignalsList.Add(new Signal(13,  "wood", "orange", Resources.Load<Sprite>("Cards/Signal/wood_orange")));
        SignalsList.Add(new Signal(14,  "wood", "yellow", Resources.Load<Sprite>("Cards/Signal/wood_yellow")));
    }
}
