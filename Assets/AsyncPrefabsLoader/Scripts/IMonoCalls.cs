using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonoCalls
{
    void StartCoroutineProxy(IEnumerator coroutine);
    T InstantiateProxy<T>(T obj) where T : Component; 
}
