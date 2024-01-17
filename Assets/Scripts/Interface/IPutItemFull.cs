
public interface IPutItemFull
{

    public bool PutItem(ItemType itemType);
    public void ProcessItem();

    public ItemType GetCurrentItem();

    public void ClearItemType();
}
