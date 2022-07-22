using UnityEngine;
using Zenject;

public class MainCameraInstaller : MonoInstaller
{
    [SerializeField] private Camera mainCamera = null;
    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(mainCamera).AsSingle().NonLazy();
    }
}