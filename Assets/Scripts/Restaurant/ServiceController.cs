using System.Collections.Generic;
using UnityEngine;

public class ServiceController : MonoBehaviour
{
    #region Singleton
    public static ServiceController Instance { get; private set; }
    #endregion

    [SerializeField] private Transform serviceTransform;

    private List<GameObject> customers = new List<GameObject>();
    private Customer firstCustomer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;

        
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Chair[] chairs = FindObjectsOfType<Chair>();
        customers = CustomerObjectPooling.Instance.GetCustomers();
        int number = 0;
        foreach (var item in customers)
        {
            
            if (number == 0)
            {
                number++;
                continue;
            }
            CoreGameSignals.Instance.OnCustomerInLine?.Invoke(item.GetComponent<Customer>(), customers[number - 1].transform);
            number++;

        }
        firstCustomer = customers[0].GetComponent<Customer>();
        CoreGameSignals.Instance.OnCustomerFirst?.Invoke(firstCustomer, serviceTransform);
    }

    public void ServeTheBurger()
    {
        firstCustomer.TakeTheBurger();
    }

    public void RemoveCustomer(Customer customer)
    {
        if (firstCustomer==customer)
        {
            customers.Remove(customer.gameObject);
            firstCustomer = customers[0].GetComponent<Customer>();
            CoreGameSignals.Instance.OnCustomerFirst?.Invoke(firstCustomer, serviceTransform);
        }
    }
}
