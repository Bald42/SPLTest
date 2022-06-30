using UnityEngine;

public class ExplosionParticle : BasePool
{
    private ParticleSystem particleSystem = null;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Init(Vector3 startPosition)
    {
        dieDelay = 1f;
        transform.position = startPosition;
        ChangeActive(true);
        particleSystem.Play();
    }
}