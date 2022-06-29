using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyController : MonoBehaviour
{
    private EnemyMove enemyMove = null;
    private EnemyShoot enemyShoot = null;
    private GameTag gameTag = null;
    private EnemyTakeDamage enemyTakeDamage = null;

    public void Init()
    {
        Cach();
        enemyMove.Init();
        enemyShoot.Init(gameTag, MainController.Instance.GameController.PlayerController.transform);
        enemyTakeDamage.Init(gameTag);
    }

    private void Cach()
    {
        enemyMove = GetComponent<EnemyMove>();
        enemyShoot = GetComponent<EnemyShoot>();
        gameTag = GetComponent<GameTag>();
        enemyTakeDamage = GetComponent<EnemyTakeDamage>();
    }
}