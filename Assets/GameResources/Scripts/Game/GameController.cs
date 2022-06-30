using System.Linq;
using UnityEngine;
using static Enums;

public class GameController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private BulletsPool bulletsPool = null;
    [SerializeField] private ViewExplosionParticle viewExplosionParticle = null;
    private PlayerController playerController = null;
    private EnemyController[] enemyControllers = null;

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

    public void Init()
    {
        FindUnits();
        playerController.Init();
        viewExplosionParticle.Init();
        for (int i = 0; i < enemyControllers.Length; i++)
        {
            enemyControllers[i].Init();
        }
    }

    private void FindUnits()
    {
        enemyControllers = FindObjectsOfType<EnemyController>();
        playerController = FindObjectOfType<PlayerController>();
    }
}