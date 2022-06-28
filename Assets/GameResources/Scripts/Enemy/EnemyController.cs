using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyController : MonoBehaviour
{
    private EnemyMove enemyMove = null;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Cach();
        enemyMove.Init();
    }

    private void Cach()
    {
        enemyMove = GetComponent<EnemyMove>();
    }
}