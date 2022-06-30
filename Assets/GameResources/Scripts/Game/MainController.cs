using UnityEngine;
using System;

public class MainController : MonoBehaviour
{
    public Action OnDestroyEvent = null;
    public Action OnUpdateEvent = null;
    public Action OnFixedUpdateEvent = null;

    [SerializeField] private GameController gameController = null;
    [SerializeField] private UIController uIController = null;
    private static MainController instance = null;

    public static MainController Instance
    {
        get
        {
            return instance;
        }
    }

    public GameController GameController
    {
        get
        {
            return gameController;
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        instance = this;
        gameController.Init();
        uIController.Init();
    }

    private void Update()
    {
        OnUpdateEvent?.Invoke();
    }

    private void FixedUpdate()
    {
        OnFixedUpdateEvent?.Invoke();
    }

    private void OnDestroy()
    {
        OnDestroyEvent?.Invoke();
    }
}