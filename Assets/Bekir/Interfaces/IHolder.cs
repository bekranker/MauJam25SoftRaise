using UnityEngine;

public interface IHolder
{

    public void Add(GameObject spawnedObject);
    public bool CheckEmpty(int index);
    public int GetIndex(IHoldObject holdObject);
    public bool IsAllBusy();
}