using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIAim uIAim = null;
    [SerializeField] private UIFinish uIFinish = null;

    public UIFinish UIFinish
    {
        get
        {
            return uIFinish;
        }
    }

    public void Init()
    {
        uIAim.Init(MainController.Instance.GameController.MainCamera);
        uIFinish.Init();
    }
}