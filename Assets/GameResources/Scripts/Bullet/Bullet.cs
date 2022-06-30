using static Enums;
using UnityEngine;

public class Bullet : BasePool
{
    private Vector3 targetPosition = default;
    private Vector3 moveVector = default;
    private float speed = 10f;
    private Tag targetTag = Tag.Null;
    private Tag shooterTag = Tag.Null;

    public Tag TargetTag
    {
        get
        {
            return targetTag;
        }
    }

    #region Subscribe 

    private void Subscribe()
    {
        MainController.Instance.OnDestroyEvent += OnDestroyHandler;
        MainController.Instance.OnFixedUpdateEvent += OnFixedUpdateHandler;
    }

    private void Unsubscribe()
    {
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
        MainController.Instance.OnFixedUpdateEvent -= OnFixedUpdateHandler;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void OnDestroyHandler()
    {
        Unsubscribe();
    }

    private void OnFixedUpdateHandler()
    {
        Move();
    }

    #endregion

    public void Init(Vector3 startPosition,
                     Vector3 targetPosition,
                     Tag targetTag,
                     Tag shooterTag)
    {
        transform.position = startPosition;
        this.targetPosition = targetPosition;
        this.targetTag = targetTag;
        this.shooterTag = shooterTag;
        transform.LookAt(targetPosition);
        ChangeActive(true);
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            GameTag gameTag = other.gameObject.GetComponentInChildren<GameTag>();
            if (gameTag != null)
            {
                if (gameTag.MyTag != targetTag &&
                    gameTag.MyTag != shooterTag &&
                    gameTag.MyTag != Tag.Bullet)
                {
                    OnDeactiveAtCollision();
                }
            }
            else
            {
                OnDeactiveAtCollision();
            }
        }
    }

    public void OnDeactiveAtCollision()
    {
        ChangeActive(false);
    }

    protected override void ChangeActive(bool isActive)
    {
        base.ChangeActive(isActive);
        if (isActive)
        {
            Subscribe();
        }
        else
        {
            Unsubscribe();
        }
    }
}