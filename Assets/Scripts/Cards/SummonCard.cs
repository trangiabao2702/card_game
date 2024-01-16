using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SummonCard : MonoBehaviour, IPointerClickHandler
{
    private List<int> ListCardsCanSummon;
    private int CardToSummon = -1;

    void Start()
    {
        // Get list cards can be summonned
        ListCardsCanSummon = new List<int> { 0, 1, 2, 3, 4, 20, 21, 22, 23, 24, 40, 41, 42, 43, 44 };

        // Shuffle list
        int n = ListCardsCanSummon.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = ListCardsCanSummon[k];
            ListCardsCanSummon[k] = ListCardsCanSummon[n];
            ListCardsCanSummon[n] = value;
        }

        // Get the card to summon
        CardToSummon = ListCardsCanSummon[0];
        print(CardDatabase.CardsList.Count);

        // Make the front to be that card
        this.transform.Find("Front").gameObject.GetComponent<Image>().sprite = CardDatabase.CardsList[CardToSummon].SpriteImage;
    }

    public void Summon()
    {
        for (float i = 800f; i >= 0f; i -= 1f)
        {
            StartCoroutine(UpdateCardPosition(i));
        }
    }

    private IEnumerator UpdateCardPosition(float posY)
    {
        yield return new WaitForSeconds(0.001f * (800f - posY));

        this.transform.position = new Vector3(960f, 540f + posY, 0);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        for (float i = 0f; i <= 180f; i += 1f)
        {
            StartCoroutine(RotateCard(i));

            if (i == 90f)
            {
                this.transform.Find("Back").gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator RotateCard(float posY)
    {
        yield return new WaitForSeconds(0.001f * posY);

        if (posY <= 90f)
        {
            transform.rotation = Quaternion.Euler(0f, posY, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f - posY, 0f);
        }
    }
}
