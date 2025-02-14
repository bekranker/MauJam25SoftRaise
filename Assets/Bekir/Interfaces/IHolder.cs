using UnityEngine;

public interface IHolder
{
    public IHoldObject SetNPC(IHoldObject holdObject);
    public bool CheckEmpty();
    public int SetIndex(int index);
    public int GetIndex();
}