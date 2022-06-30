using UnityEngine;

public class PlayerMove : BaseSuscribe, IMove
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
        Subscribe();
    }

    protected override void OnFixedUpdateHandler()
    {
        Move();
    }

    protected override void OnUpdateHandler()
    {
        Rotation();
    }

    public void Move()
    {
        moveVector = transform.TransformVector(playerInput.GetMoveInput()) * moveSpeed;
        characterVelocity = Vector3.Lerp(characterVelocity, moveVector + damageVector, movementSharpnessOnGround * Time.fixedDeltaTime);
        damageVector = Vector3.Lerp(damageVector, Vector3.zero, movementSharpnessOnGround * Time.fixedDeltaTime);
        characterVelocity += Vector3.down * gravityForce * Time.fixedDeltaTime;
        characterController.Move(characterVelocity * Time.fixedDeltaTime);
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