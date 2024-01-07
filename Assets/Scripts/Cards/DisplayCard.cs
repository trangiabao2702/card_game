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
    public bool IsSelected = false;

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

    //void Update()
    //{
    //    if (PlayerCard != null)
    //    {
    //        CardId = PlayerCard.Id;
    //        CardPower = PlayerCard.Power;
    //        CardElement = PlayerCard.Element;
    //        CardColor = PlayerCard.Color;
    //        CardSpriteImage = PlayerCard.SpriteImage;

    //        CardImage.sprite = CardSpriteImage;
    //    }
    //}

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (IsSelected == false)
        {
            DeselectOldSelectedCard();

            IsSelected = true;
            this.transform.position += Vector3.up * 20f;
        }
    }

    public void SetDisplayCard(int cardId, Vector3 position)
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

    private void DeselectOldSelectedCard()
    {
        GameObject[] playerOnHandCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (GameObject card in playerOnHandCards)
        {
            if (card.GetComponent<DisplayCard>().IsSelected)
            {
                card.GetComponent<DisplayCard>().IsSelected = false;
                card.GetComponent<DisplayCard>().transform.position -= Vector3.up * 20f;
                return;
            }
        }
    }
}
