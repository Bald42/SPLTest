using UnityEngine;

public class PlayerTakeDamage : BaseTakeDamage, IHit
{
    [SerializeField] private PlayerMove playerMove = null;
    private Vector3 directionDamage = default;

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