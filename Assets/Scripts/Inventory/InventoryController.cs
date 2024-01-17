using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] DetailItem detail;
    //public static InventoryController instance {  get; private set; }
    //private void Awake()
    //{
    //    if (instance == null && instance != this)
    //    {
    //        Destroy(this);
    //    }
    //    else
    //    {
    //        instance = this; 
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        inventory.InitInventory();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Press I");
            if(inventory.isActiveAndEnabled == false)
            {
                if(inventory.listOfUIItems.Count == 60)
                {
                    inventory.LoadInventory();
                }
                inventory.Open();
            }
            else
            {
                inventory.Close();
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
