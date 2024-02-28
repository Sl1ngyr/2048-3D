using Components;
using Factories;
using Handlers;
using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CubeSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private UiPointsCalculate _uiPointsCalculate;
        [SerializeField] private UiCompletionGame _uiCompletionGame;
        [SerializeField] private MotionHandler _motionHandler;
            
        public override void InstallBindings()
        {
            Container.Bind<CubeFactory>().AsSingle();
            Container.BindFactory<CubeComponent, CubeComponent.Factory>().FromComponentInNewPrefab(_prefab);
            Container.Bind<CubeSpawner>().FromInstance(_cubeSpawner).AsSingle();
            Container.Bind<UiPointsCalculate>().FromInstance(_uiPointsCalculate);
            Container.Bind<UiCompletionGame>().FromInstance(_uiCompletionGame);
            Container.Bind<MotionHandler>().FromInstance(_motionHandler);
            
        }
    }
}