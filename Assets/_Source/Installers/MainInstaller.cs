using Game;
using Pool;
using Service;
using Services;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private float _roadLength;
    [SerializeField] private int _tileCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private Vector3 _distance;
    [SerializeField] private TextMeshProUGUI _startText;

    public override void InstallBindings()
    {
        Container.Bind<List<GameObject>>().FromInstance(_prefabs).NonLazy();
        Container.Bind<float>().FromInstance(_roadLength).NonLazy();
        Container.Bind<int>().FromInstance(_tileCount).NonLazy();
        Container.Bind<bool>().FromInstance(_autoExpand).NonLazy();
        Container.Bind<Vector3>().FromInstance(_distance).NonLazy();
        Container.Bind<TextMeshProUGUI>().FromInstance(_startText).NonLazy();

        Container.Bind<RandomService>().AsSingle().NonLazy();
        Container.Bind<TilePool>().AsSingle().NonLazy();
        Container.Bind<LayerService>().AsSingle().NonLazy();
        Container.Bind<GameController>().AsSingle().NonLazy();
    }
}