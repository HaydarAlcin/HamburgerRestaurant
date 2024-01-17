using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;

    #region Private Variables
    private PlayerInput playerInput;
    private Vector3 input;
  
    private Rigidbody rb;
    
    #endregion


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        GetInput();
        RotateChar();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        MoveChar();
    }


    private void MoveChar()
    {
        rb.MovePosition(transform.position + (transform.forward * input.z * speed * Time.fixedDeltaTime));
    }
    private void GetInput()
    {
        input.x = playerInput.HorizontalInput;
        input.z = playerInput.VerticalInput;
    }

    private void UpdateAnimation()
    {
        //animation
        anim.SetFloat("Speed", input.z);
    }
    private void RotateChar()
    {
        transform.Rotate(Vector3.up * sensitivity * input.x);
    }
}
