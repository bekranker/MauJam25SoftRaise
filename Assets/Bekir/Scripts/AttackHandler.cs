using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Holder _enemyHolder;
    [SerializeField] private Holder _playerHolder;
    [SerializeField] private float _timer;


    public List<IHoldObject> AttackList = new();


    public void Init()
    {
        StartCoroutine(AttackIE());
    }
    private IEnumerator AttackIE()
    {
        yield return new WaitForSeconds(_timer);
        AttackList?.ForEach((item) =>
        {
            item.AttackAnimation();
        });
        Init();
    }
}