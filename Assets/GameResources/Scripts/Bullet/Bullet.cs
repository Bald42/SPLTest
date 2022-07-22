using static Enums;
using UnityEngine;
using System;

public class Bullet : BasePool
{
    public static Action<Vector3> OnDestroyBulletEvent = null;
    private Vector3 targetPosition = default;
    private float speed = 10f;
    private Tag targetTag = Tag.Null;
    private Tag shooterTag = Tag.Null;
    private Rigidbody rigidbody = null;

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
        MainController.Instance.GameController.OnChangeGameStateEvent += OnChangeGameStateHandler;
    }

    private void Unsubscribe()
    {
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
        MainController.Instance.GameController.OnChangeGameStateEvent -= OnChangeGameStateHandler;
    }

    private void OnDestroyHandler()
    {
        OnDestroyBulletEvent = null;
        Unsubscribe();
    }

    private void OnChangeGameStateHandler(GameState gameState)
    {
        if (gameState != GameState.Play)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    private void Awake()
    {
        Caching();
        Subscribe();
    }

    private void Caching()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 startPosition,
                     Vector3 targetPosition,
                     Tag targetTag,
                     Tag shooterTag)
    {
        transform.position = startPosition;
        this.targetPosition = targetPosition;
        this.targetTag = targetTag;
        this.shooterTag = shooterTag;
        AddForce();
        ChangeActive(true);
    }

    private void AddForce()
    {
        transform.LookAt(targetPosition);
        rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
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

    public void OnDeactiveAtCollision()
    {
        ChangeActive(false);
        OnDestroyBulletEvent?.Invoke(transform.position);
    }
}