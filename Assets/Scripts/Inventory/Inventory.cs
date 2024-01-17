using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectnType
{
    public GameObject item;
    public ItemType slicedType;
    public ItemType type;
    public GameObject slicedItem;
}
public class Inventory : MonoBehaviour
{
    [Header("Burger")]
    [SerializeField] private GameObject burgerPrefab;
    [SerializeField] private int validNumberOfBurger;

    [Header("ItemTypes")]
    [SerializeField] private List<ObjectnType> itemsToHold = new List<ObjectnType>();
    private ItemType currentType;

    private void Start()
    {
        currentType = ItemType.BURGER;
    }

    public void TakeItem(ItemType type)
    {
        if (currentType != ItemType.NONE) return;

        currentType = type;
        if (currentType==ItemType.BURGER)
        {
            TakeTheBurger();
            return;
        }

        foreach (ObjectnType holdItem in itemsToHold) 
        {
            if (holdItem.type ==currentType)
            {
                holdItem.item.SetActive(true);
                holdItem.slicedItem.SetActive(false);

            }
            else if (holdItem.slicedType ==currentType)
            {
                holdItem.item.SetActive(false);
                holdItem.slicedItem.SetActive(true);
            }
            
        }
    }

    public void TakeSlicedItem(ItemType slicedItem)
    {
        if (currentType != ItemType.NONE) return;

        currentType = slicedItem;
        foreach (ObjectnType holdItem in itemsToHold)
        {
            if (holdItem.slicedType != currentType)
            {
                holdItem.item.SetActive(false);
                holdItem.slicedItem.SetActive(false);
                continue;
            }
            holdItem.item.SetActive(false);
            holdItem.slicedItem.SetActive(true);
        }
    }

    public ItemType PutItem()
    {
        if (currentType == ItemType.NONE) return ItemType.NONE;

        foreach (ObjectnType item in itemsToHold)
        {
            item.item.SetActive(false);
            item.slicedItem.SetActive(false);
        }
        //  itemsToHold.ForEach(obj => obj.item.SetActive(false));
        burgerPrefab.SetActive(false);
        return currentType;
    }


    public void TakeTheBurger()
    {
        burgerPrefab.SetActive(true);
        validNumberOfBurger++;
    }

    public void PutTheBurger()
    {
        burgerPrefab.SetActive(false);
        validNumberOfBurger--;
    }

    public void ClearHand()
    {
        currentType = ItemType.NONE;
    }

    public ItemType GetCurrentItem()
    {
       
        return currentType;
    }
}
