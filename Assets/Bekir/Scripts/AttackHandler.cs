using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Holder _enemyHolder;
    [SerializeField] private Holder _playerHolder;
    [SerializeField] private float _timer;

    private float _timeCounter;
    public void Init()
    {
        _timeCounter = _timer;
        StartCoroutine(AttackIE());
    }


    private IEnumerator AttackIE()
    {

        yield return new WaitForSeconds(_timer);
    }
}