using System;
using UnityEngine;

public interface IHoldObject
{
    public GameObject RootGameObject { get; set; }
    void OnMove();
    void AttackAnimation();

}
