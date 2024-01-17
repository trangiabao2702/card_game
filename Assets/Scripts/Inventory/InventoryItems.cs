using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    [SerializeField] GameObject detailItem;
    // Start is called before the first frame update
    public void ChangeSprite(Sprite newSprite)
    {
        var image = GetComponent<Image>();
        image.sprite = newSprite;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnMouseDown()
    //{
    //    var image = detail.GetComponent<Image>();
    //    image.sprite = gameObject.GetComponent<Image>().sprite;
    //}
}
