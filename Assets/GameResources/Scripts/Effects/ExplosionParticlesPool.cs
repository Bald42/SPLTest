using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExplosionParticlesPool : MonoBehaviour
{
    [SerializeField] private ExplosionParticle prefabBullet = null;
    [SerializeField] private Transform parent = null;
    private List<ExplosionParticle> explosionParticles = new List<ExplosionParticle>();

    public void OnSpawnParticle(Vector3 startPosition)
    {
        ExplosionParticle newExplosionParticle = GetFreeExplosionParticle;
        if (newExplosionParticle == null)
        {
            newExplosionParticle = Instantiate(prefabBullet, startPosition, Quaternion.identity, parent);
            explosionParticles.Add(newExplosionParticle);
        }
        newExplosionParticle.Init(startPosition);
    }

    private ExplosionParticle GetFreeExplosionParticle
    {
        get
        {
            return explosionParticles.Where(x => !x.IsActive).FirstOrDefault();
        }
    }
}