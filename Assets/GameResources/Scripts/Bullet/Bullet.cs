using static Enums;
using UnityEngine;
using System;

public class Bullet : BasePool
{
    public static Action<Vector3> OnDestroyBulletEvent = null;
    private Vector3 targetPosition = default;
    private Vector3 moveVector = default;
    private Vector3 collisionPosition = default;
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
        MainController.Instance.GameController.OnChangeGameStateEvent += OnChangeGameStateHandler;
    }

    private void Unsubscribe()
    {
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
        MainController.Instance.OnFixedUpdateEvent -= OnFixedUpdateHandler;
        MainController.Instance.GameController.OnChangeGameStateEvent -= OnChangeGameStateHandler;
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

    private void OnChangeGameStateHandler(GameState gameState)
    {
        if (gameState != GameState.Play)
        {
            Destroy(gameObject);
        }
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
            collisionPosition = other.ClosestPoint(transform.position);
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
        OnDestroyBulletEvent?.Invoke(collisionPosition);
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