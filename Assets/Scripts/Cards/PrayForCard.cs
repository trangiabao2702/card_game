using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrayForCard : MonoBehaviour, IPointerClickHandler
{
    public GameObject Card;
    public int NumberSummonCards;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Card.GetComponent<SummonCard>().Summon();
        Card.transform.Find("Back").gameObject.SetActive(true);
    }
}
