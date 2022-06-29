using UnityEngine;

public class PlayerTakeDamage : BaseTakeDamage, IHit
{
    private PlayerMove playerMove = null;
    private Vector3 directionDamage = default;

    public void Init(GameTag gameTag, PlayerMove playerMove)
    {
        this.playerMove = playerMove;
        base.Init(gameTag);
    }

    public void OnHit()
    {
        playerMove.TakeDamage(directionDamage);
    }

    protected override void OnTakeDamage(Collider other)
    {
        directionDamage = other.transform.forward;
        OnHit();
    }
}