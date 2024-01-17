using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailItem : MonoBehaviour
{

    public void ChangeSprite(Sprite newSprite)
    {
        var image = GetComponent<Image>();
        image.sprite = newSprite;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
