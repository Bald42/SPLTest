using UnityEngine;

public class BaseSuscribe : MonoBehaviour
{
    protected void OnDestroy()
    {
        Unsubscribe();
    }

    protected virtual void Subscribe()
    {
        MainController.Instance.OnDestroyEvent += OnDestroyHandler;
        MainController.Instance.OnUpdateEvent += OnUpdateHandler;
        MainController.Instance.OnFixedUpdateEvent += OnFixedUpdateHandler;
    }

    protected virtual void Unsubscribe()
    {
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
        MainController.Instance.OnUpdateEvent -= OnUpdateHandler;
        MainController.Instance.OnFixedUpdateEvent -= OnFixedUpdateHandler;
    }

    protected virtual void OnDestroyHandler()
    {
        Unsubscribe();
    }

    protected virtual void OnUpdateHandler()
    {
    }

    protected virtual void OnFixedUpdateHandler()
    {
    }
}