using UnityEngine;
using static InputControl.Inputs;

public class PlayerInput : MonoBehaviour
{
    public float VerticalInput { get => verticalInput; }
    public float HorizontalInput { get => horizontalInput;}

    private float verticalInput;
    private float horizontalInput;

    private void Update()
    {
        verticalInput = Input.GetAxis(Vertical);
        horizontalInput = Input.GetAxis(Horizontal);
    }
}
