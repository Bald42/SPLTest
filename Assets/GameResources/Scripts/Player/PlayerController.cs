using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(PlayerMove))]

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput = null;
    private PlayerMove playerMove = null;
    private CharacterController characterController = null;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Cach();
        playerInput.Init();
        playerMove.Init(playerInput, characterController);
    }

    private void Cach()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        characterController = GetComponent<CharacterController>();
    }
}