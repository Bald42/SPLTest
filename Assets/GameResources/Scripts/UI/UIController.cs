using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIAim uIAim = null;

    public void Init()
    {
        uIAim.Init(MainController.Instance.GameController.MainCamera);
    }
}