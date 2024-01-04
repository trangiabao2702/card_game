    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> CardsList = new List<Card>();

    void Awake()
    {
        CardsList.Add(new Card(0,   "fire", "orange", 1,  Resources.Load<Sprite>("Cards/Fire/fire_01")));
        CardsList.Add(new Card(1,   "fire", "grey",   2,  Resources.Load<Sprite>("Cards/Fire/fire_02")));
        CardsList.Add(new Card(2,   "fire", "yellow", 3,  Resources.Load<Sprite>("Cards/Fire/fire_03")));
        CardsList.Add(new Card(3,   "fire", "blue",   4,  Resources.Load<Sprite>("Cards/Fire/fire_04")));
        CardsList.Add(new Card(4,   "fire", "green",  5,  Resources.Load<Sprite>("Cards/Fire/fire_05")));
        CardsList.Add(new Card(5,   "fire", "orange", 6,  Resources.Load<Sprite>("Cards/Fire/fire_06")));
        CardsList.Add(new Card(6,   "fire", "grey",   7,  Resources.Load<Sprite>("Cards/Fire/fire_07")));
        CardsList.Add(new Card(7,   "fire", "yellow", 8,  Resources.Load<Sprite>("Cards/Fire/fire_08")));
        CardsList.Add(new Card(8,   "fire", "blue",   9,  Resources.Load<Sprite>("Cards/Fire/fire_09")));
        CardsList.Add(new Card(9,   "fire", "green",  10, Resources.Load<Sprite>("Cards/Fire/fire_10")));
        CardsList.Add(new Card(10,  "fire", "orange", 11, Resources.Load<Sprite>("Cards/Fire/fire_11")));
        CardsList.Add(new Card(11,  "fire", "grey",   12, Resources.Load<Sprite>("Cards/Fire/fire_12")));
        CardsList.Add(new Card(12,  "fire", "yellow", 13, Resources.Load<Sprite>("Cards/Fire/fire_13")));
        CardsList.Add(new Card(13,  "fire", "blue",   14, Resources.Load<Sprite>("Cards/Fire/fire_14")));
        CardsList.Add(new Card(14,  "fire", "green",  15, Resources.Load<Sprite>("Cards/Fire/fire_15")));
        CardsList.Add(new Card(15,  "fire", "orange", 16, Resources.Load<Sprite>("Cards/Fire/fire_16")));
        CardsList.Add(new Card(16,  "fire", "grey",   17, Resources.Load<Sprite>("Cards/Fire/fire_17")));
        CardsList.Add(new Card(17,  "fire", "yellow", 18, Resources.Load<Sprite>("Cards/Fire/fire_18")));
        CardsList.Add(new Card(18,  "fire", "blue",   19, Resources.Load<Sprite>("Cards/Fire/fire_19")));
        CardsList.Add(new Card(19,  "fire", "green",  20, Resources.Load<Sprite>("Cards/Fire/fire_20")));
        
        CardsList.Add(new Card(20, "water", "orange", 1,  Resources.Load<Sprite>("water_01")));
        CardsList.Add(new Card(21, "water", "grey",   2,  Resources.Load<Sprite>("water_02")));
        CardsList.Add(new Card(22, "water", "yellow", 3,  Resources.Load<Sprite>("water_03")));
        CardsList.Add(new Card(23, "water", "blue",   4,  Resources.Load<Sprite>("water_04")));
        CardsList.Add(new Card(24, "water", "green",  5,  Resources.Load<Sprite>("water_05")));
        CardsList.Add(new Card(25, "water", "orange", 6,  Resources.Load<Sprite>("water_06")));
        CardsList.Add(new Card(26, "water", "grey",   7,  Resources.Load<Sprite>("water_07")));
        CardsList.Add(new Card(27, "water", "yellow", 8,  Resources.Load<Sprite>("water_08")));
        CardsList.Add(new Card(28, "water", "blue",   9,  Resources.Load<Sprite>("water_09")));
        CardsList.Add(new Card(29, "water", "green",  10, Resources.Load<Sprite>("water_10")));
        CardsList.Add(new Card(30, "water", "orange", 11, Resources.Load<Sprite>("water_11")));
        CardsList.Add(new Card(31, "water", "grey",   12, Resources.Load<Sprite>("water_12")));
        CardsList.Add(new Card(32, "water", "yellow", 13, Resources.Load<Sprite>("water_13")));
        CardsList.Add(new Card(33, "water", "blue",   14, Resources.Load<Sprite>("water_14")));
        CardsList.Add(new Card(34, "water", "green",  15, Resources.Load<Sprite>("water_15")));
        CardsList.Add(new Card(35, "water", "orange", 16, Resources.Load<Sprite>("water_16")));
        CardsList.Add(new Card(36, "water", "grey",   17, Resources.Load<Sprite>("water_17")));
        CardsList.Add(new Card(37, "water", "yellow", 18, Resources.Load<Sprite>("water_18")));
        CardsList.Add(new Card(38, "water", "blue",   19, Resources.Load<Sprite>("water_19")));
        CardsList.Add(new Card(39, "water", "green",  20, Resources.Load<Sprite>("water_20")));
        
        CardsList.Add(new Card(40, "wood", "orange", 1,  Resources.Load<Sprite>("wood_01")));
        CardsList.Add(new Card(41, "wood", "grey",   2,  Resources.Load<Sprite>("wood_02")));
        CardsList.Add(new Card(42, "wood", "yellow", 3,  Resources.Load<Sprite>("wood_03")));
        CardsList.Add(new Card(43, "wood", "blue",   4,  Resources.Load<Sprite>("wood_04")));
        CardsList.Add(new Card(44, "wood", "green",  5,  Resources.Load<Sprite>("wood_05")));
        CardsList.Add(new Card(45, "wood", "orange", 6,  Resources.Load<Sprite>("wood_06")));
        CardsList.Add(new Card(46, "wood", "grey",   7,  Resources.Load<Sprite>("wood_07")));
        CardsList.Add(new Card(47, "wood", "yellow", 8,  Resources.Load<Sprite>("wood_08")));
        CardsList.Add(new Card(48, "wood", "blue",   9,  Resources.Load<Sprite>("wood_09")));
        CardsList.Add(new Card(49, "wood", "green",  10, Resources.Load<Sprite>("wood_10")));
        CardsList.Add(new Card(50, "wood", "orange", 11, Resources.Load<Sprite>("wood_11")));
        CardsList.Add(new Card(51, "wood", "grey",   12, Resources.Load<Sprite>("wood_12")));
        CardsList.Add(new Card(52, "wood", "yellow", 13, Resources.Load<Sprite>("wood_13")));
        CardsList.Add(new Card(53, "wood", "blue",   14, Resources.Load<Sprite>("wood_14")));
        CardsList.Add(new Card(54, "wood", "green",  15, Resources.Load<Sprite>("wood_15")));
        CardsList.Add(new Card(55, "wood", "orange", 16, Resources.Load<Sprite>("wood_16")));
        CardsList.Add(new Card(56, "wood", "grey",   17, Resources.Load<Sprite>("wood_17")));
        CardsList.Add(new Card(57, "wood", "yellow", 18, Resources.Load<Sprite>("wood_18")));
        CardsList.Add(new Card(58, "wood", "blue",   19, Resources.Load<Sprite>("wood_19")));
        CardsList.Add(new Card(59, "wood", "green",  20, Resources.Load<Sprite>("wood_20")));
    }
}
