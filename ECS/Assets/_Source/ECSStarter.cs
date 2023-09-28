using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class ECSStarter : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _objectCount;
    [SerializeField] private float _time;
    [SerializeField] private float _range;

    private EntityManager _entityManager;

    private void Awake()
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

        Entity prefabUnity = GameObjectConversionUtility.ConvertGameObjectHierarchy(_prefab, settings);

        for (int i = 0; i < _objectCount; i++)
        {
            Entity prefabInstance = _entityManager.Instantiate(prefabUnity);
            float3 positionVector = new float3(Random.Range(-100, 100),.5f,Random.Range(-100, 100));
            Vector3 position = transform.TransformPoint(positionVector);

            _entityManager.SetComponentData(prefabInstance, new Translation { Value = position });
            _entityManager.AddComponentData(prefabInstance, new PrefabData { Time = _time, TimeLeft = _time, TimeDelta = Time.fixedDeltaTime, Number = Random.Range(1,100), Range = _range});
        }
    }
}