using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SlicedObjectnType
{
    public GameObject slicedItem;
    public ItemType slicedType;
}


public class PreparationTable : MonoBehaviour, IPutItemFull
{
    [Header("BurgerObject")]
    [SerializeField] private GameObject burgerObject;

    [Header("Items")]
    [SerializeField] private List<SlicedObjectnType> itemTypes = new List<SlicedObjectnType>();

    private int currentIndex;
    private ItemType currentItem;

    private void Start()
    {
        currentItem = ItemType.SLICED_BREAD;
    }

    public void ClearItemType()
    {
        currentItem = ItemType.SLICED_BREAD;
        burgerObject.SetActive(false);
    }

    public ItemType GetCurrentItem()
    {
        return currentItem;
    }

    public bool PutItem(ItemType itemType)
    {
        Debug.Log("çalýþtý");
        if (currentItem != itemType) return false;
        itemTypes[currentIndex].slicedItem.SetActive(true);
        currentIndex++;
        if (currentIndex>=6)
        {
            ProcessItem();
            return true;
        }
        currentItem = itemTypes[currentIndex].slicedType;
        return true;
    }


    public void ProcessItem()
    {
        currentIndex = 0;
        burgerObject.SetActive(true);
        currentItem = ItemType.BURGER;
        itemTypes.ForEach(itemType => itemType.slicedItem.SetActive(false));
    }
}
