using UnityEngine;

public enum ChairType
{
    EMPTY_CHAIR,
    FILLED_CHAIR
}

public class Chair : MonoBehaviour
{
    private ChairType chairType;

    public bool IsEmptyChair()
    {
        if (chairType ==ChairType.EMPTY_CHAIR) return true;

        return false;
    }

    public void EmptyChair()
    {
        chairType = ChairType.EMPTY_CHAIR;
    }
}
