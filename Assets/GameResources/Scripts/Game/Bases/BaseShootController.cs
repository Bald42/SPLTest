using static Enums;
using UnityEngine;
using Zenject;

public class BaseShootController : MonoBehaviour
{
    [SerializeField] protected Transform shotPoint = null;
    [Inject] protected BulletsPool bulletsPool = null;

    protected GameTag gameTag = null;
    protected Tag targetTag = Tag.Null;

    protected virtual void Init(GameTag gameTag)
    {
        this.gameTag = gameTag;
    }
}