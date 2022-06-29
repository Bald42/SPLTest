using static Enums;
using UnityEngine;

public class BaseShootController : MonoBehaviour
{
    [SerializeField] protected Transform shotPoint = null;
    protected BulletsPool bulletsPool = null;
    protected GameTag gameTag = null;
    protected Tag targetTag = Tag.Null;

    protected virtual void Init(GameTag gameTag, BulletsPool bulletsPool)
    {
        this.gameTag = gameTag;
        this.bulletsPool = bulletsPool;
    }
}