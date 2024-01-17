using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


[Serializable] 
public class DetailCard
{
    public string sprite;
    public bool inDeck;
    public bool playerGet;

    public DetailCard(string spriteImage, bool inDeck = false, bool playerGet = false)
    {
        this.sprite = spriteImage;
        this.inDeck = inDeck;
        this.playerGet = playerGet;
    }
}

public class Inventory : MonoBehaviour, IPointerClickHandler
{
    string[] cardSprites = {
        "Cards/Fire/fire_01","Cards/Water/water_01","Cards/Wood/wood_01",
        "Cards/Fire/fire_02","Cards/Water/water_02","Cards/Wood/wood_02",
        "Cards/Fire/fire_03","Cards/Water/water_03","Cards/Wood/wood_03",
        "Cards/Fire/fire_04","Cards/Water/water_04","Cards/Wood/wood_04",
        "Cards/Fire/fire_05","Cards/Water/water_05","Cards/Wood/wood_05",
        "Cards/Fire/fire_06","Cards/Water/water_06","Cards/Wood/wood_06",
        "Cards/Fire/fire_07","Cards/Water/water_07","Cards/Wood/wood_07",
        "Cards/Fire/fire_08","Cards/Water/water_08","Cards/Wood/wood_08",
        "Cards/Fire/fire_09","Cards/Water/water_09","Cards/Wood/wood_09",
        "Cards/Fire/fire_10","Cards/Water/water_10","Cards/Wood/wood_10",
        "Cards/Fire/fire_11","Cards/Water/water_11","Cards/Wood/wood_11",
        "Cards/Fire/fire_12","Cards/Water/water_12","Cards/Wood/wood_12",
        "Cards/Fire/fire_13","Cards/Water/water_13","Cards/Wood/wood_13",
        "Cards/Fire/fire_14","Cards/Water/water_14","Cards/Wood/wood_14",
        "Cards/Fire/fire_15","Cards/Water/water_15","Cards/Wood/wood_15",
        "Cards/Fire/fire_16","Cards/Water/water_16","Cards/Wood/wood_16",
        "Cards/Fire/fire_17","Cards/Water/water_17","Cards/Wood/wood_17",
        "Cards/Fire/fire_18","Cards/Water/water_18","Cards/Wood/wood_18",
        "Cards/Fire/fire_19","Cards/Water/water_19","Cards/Wood/wood_19",
        "Cards/Fire/fire_20","Cards/Water/water_20","Cards/Wood/wood_20",
    };
    [SerializeField] InventoryItems inventoryCardPrefab;
    [SerializeField] RectTransform ItemsPanel;
    [SerializeField] DetailItem detailItem;
    public List<DetailCard> cards = new List<DetailCard>();

    public List<InventoryItems> listOfUIItems = new List<InventoryItems>();
    // Start is called before the first frame update
    void Start()
    {
        //cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/fire_01"), true, true));
        //cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/fire_02"), true, true));
        //cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Water/water_01"), true, true));
        //cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Water/water_02"), true, true));
        //cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Wood/wood_01"), true, true));
        //cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Wood/wood_02"), true, true));
        //string randomCard = cardSprites[new Random().Next(6, 16)];
        //cards.Add(new DetailCard(Resources.Load<Sprite>(randomCard), true, true));

        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            Debug.Log("Press I");
        }
    }

    public void InitInventory()
    {
        cards.Add(new DetailCard("Cards/Fire/fire_01", true, true));
        cards.Add(new DetailCard("Cards/Fire/fire_02", true, true));
        cards.Add(new DetailCard("Cards/Water/water_01", true, true));
        cards.Add(new DetailCard("Cards/Water/water_02", true, true));
        cards.Add(new DetailCard("Cards/Wood/wood_01", true, true));
        cards.Add(new DetailCard("Cards/Wood/wood_02", true, true));
        Debug.Log(cards);
        string json = JsonUtility.ToJson(cards, true);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/playerCards.json", json);
        for (int i = 0; i < 60; i++)
        {
            InventoryItems newCard = Instantiate(inventoryCardPrefab, Vector3.zero, Quaternion.identity);
            if (i < cards.Count)
            {
                newCard.ChangeSprite(Resources.Load<Sprite>(cards[i].sprite));
            }
            newCard.transform.SetParent(ItemsPanel);
            listOfUIItems.Add(newCard);
        }
    }

    public void LoadInventory()
    {
        while (ItemsPanel.childCount > 0)
        {
            DestroyImmediate(ItemsPanel.GetChild(0).gameObject);
        }
        listOfUIItems.Clear();
        Debug.Log("delete");
        Debug.Log(ItemsPanel);
        Debug.Log(listOfUIItems);
        Debug.Log(cards);
        for (int i = 0; i < 60; i++)
        {
            InventoryItems newCard = Instantiate(inventoryCardPrefab, Vector3.zero, Quaternion.identity);
            if (i < cards.Count)
            {
                newCard.ChangeSprite(Resources.Load<Sprite>(cards[i].sprite));
            }
            newCard.transform.SetParent(ItemsPanel);
            listOfUIItems.Add(newCard);
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData);
    }
}
