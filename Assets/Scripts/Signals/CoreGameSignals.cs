using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
    #region Singleton
    public static CoreGameSignals Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }
    #endregion
    public UnityAction<ObjectnType> OnItemPutTheTable = delegate { };
    public UnityAction<ObjectnType> OnItemPutTheSlicedTable = delegate { };
    public UnityAction OnItemSliced = delegate { };

    public UnityAction<Customer,Transform> OnCustomerFirst = delegate { };
    public UnityAction<Customer,Transform> OnCustomerInLine = delegate { };

}
