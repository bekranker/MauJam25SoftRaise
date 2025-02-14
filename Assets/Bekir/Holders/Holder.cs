using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour, IHolder
{
    public List<IHoldObject> _gridsToMove = new();
    [SerializeField] private List<Transform> _points;
    public Dictionary<int, IHoldObject> _holdObjects = new();
    private int _index = 0;
    private IHoldObject _holdObject;
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
    public int SetIndex(int index)
    {
        _index = index;
        return _index;
    }
    public IHoldObject SetNPC(IHoldObject holdObject)
    {
        _holdObject = holdObject;
        return _holdObject;
    }
}