using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Holder : MonoBehaviour, IHolder
{


    [ShowInInspector] // Odin ile Dictionary'yi Inspector'da göster
    public Dictionary<int, IHoldObject> _gridsToMove = new();

    private int _index = 0;
    private IHoldObject _holdObject;
    public bool CheckEmpty()
    {
        return _holdObject != null;
    }

    public int GetIndex()
    {
        return _index;
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