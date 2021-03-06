using UnityEngine;
using System;

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
    private Vector3 damageVector = Vector3.zero;

    private float deltaX = 0f;
    private bool isDie = false;
    private Action onDieEvent = null;

    public void Init(PlayerInput playerInput, CharacterController characterController, Action onDieEvent)
    {
        this.playerInput = playerInput;
        this.characterController = characterController;
        this.onDieEvent += onDieEvent;
        Subscribe();
    }

    protected override void OnDestroyHandler()
    {
        base.OnDestroyHandler();
        onDieEvent = null;
    }

    protected override void OnFixedUpdateHandler()
    {
        CheckDie();
        Move();
    }

    protected override void OnUpdateHandler()
    {
        Rotation();
    }

    private void CheckDie()
    {
        if (transform.position.y <= killHeight)
        {
            if (!isDie)
            {
                isDie = true;
                onDieEvent?.Invoke();
            }
        }
    }

    public void Move()
    {
        if (isDie)
        {
            return;
        }
        moveVector = transform.TransformVector(playerInput.GetMoveInput()) * moveSpeed;
        characterVelocity = Vector3.Lerp(characterVelocity, moveVector + damageVector, movementSharpnessOnGround * Time.fixedDeltaTime);
        damageVector = Vector3.Lerp(damageVector, Vector3.zero, movementSharpnessOnGround * Time.fixedDeltaTime);
        characterVelocity += Vector3.down * gravityForce * Time.fixedDeltaTime;
        characterController.Move(characterVelocity * Time.fixedDeltaTime);
    }

    public void TakeDamage(Vector3 direction)
    {
        damageVector += direction * damagePower;
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