using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private bool invert;
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        Canvas canvas =GetComponent<Canvas>();
        canvas.worldCamera=Camera.main;
    }

    private void LateUpdate()
    {

        if (invert)
        {
            Vector3 dirToCamera = (cameraTransform.transform.position - transform.position).normalized;
            transform.LookAt(transform.position + dirToCamera * -1);
        }
        else
        {
            transform.LookAt(cameraTransform);
        }

    }
}
