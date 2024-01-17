public enum ItemType
{
    TOMATO,LETTUCE,ONION,CHEESE,MEATBALL,BREAD,NONE,
    SLICED_TOMATO,SLICED_LETTUCE, SLICED_ONION, SLICED_CHEESE, SLICED_BREAD, COOKED_MEAT,
    BURGER
}
public interface IGetItem
{
    public ItemType GetItem();
}
