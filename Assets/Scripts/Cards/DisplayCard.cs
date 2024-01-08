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
        print("Set display card " + cardId);
        PlayerCard = CardDatabase.CardsList[cardId];

        CardId = PlayerCard.Id;
        CardPower = PlayerCard.Power;
        CardElement = PlayerCard.Element;
        CardColor = PlayerCard.Color;
        CardSpriteImage = PlayerCard.SpriteImage;

        CardImage.sprite = CardSpriteImage;

        this.transform.position = position;
        this.transform.localScale = Vector3.one;
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

    public void PlayCard()
    {
        float x = 1500f;
        float y = 650f;
        float z = 1f;
        this.transform.position = new Vector3(x, y, z);
        this.transform.localScale = Vector3.one * 2f;
    }
}
