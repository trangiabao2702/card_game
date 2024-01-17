using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBtn : MonoBehaviour
{
    [SerializeField] public GameObject guide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick()
    {
        Debug.Log("clicked");
        if (guide.gameObject.activeInHierarchy == false)
        {
            guide.SetActive(true);
        }
        else
        {
            guide.SetActive(false);
        }
    }
}
