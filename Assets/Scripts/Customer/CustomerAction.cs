using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerAction : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject customerCanvas;
    [SerializeField] private TextMeshProUGUI neededHamburgerText;

    private Customer _customer;
    private CustomerMovement _customerMovement;
    private int neededBurger;

    private void Start()
    {
        _customer = GetComponent<Customer>();
        _customerMovement = GetComponent<CustomerMovement>();
        neededBurger = Random.Range(1, 5);
        neededHamburgerText.text = neededBurger.ToString();
    }

    public void TakeTheBurger()
    {
        neededBurger -= 1;
        if (neededBurger <= 0)
        {
            //sipariþi hazýr sandalyeye gidebilir
            List<GameObject> emptyChairs = EatingPlace.Instance.GetEmptyChairs();
            int lenght = Random.Range(0, emptyChairs.Count + 1);
            _customerMovement.SetDataTransform(emptyChairs[lenght].transform);
            customerCanvas.SetActive(false);

            EatingPlace.Instance.EmptyChairDecreased(emptyChairs[lenght]);
            ServiceController.Instance.RemoveCustomer(_customer);
        }
        neededHamburgerText.text = neededBurger.ToString();
    }

    public void ActiveTheCanvas()
    {
        customerCanvas.SetActive(true);
    }
}
