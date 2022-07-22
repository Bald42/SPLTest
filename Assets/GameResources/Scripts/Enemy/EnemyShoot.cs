using System.Collections;
using static Enums;
using UnityEngine;
using Zenject;

public class EnemyShoot : BaseShootController, IShot
{
    [SerializeField] private float speed = 1f;
    [Inject] private PlayerController playerController = null;

    private bool CanShoot
    {
        get
        {
            return MainController.Instance.GameController.GameState == GameState.Play;
        }
    }

    public void Init(GameTag gameTag)
    {
        base.Init(gameTag);
        targetTag = Tag.Player;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed + Random.RandomRange(-0.2f, 0.2f));
            if (CanShoot)
            {
                OnShot(playerController.transform.position);
            }
        }
    }

    public void OnShot(Vector3 direction)
    {
        bulletsPool.OnSpawnBullet(shotPoint.position, direction, targetTag, gameTag.MyTag);
    }
}