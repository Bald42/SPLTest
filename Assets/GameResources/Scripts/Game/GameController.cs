using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private EnemyController[] enemyControllers = null;

    public void Init()
    {
        // TODO ���������� �� ����� �� ����
        playerController.Init();
        for (int i = 0; i < enemyControllers.Length; i++)
        {
            enemyControllers[i].Init();
        }
    }
}