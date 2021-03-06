using static Enums;
using UnityEngine;

public class EnemyMove : BaseSuscribe, IMove
{
    [SerializeField] private EnemyMoveVector enemyMoveVector = default;
    [SerializeField] private float speed = 5f;

    private float checkDistance = 0.5f;

    private float direction = 1f;
    private Vector3 directionVector = default;
    private RaycastHit hit = default;

    public void Init()
    {
        if (enemyMoveVector == EnemyMoveVector.Null)
        {
            return;
        }

        if (enemyMoveVector == EnemyMoveVector.MoveX)
        {
            directionVector = Vector3.left;
        }
        else if (enemyMoveVector == EnemyMoveVector.MoveZ)
        {
            directionVector = Vector3.forward;
        }
        Subscribe();
    }

    public void Move()
    {
        CheckGround();
        transform.Translate(directionVector * speed * direction * Time.fixedDeltaTime);
    }

    protected override void OnFixedUpdateHandler()
    {
        Move();
    }

    private void CheckGround()
    {
        if (!Physics.Raycast(transform.position + (directionVector * checkDistance * direction), Vector3.down, out hit, 2f))
        {
            ChangeDirection();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameTag gameTag = collision.gameObject.GetComponentInChildren<GameTag>();
        if (gameTag != null && gameTag.MyTag == Tag.Obstacle)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        direction *= -1;
    }
}