using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncPrefabLoader<T> where T : Component
{
    public event Action<float> OnProgress; 
    public event Action<T> OnPrefabInstantiated; 
    private Queue<LoadPrefabCommand<T>> _commands;
    private int _loadPerFrame;
    private int _commandsCount;
    public void StartLoad(IMonoCalls monoCalls, Queue<LoadPrefabCommand<T>> commands, int loadPerFrame)
    {
        _commands = commands;
        _commandsCount = _commands.Count;
        _loadPerFrame = loadPerFrame;
        monoCalls.StartCoroutineProxy(LoadAsync(monoCalls));
    }

    private IEnumerator LoadAsync(IMonoCalls monoCalls)
    {
        int loaded = 0;
        while (loaded < _commandsCount)
        {
            yield return null;
            for (int i = 0; i < _loadPerFrame; i++)
            {
                var command = _commands.Dequeue();
                var obj = monoCalls.InstantiateProxy(command.Prefab);
                obj.transform.position = command.Position;
                obj.transform.rotation = command.Rotation;
                OnPrefabInstantiated?.Invoke(obj);
                if (_commands.Count == 0)
                {
                    break;
                }
            }
            loaded += _loadPerFrame;
            OnProgress?.Invoke((float) loaded / _commandsCount);
        }
        OnProgress?.Invoke( 1);
    }
}
