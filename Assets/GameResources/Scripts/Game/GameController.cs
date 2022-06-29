using System.Linq;
using UnityEngine;
using static Enums;

public class GameController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private BulletsPool bulletsPool = null;
    private PlayerController playerController = null;
    [SerializeField] private EnemyController[] enemyControllers = null;

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
        for (int i = 0; i < enemyControllers.Length; i++)
        {
            enemyControllers[i].Init();
        }
    }

    private void FindUnits()
    {
        GameTag[] allGameTags = FindObjectsOfType<GameTag>();
        GameTag[] enemies = FindObjectsOfType<GameTag>();
        playerController = allGameTags.Where(x => x.MyTag == Tag.Player).FirstOrDefault().GetComponent<PlayerController>();
        enemies = allGameTags.Where(x => x.MyTag == Tag.Enemy && x.gameObject.activeSelf).ToArray();
        enemyControllers = new EnemyController[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyControllers[i] = enemies[i].GetComponent<EnemyController>();
        }
    }
}