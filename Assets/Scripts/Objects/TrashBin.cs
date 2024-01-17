using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour, IPutItemFull
{
    public void ClearItemType()
    {
        
    }

    public ItemType GetCurrentItem()
    {
        return ItemType.NONE;
    }

    public bool PutItem(ItemType itemType)
    {
        return true;
    }

    public void ProcessItem()
    {
        
    }
}
