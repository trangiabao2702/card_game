using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailCard
{
    public Sprite sprite;
    public bool inDeck;
    public bool playerGet;

    public DetailCard(Sprite spriteImage, bool inDeck = false, bool playerGet = false)
    {
        this.sprite = spriteImage;
        this.inDeck = inDeck;
        this.playerGet = playerGet;
    }
}

class CardList
{
    public List<DetailCard> cards = new List<DetailCard>();

    public CardList()
    {
        cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/fire_01"), true, true));
        cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/fire_02"), true, true));
        cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/water_01"), true, true));
        cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/water_02"), true, true));
        cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/wood_01"), true, true));
        cards.Add(new DetailCard(Resources.Load<Sprite>("Cards/Fire/wood_02"), true, true));
        //string randomCard = cardSprites[new Random().Next(6, 16)];
        //cards.Add(new DetailCard(Resources.Load<Sprite>(randomCard), true, true));
    }
}

public class Inventory : MonoBehaviour
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
    [SerializeField] GameObject inventoryCardPrefab;
    [SerializeField] GameObject ItemsPanel;
    CardList cards = new CardList();

    //List<InventoryItems> listOfUIItems = new List<InventoryItems>();
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //public void InitInventory()
    //{
    //    for(int i = 0; i < 60; i++)
    //    {
    //        InventoryItems newCard = Instantiate(inventoryCardPrefab, Vector3.zero, Quaternion.identity);
    //        newCard.transform.SetParent(ItemsPanel);
    //        listOfUIItems.Add(newCard);
    //    }
    //}

    //public void setActive()
    //{
    //    this.gameObject.SetActive(!gameObject.active);
    //}
}
