using static Enums;
using UnityEngine;

public class PlayerShoot : BaseShootController, IShot
{
    [SerializeField] private LayerMask layerMask = default;
    private Camera camera = null;
    private PlayerInput playerInput = null;
    private RaycastHit hit = default;
    private Vector3 diractionShoot = default;

    #region Subscribe 

    private void Subscribe()
    {
        MainController.Instance.OnDestroyEvent += OnDestroyHandler;
        MainController.Instance.OnUpdateEvent += OnUpdateHandler;
    }

    private void Unsubscribe()
    {
        MainController.Instance.OnDestroyEvent -= OnDestroyHandler;
        MainController.Instance.OnUpdateEvent -= OnUpdateHandler;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void OnDestroyHandler()
    {
        Unsubscribe();
    }

    private void OnUpdateHandler()
    {
        RefreshUpdate();
    }

    #endregion

    public void Init(GameTag gameTag, PlayerInput playerInput, Camera camera, BulletsPool bulletsPool)
    {
        targetTag = Tag.Enemy;
        this.playerInput = playerInput;
        this.camera = camera;
        base.Init(gameTag, bulletsPool);
        Subscribe();
    }

    public void OnShot(Vector3 direction)
    {
        bulletsPool.OnSpawnBullet(shotPoint.position, direction, targetTag, gameTag.MyTag);
    }

    private void RefreshUpdate()
    {
        if (playerInput.GetFireInput())
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, float.MaxValue, layerMask))
            {
                diractionShoot = hit.point;
            }
            else
            {
                diractionShoot = camera.transform.forward * 100000f;
            }
            OnShot(diractionShoot);
        }
    }
}