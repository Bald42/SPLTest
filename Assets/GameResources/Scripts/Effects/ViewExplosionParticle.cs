using UnityEngine;

[RequireComponent(typeof(ExplosionParticlesPool))]
public class ViewExplosionParticle : MonoBehaviour
{
    private ExplosionParticlesPool explosionParticlesPool = null;

    #region Subscribe 

    private void Subscribe()
    {
        Bullet.OnDestroyBulletEvent += OnDestroyBulletHandler;
        MainController.Instance.OnDestroyEvent += OnDestroyHandler;
    }

    private void Unsubscribe()
    {
        Bullet.OnDestroyBulletEvent -= OnDestroyBulletHandler;
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void OnDestroyHandler()
    {
        Unsubscribe();
    }

    private void OnDestroyBulletHandler(Vector3 pointPosition)
    {
        explosionParticlesPool.OnSpawnParticle(pointPosition);
    }

    #endregion
    public void Init()
    {
        explosionParticlesPool = GetComponent<ExplosionParticlesPool>();
        Subscribe();
    }
}