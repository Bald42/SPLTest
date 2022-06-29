using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyController : MonoBehaviour
{
    private EnemyMove enemyMove = null;

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