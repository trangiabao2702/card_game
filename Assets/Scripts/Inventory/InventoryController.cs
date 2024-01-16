using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] Inventory inventory;
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
    }
}
