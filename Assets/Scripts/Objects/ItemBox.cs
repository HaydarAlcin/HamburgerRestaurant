using UnityEngine;

public class ItemBox : MonoBehaviour,IGetItem
{
    [SerializeField] private ItemType itemType;
    public ItemType GetItem()
    {
        return itemType;
    }

}
