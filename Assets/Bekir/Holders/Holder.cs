using System;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour, IHolder
{
    public List<IHoldObject> _gridsToMove = new();
    [SerializeField] private List<Transform> _points;
    public Dictionary<int, IHoldObject> _holdObjects = new();
    public event Action OnFullEmpty, OnOneEmpty;
    public List<GameObject> HolderGameObjects;

    private int _index = 0;
    public Transform GetTransform(int index) => _points[index];
    /// <summary>
    /// adding 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="holdObject"></param>
    public void Add(GameObject spawnedObject)
    {
        if (_index == 5) return;

        spawnedObject.transform.position = _points[_index].position;
        _holdObjects.Add(_index, spawnedObject.GetComponent<IHoldObject>());
        HolderGameObjects.Add(spawnedObject);
        _index++;
    }

    /// <summary>
    /// eğer dictionary boş değilse true döndürür
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool CheckEmpty(int index)
    {
        return _holdObjects[index] != null;
    }
    public int GetIndex(IHoldObject holdObject)
    {
        foreach (KeyValuePair<int, IHoldObject> holdobject in _holdObjects)
        {
            if (holdObject == holdobject.Value)
            {
                return holdobject.Key;
            }
        }
        return 0;
    }

    public bool IsAllBusy()
    {
        if (_holdObjects.Count == 0) return false;

        if (_holdObjects.Count == 5)
        {
            foreach (var item in _holdObjects)
            {
                if (item.Value == null) return false;
            }
        }
        else
        {
            return false;
        }

        return true;
    }

    public void SetEmpty(int index)
    {
        if (!_holdObjects.ContainsKey(index)) return;

        if (_holdObjects.Count == 1)
        {
            _holdObjects.Remove(index);
            OnFullEmpty?.Invoke();
            return;
        }
        _holdObjects.Remove(index);
        OnOneEmpty?.Invoke();
    }

    public GameObject GetFirstOne()
    {
        return HolderGameObjects[0];
    }

    public IHoldObject GetObject(int index)
    {
        return _holdObjects[index];
    }
}