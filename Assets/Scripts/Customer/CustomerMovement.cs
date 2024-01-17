using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator anim;
    [SerializeField] private CustomerData _customerData;

    [Header("Variables")]
    #region Serialize Variables
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float moveSpeed;
    #endregion
    private Transform _customerTransform;
    private bool isIdle;
    private void Start()
    {
        _customerTransform = transform;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        
    }
    private void Update()
    {
        UpdateAnimation();
    }

    private void HandleMovement()
    {

        if (_customerData.target == null) return;
        Vector3 moveDirection = (_customerData.target.position - transform.position).normalized;
        _customerTransform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.fixedDeltaTime * rotationSpeed);

        if (Vector3.Distance(_customerTransform.transform.position, _customerData.target.position) > stoppingDistance)
        {
            _customerTransform.position += (moveDirection * moveSpeed * Time.fixedDeltaTime);
            isIdle=false;
            return;
        }

        isIdle=true;
    }

    private void UpdateAnimation()
    {
        anim.SetBool("isIdle", isIdle);
    }

    public void SetDataTransform(Transform target)
    {
        _customerData.target = target;
    }
}
