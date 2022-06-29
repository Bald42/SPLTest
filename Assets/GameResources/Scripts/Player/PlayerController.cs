using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(PlayerMove))]

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput = null;
    private PlayerMove playerMove = null;
    private CharacterController characterController = null;
    private PlayerShoot playerShoot = null;
    private GameTag gameTag = null;
    private PlayerTakeDamage playerTakeDamage = null;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Cach();
        playerInput.Init();
        playerMove.Init(playerInput, characterController);
        playerShoot.Init(gameTag, playerInput, MainController.Instance.GameController.Camera);
        playerTakeDamage.Init(gameTag, playerMove);
    }

    private void Cach()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        characterController = GetComponent<CharacterController>();
        playerShoot = GetComponent<PlayerShoot>();
        gameTag = GetComponent<GameTag>();
        playerTakeDamage = GetComponent<PlayerTakeDamage>();
    }
}