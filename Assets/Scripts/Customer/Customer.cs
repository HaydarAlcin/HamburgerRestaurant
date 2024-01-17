using UnityEngine;

public class Customer : MonoBehaviour
{
    [Header("References")]
    private CustomerMovement _movement;
    private CustomerAction _action;

    private void Awake()
    {
        _movement=GetComponent<CustomerMovement>();
        _action=GetComponent<CustomerAction>();
    }

    private void OnEnable()
    {
        CoreGameSignals.Instance.OnCustomerFirst += OnCustomerFirst;
        CoreGameSignals.Instance.OnCustomerInLine += OnCustomerInLine;
    }

    public void OnCustomerFirst(Customer customer, Transform serviceTarget)
    {
        if (customer == this)
        {

            _movement.SetDataTransform(serviceTarget);
            _action.ActiveTheCanvas();
        }
    }

    public void OnCustomerInLine(Customer customer, Transform target)
    {
        if (customer == this)
        {
            _movement.SetDataTransform(target);
        }
    }

    private void OnDisable()
    {
        CoreGameSignals.Instance.OnCustomerFirst -= OnCustomerFirst;
        CoreGameSignals.Instance.OnCustomerInLine -= OnCustomerInLine;
    }

    public virtual void TakeTheBurger()
    {
        _action.TakeTheBurger();
    }
}
