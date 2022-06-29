using System.Collections.Generic;
using static Enums;
using UnityEngine;
using System.Linq;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet prefabBullet = null;
    [SerializeField] private Transform parent = null;
    private List<Bullet> bullets = new List<Bullet>();

    public void OnSpawnBullet(Vector3 startPosition,
                              Vector3 targetPosition,
                              Tag targetTag,
                              Tag shooterTag)
    {
        Bullet newBullet = GetFreeBullet;
        if (newBullet == null)
        {
            newBullet = Instantiate(prefabBullet, startPosition, Quaternion.identity, parent);
            bullets.Add(newBullet);
        }
        newBullet.Init(startPosition, targetPosition, targetTag, shooterTag);
    }
    private Bullet GetFreeBullet
    {
        get
        {
            return bullets.Where(x => !x.IsActive).FirstOrDefault();
        }
    }
}