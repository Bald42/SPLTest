using UnityEngine;
using System;

public class MainController : MonoBehaviour
{
    public Action OnDestroyEvent = null;
    public Action OnUpdateEvent = null;

    [SerializeField] private GameController gameController = null;
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
    }

    private void Update()
    {
        OnUpdateEvent?.Invoke();
    }

    private void OnDestroy()
    {
        OnDestroyEvent?.Invoke();
    }
}