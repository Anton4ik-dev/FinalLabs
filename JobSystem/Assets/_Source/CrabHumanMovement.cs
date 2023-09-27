using System.Collections;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class CrabHumanMovement : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private int _objectCount;
    [SerializeField] private float _waitSeconds;

    private Transform[] _objectsOnScene;
    private TransformAccessArray _transformOnScene;

    private void Start()
    {
        _objectsOnScene = new Transform[_objectCount];
        for (int i = 0; i < _objectCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-100, 100), 5.5f, Random.Range(-100, 100));
            GameObject instance = Instantiate(_prefab, position, Quaternion.identity);
            _objectsOnScene[i] = instance.transform;
        }
        _transformOnScene = new TransformAccessArray(_objectsOnScene);
        StartCoroutine(DoLogs());
    }

    private void Update()
    {
        MovementJob movementJob = new MovementJob()
        {
            Speed = _speed, 
        };
        JobHandle movementJobHandel = movementJob.Schedule(_transformOnScene);
        movementJobHandel.Complete();
    }

    private void OnDestroy()
    {
        _transformOnScene.Dispose();
    }

    private IEnumerator DoLogs()
    {
        while(true)
        {
            yield return new WaitForSeconds(_waitSeconds);

            NativeArray<int> numbers = new NativeArray<int>(_objectsOnScene.Length, Allocator.Persistent);
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Random.Range(1, 100);

            LogJob logJob = new LogJob()
            {
                Numbers = numbers
            };

            JobHandle logJobHandel = logJob.Schedule();
            logJobHandel.Complete();

            numbers.Dispose();
        }
    }
}