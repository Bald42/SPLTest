using static Enums;
using UnityEngine;

public class BaseTakeDamage : MonoBehaviour
{
    private GameTag gameTag = null;

    protected void Init(GameTag gameTag)
    {
        this.gameTag = gameTag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            GameTag bulletGameTag = other.gameObject.GetComponentInChildren<GameTag>();
            if (bulletGameTag != null && bulletGameTag.MyTag == Tag.Bullet)
            {
                CheckDamage(other);
            }
        }
    }

    private void CheckDamage(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponentInChildren<Bullet>();
        if (bullet != null && bullet.TargetTag == gameTag.MyTag)
        {
            OnTakeDamage(other);
            bullet.OnDeactiveAtCollision();
        }
    }

    protected virtual void OnTakeDamage(Collider other)
    {

    }
}