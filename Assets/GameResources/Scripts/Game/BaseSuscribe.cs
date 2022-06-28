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
    }

    protected virtual void Unsubscribe()
    {
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
        MainController.Instance.OnUpdateEvent -= OnUpdateHandler;
    }

    protected virtual void OnDestroyHandler()
    {
        Unsubscribe();
    }

    protected virtual void OnUpdateHandler()
    {
    }
}