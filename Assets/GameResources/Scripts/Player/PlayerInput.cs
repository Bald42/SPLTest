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

    private bool CanProcessInput()
    {
        return MainController.Instance.GameController.GameState == Enums.GameState.Play;
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
        return CanProcessInput() ? Input.GetAxisRaw(LOOK_X) * rotationSensitivity : 0f;
    }

    public float GetLookInputsVertical()
    {
        return CanProcessInput() ? Input.GetAxisRaw(LOOK_Y) * rotationSensitivity * CheckInvert : 0f;
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
        return CanProcessInput() && Input.GetMouseButtonDown(0);
    }
}