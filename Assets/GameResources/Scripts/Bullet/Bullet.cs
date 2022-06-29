using System.Collections;
using static Enums;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 targetPosition = default;
    private Vector3 moveVector = default;
    private float speed = 10f;
    private float dieDelay = 4f;
    private Tag targetTag = Tag.Null;
    private Tag shooterTag = Tag.Null;

    public Tag TargetTag
    {
        get
        {
            return targetTag;
        }
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
        transform.LookAt(targetPosition);
        StartCoroutine(DelayDestroy());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(dieDelay);
        OnDeactive();
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
        OnDeactive();
    }

    private void OnDeactive()
    {
        Destroy(this.gameObject);
    }
}