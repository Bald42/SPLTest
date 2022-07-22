using UnityEngine;
using Zenject;

public class BulletsPoolInstaller : MonoInstaller
{
    [SerializeField] private BulletsPool bulletsPool = null;
    public override void InstallBindings()
    {
        Container.Bind<BulletsPool>().FromInstance(bulletsPool).AsSingle().NonLazy();
    }
}