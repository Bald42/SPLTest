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
        Caching();
        enemyMove.Init();
        enemyShoot.Init(gameTag);
        enemyTakeDamage.Init(gameTag);
    }

    private void Caching()
    {
        enemyMove = GetComponent<EnemyMove>();
        enemyShoot = GetComponent<EnemyShoot>();
        gameTag = GetComponent<GameTag>();
        enemyTakeDamage = GetComponent<EnemyTakeDamage>();
    }
}