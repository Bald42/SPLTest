using UnityEngine;

public class PlayerMove : MonoBehaviour, IMove
{
    [Header("References")]
    [SerializeField] private Transform camPoint = null;
    [SerializeField] private float rotationSpeed = 0f;
    [SerializeField] private float gravityForce = 20f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float killHeight = -50f;
    [SerializeField] private float movementSharpnessOnGround = 15f;
    [SerializeField] private float damagePower = 10f;

    private PlayerInput playerInput = null;
    private CharacterController characterController = null;

    private Vector3 roationCamera = default;
    private Vector3 roationPlayer = default;
    private Vector3 characterVelocity = default;
    private Vector3 moveVector = default;
    private Vector3 damageVector = default;

    private bool isDie = false;
    private float deltaX = 0f;

    public void Init(PlayerInput playerInput, CharacterController characterController)
    {
        this.playerInput = playerInput;
        this.characterController = characterController;
    }

    private void Update()
    {
        Rotation();
        Move();
    }

    public void Move()
    {
        moveVector = (transform.TransformVector(playerInput.GetMoveInput()) + damageVector) * moveSpeed;
        characterVelocity = Vector3.Lerp(characterVelocity, moveVector, movementSharpnessOnGround * Time.deltaTime);
        damageVector = Vector3.Lerp(damageVector, Vector3.zero, movementSharpnessOnGround * Time.deltaTime);
        characterVelocity += Vector3.down * gravityForce * Time.deltaTime;
        characterController.Move(characterVelocity * Time.deltaTime);
    }

    public void TakeDamage(Vector3 direction)
    {
        damageVector = direction * damagePower;
    }

    #region Rotation

    private void Rotation()
    {
        RotationX();
        RotationY();
    }

    private void RotationX()
    {
        deltaX += playerInput.GetLookInputsVertical() * rotationSpeed;
        deltaX = Mathf.Clamp(deltaX, -89f, 89f);
        roationCamera.x = deltaX;
        camPoint.localEulerAngles = roationCamera;
    }

    private void RotationY()
    {
        roationPlayer.y = playerInput.GetLookInputsHorizontal() * rotationSpeed;
        transform.Rotate(roationPlayer);
    }

    #endregion
}