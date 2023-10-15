using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class ECSStarter : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _objectCount;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private float _changeHealth;

    private EntityManager _entityManager;

    private void Awake()
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        GameObjectConversionSettings settings = GameObjectConversionSettings
            .FromWorld(World.DefaultGameObjectInjectionWorld, null);

        Entity prefabUnity = GameObjectConversionUtility
            .ConvertGameObjectHierarchy(_prefab, settings);

        for (int i = 0; i < _objectCount; i++)
        {
            Entity prefabInstance = _entityManager.Instantiate(prefabUnity);
            float3 positionVector = new float3(Random.Range(-100, 100),.5f,Random.Range(-100, 100));
            Vector3 position = transform.TransformPoint(positionVector);

            _entityManager.SetComponentData(prefabInstance, new Translation { Value = position });
            _entityManager.AddComponentData(prefabInstance, new PrefabWarrior { Speed = _speed, Health = _health});
            _entityManager.AddComponentData(prefabInstance, new PrefabInput { ChangeSpeed = _changeSpeed, ChangeHealth = _changeHealth});
        }
    }
}