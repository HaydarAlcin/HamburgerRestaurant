using System.Collections.Generic;
using UnityEngine;

public class SliceBoard : MonoBehaviour , IPutItemFull
{
    [SerializeField] private List<ObjectnType> items = new List<ObjectnType>();
    private ItemType currentType;

    private void Start()
    {
        currentType = ItemType.NONE;
    }
    public bool PutItem(ItemType itemType)
    {
        if (currentType != ItemType.NONE) return false;
        currentType = itemType;
        if (currentType == ItemType.MEATBALL) 
        { 
            currentType= ItemType.NONE;
            return false; 
        }
        foreach (ObjectnType holdItem in items)
        {
            if (holdItem.type != currentType)
            {
                holdItem.item.SetActive(false);
                continue;
            }
            holdItem.item.SetActive(true);
        }

        return true;
    }

    public void ProcessItem()
    {
        if (currentType == ItemType.NONE) return;
        foreach (ObjectnType holdItem in items)
        {
            if (holdItem.type != currentType)
            {
                holdItem.item.SetActive(false);
                holdItem.slicedItem.SetActive(false);
                continue;
            }
            holdItem.item.SetActive(false);
            holdItem.slicedItem.SetActive(true);
            currentType = holdItem.slicedType;
        }
    }

    public ItemType GetCurrentItem()
    {
        return currentType;
    }

    public void ClearItemType()
    {
        
        foreach (ObjectnType holdItem in items)
        {
            holdItem?.item.SetActive(false);
            holdItem?.slicedItem.SetActive(false);
        }
        currentType = ItemType.NONE;
    }
}
