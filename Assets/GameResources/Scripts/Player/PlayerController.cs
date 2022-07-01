using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(PlayerMove))]

public class PlayerController : MonoBehaviour
{
    public Action OnDieEvent = null;
    private PlayerInput playerInput = null;
    private PlayerMove playerMove = null;
    private CharacterController characterController = null;
    private PlayerShoot playerShoot = null;
    private GameTag gameTag = null;
    private PlayerTakeDamage playerTakeDamage = null;

    public void Init()
    {
        Cach();
        playerMove.Init(playerInput, characterController, OnDieEvent);
        playerShoot.Init(gameTag, playerInput, MainController.Instance.GameController.MainCamera, MainController.Instance.GameController.BulletsPool);
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