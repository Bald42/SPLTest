using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Camera camera = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private EnemyController[] enemyControllers = null;

    public Camera Camera
    {
        get
        {
            return camera;
        }
    }

    public PlayerController PlayerController
    {
        get
        {
            return playerController;
        }
    }

    public void Init()
    {
        // TODO переделать на поиск по тегу
        playerController.Init();
        for (int i = 0; i < enemyControllers.Length; i++)
        {
            enemyControllers[i].Init();
        }
    }
}