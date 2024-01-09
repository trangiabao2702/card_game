using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int RemainCards;
    public List<int> PlayerDeck = new List<int>();

    [SerializeField] private TextMeshProUGUI uiText;

    private void Update()
    {
        uiText.text = "" + RemainCards;
    }

    public void InitializePlayerDeck(List<int> cardIds)
    {
        PlayerDeck.Clear();
        PlayerDeck.AddRange(cardIds);
        ShuffleDeck();

        RemainCards = PlayerDeck.Count;
        uiText.text = "" + RemainCards;
    }

    private void ShuffleDeck()
    {
        int n = PlayerDeck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = PlayerDeck[k];
            PlayerDeck[k] = PlayerDeck[n];
            PlayerDeck[n] = value;
        }
    }

    public int Draw()
    {
        if (PlayerDeck.Count > 0)
        {
            int firstCard = PlayerDeck[0];
            PlayerDeck.RemoveAt(0);
            RemainCards = PlayerDeck.Count;
            uiText.text = RemainCards.ToString();

            return firstCard;
        }

        return -1;
    }
}
