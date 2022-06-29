using System.Collections;
using static Enums;
using UnityEngine;

public class EnemyShoot : BaseShootController, IShot
{
    [SerializeField] private float speed = 1f;
    private Transform player = null;

    public void Init(GameTag gameTag, Transform player)
    {
        base.Init(gameTag);
        this.player = player;
        targetTag = Tag.Player;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed + Random.RandomRange(-0.2f, 0.2f));
            OnShot(player.position);
        }
    }

    public void OnShot(Vector3 direction)
    {
        var newBullet = Instantiate(prefabBullet);
        newBullet.Init(shotPoint.position, direction, targetTag, gameTag.MyTag);
    }
}
