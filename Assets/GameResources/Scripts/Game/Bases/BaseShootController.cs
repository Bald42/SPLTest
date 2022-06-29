using static Enums;
using UnityEngine;

public class BaseShootController : MonoBehaviour
{
    [SerializeField] protected Transform shotPoint = null;
    [SerializeField] protected Bullet prefabBullet = null;
    protected GameTag gameTag = null;
    protected Tag targetTag = Tag.Null;

    protected virtual void Init(GameTag gameTag)
    {
        this.gameTag = gameTag;
    }
}