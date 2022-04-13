using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DemoCommandGenerator : MonoBehaviour, IMonoCalls
{
    [SerializeField] private DemoObject _Prefab;
    [SerializeField] private int _InstantiatePerFrame = 100;
    [SerializeField] private int _InstantiateCount = 1000;
    [SerializeField] private DemoProgressUI _progressUI;
    private Queue<LoadPrefabCommand<DemoObject>> _commands = new Queue<LoadPrefabCommand<DemoObject>>();
    private void Start()
    {
        for (int i = 0; i < _InstantiateCount; i++)
        {
            var command = new LoadPrefabCommand<DemoObject>();
            command.Prefab = _Prefab;
            command.Position = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f),
                Random.Range(-100f, 100f));
            _commands.Enqueue(command);
        }

        var loader = new AsyncPrefabLoader<DemoObject>();
        loader.StartLoad(this, _commands, _InstantiatePerFrame);
        loader.OnProgress += progress =>
        {
            if (_progressUI != null)
            {
                _progressUI.SetProgress(progress);
            }
        };
    }

    public void StartCoroutineProxy(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public T InstantiateProxy<T>(T obj) where T : Component
    {
        return Instantiate(obj);
    }

}
