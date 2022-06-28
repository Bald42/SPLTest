using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float rotationSensitivity = 0.01f;
    [SerializeField] private bool isInvertY = false;

    private const string VERTICAL = "Vertical";
    private const string HORIZONTAL = "Horizontal";
    private const string LOOK_X = "Mouse X";
    private const string LOOK_Y = "Mouse Y";

    private Vector3 moveVector = Vector3.zero;

    public void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private bool CanProcessInput()
    {
        return true;
    }

    public Vector3 GetMoveInput()
    {
        if (CanProcessInput())
        {
            moveVector.x = Input.GetAxisRaw(HORIZONTAL);
            moveVector.z = Input.GetAxisRaw(VERTICAL);
            moveVector = Vector3.ClampMagnitude(moveVector, 1);
            return moveVector;
        }

        return Vector3.zero;
    }

    public float GetLookInputsHorizontal()
    {
        return Input.GetAxisRaw(LOOK_X) * rotationSensitivity;
    }

    public float GetLookInputsVertical()
    {
        return Input.GetAxisRaw(LOOK_Y) * rotationSensitivity * CheckInvert;
    }

    private float CheckInvert
    {
        get
        {
            if (isInvertY)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

    public bool GetFireInput()
    {
        return Input.GetMouseButtonDown(0);
    }
}