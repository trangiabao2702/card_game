using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviors : MonoBehaviour
{
    public bool isSelected = false;

    private GameObject selectedCard;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit.collider);
            if (hit.collider != null)
            {
                GameObject clickedCard = hit.collider.gameObject;

                // Check if a different card is being selected
                if (clickedCard != selectedCard)
                {
                    // Reset the previously selected card
                    if (selectedCard != null)
                    {
                        MoveCardToOriginalPosition();
                    }

                    // Select the new card and move it up
                    selectedCard = clickedCard;
                    originalPosition = selectedCard.transform.position;
                    MoveCardUp();
                }
            }
        }
    }

    private void MoveCardUp()
    {
        if (selectedCard != null)
        {
            Vector3 newPosition = originalPosition + Vector3.up * 20f;
            selectedCard.transform.position = newPosition;
        }
    }

    private void MoveCardToOriginalPosition()
    {
        if (selectedCard != null)
        {
            selectedCard.transform.position = originalPosition;
        }
    }
}
