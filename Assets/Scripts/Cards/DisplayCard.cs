using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour, IPointerClickHandler
{
    private Card PlayerCard;

    public int CardId;
    public int CardPower;
    public string CardElement;
    public string CardColor;
    public Sprite CardSpriteImage;

    public Image CardImage;

    public DisplayCard(int cardId, Vector3 position)
    {
        PlayerCard = CardDatabase.CardsList[cardId];

        CardId = PlayerCard.Id;
        CardPower = PlayerCard.Power;
        CardElement = PlayerCard.Element;
        CardColor = PlayerCard.Color;
        CardSpriteImage = PlayerCard.SpriteImage;

        CardImage.sprite = CardSpriteImage;

        this.transform.position = position;
    }

    void Update()
    {
        if (PlayerCard != null)
        {
            CardId = PlayerCard.Id;
            CardPower = PlayerCard.Power;
            CardElement = PlayerCard.Element;
            CardColor = PlayerCard.Color;
            CardSpriteImage = PlayerCard.SpriteImage;

            CardImage.sprite = CardSpriteImage;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (PlayerCard.IsSelected == false)
        {
            PlayerCard.IsSelected = true;
            this.transform.position += Vector3.up * 20f;
        }
    }

    public void SetDisplayCard(int cardId, Vector3 position)
    {
        print("Render card " + cardId + " at position " + position);
        PlayerCard = CardDatabase.CardsList[cardId];

        CardId = PlayerCard.Id;
        CardPower = PlayerCard.Power;
        CardElement = PlayerCard.Element;
        CardColor = PlayerCard.Color;
        CardSpriteImage = PlayerCard.SpriteImage;

        CardImage.sprite = CardSpriteImage;

        this.transform.position = position;
        //print("Power: " + CardPower + "; Element: " + CardElement + "; Color: " + CardColor + "; SpriteImage: " + CardSpriteImage);
    }
}
