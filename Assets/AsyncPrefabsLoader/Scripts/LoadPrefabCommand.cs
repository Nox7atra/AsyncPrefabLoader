using System;
using UnityEngine;

[Serializable]
public class LoadPrefabCommand<T> where T : Component
{
  public T Prefab;
  public Vector3 Position;
  public Quaternion Rotation;
}
