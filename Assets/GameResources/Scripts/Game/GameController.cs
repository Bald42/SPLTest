using static Enums;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public static Action<GameState> OnChangeGameStateEvent = null;

    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private BulletsPool bulletsPool = null;
    [SerializeField] private ViewExplosionParticle viewExplosionParticle = null;
    private PlayerController playerController = null;
    private EnemyController[] enemyControllers = null;
    private GameState gameState = GameState.Null;

    public GameState GameState
    {
        get
        {
            return gameState;
        }
    }

    public Camera MainCamera
    {
        get
        {
            return mainCamera;
        }
    }

    public PlayerController PlayerController
    {
        get
        {
            return playerController;
        }
    }

    public BulletsPool BulletsPool
    {
        get
        {
            return bulletsPool;
        }
    }

    #region Subscribe

    private void Sunscribe()
    {
        MainController.Instance.OnDestroyEvent += OnDestroyHandler;
        FinishTrigger.OnFinishEvent += OnFinishHandler;
        playerController.OnDieEvent += OnDieHandler;
    }

    private void Unsubscribe()
    {
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
        FinishTrigger.OnFinishEvent -= OnFinishHandler;
        playerController.OnDieEvent -= OnDieHandler;
    }

    private void OnDestroyHandler()
    {
        Unsubscribe();
    }

    private void OnFinishHandler()
    {
        ChangeGameState(GameState.Win);
    }

    private void OnDieHandler()
    {
        Debug.Log("OnDieHandler");

        ChangeGameState(GameState.Lose);
    }

    #endregion

    public void Init()
    {
        FindUnits();
        Sunscribe();
        playerController.Init();
        viewExplosionParticle.Init();
        for (int i = 0; i < enemyControllers.Length; i++)
        {
            enemyControllers[i].Init();
        }
        ChangeGameState(GameState.Play);
    }

    private void FindUnits()
    {
        enemyControllers = FindObjectsOfType<EnemyController>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void ChangeGameState(GameState gameState)
    {
        this.gameState = gameState;
        ChangeStateMouse(gameState);
        Debug.Log(gameState);
        OnChangeGameStateEvent?.Invoke(gameState);
    }

    private void ChangeStateMouse(GameState gameState)
    {
        if (gameState == GameState.Play)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}