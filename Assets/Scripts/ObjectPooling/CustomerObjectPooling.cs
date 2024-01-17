using System.Collections.Generic;
using UnityEngine;

public class CustomerObjectPooling : MonoBehaviour
{
    #region Singleton
    public static CustomerObjectPooling Instance;
    #endregion
    [SerializeField] GameObject prefab; // Havuzda bulunacak GameObject'in prefab'ý
    [SerializeField] private int poolSize; // Havuzdaki nesne sayýsý

    private List<GameObject> objectPool = new List<GameObject>();

    private void Awake()
    {
        if (Instance!=null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        InitializeObjectPool();
    }

    void InitializeObjectPool()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab,transform.position,Quaternion.identity,transform); // Prefab'ý sahnede instantiate et
            obj.SetActive(true); // Baþlangýçta pasif yap

            objectPool.Add(obj); // Havuza ekle
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Havuzda aktif olmayan nesne kalmadýysa yeni bir nesne instantiate et
        GameObject newObj = Instantiate(prefab, transform);
        objectPool.Add(newObj);

        newObj.SetActive(true);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false); // Nesneyi pasif yap
    }


    public List<GameObject> GetCustomers()
    {
        return objectPool;
    }
}
