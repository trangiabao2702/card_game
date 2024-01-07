using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour, IPointerClickHandler
{
    public List<Card> DisplayCards = new List<Card>();
    public int DisplayId;

    public int CardId;
    public int CardPower;
    public string CardElement;
    public string CardColor;
    public Sprite CardSpriteImage;

    public Image CardImage;

    void Start()
    {
        DisplayCards.Clear();
        DisplayCards.Add(CardDatabase.CardsList[DisplayId]);
    }

    void Update()
    {
        CardId = DisplayCards[0].Id;
        CardPower = DisplayCards[0].Power;
        CardElement = DisplayCards[0].Element;
        CardColor = DisplayCards[0].Color;
        CardSpriteImage = DisplayCards[0].SpriteImage;

        CardImage.sprite = CardSpriteImage;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (DisplayCards[0].IsSelected == false)
        {
            DisplayCards[0].IsSelected = true;
            this.transform.position += Vector3.up * 20f;
        }
    }
}
