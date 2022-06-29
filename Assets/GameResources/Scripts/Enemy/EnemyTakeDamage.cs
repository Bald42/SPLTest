using UnityEngine;

public class EnemyTakeDamage : BaseTakeDamage, IHit
{
    public void Init(GameTag gameTag)
    {
        base.Init(gameTag);
    }

    public void OnHit()
    {
        Destroy(this.gameObject);
    }

    protected override void OnTakeDamage(Collider other)
    {
        OnHit();
    }
}