using UnityEngine;
using TMPro;
using System;

public class Enemy : MonoBehaviour, IDamage, IHoldObject
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _nameTMP;
    [SerializeField] private TMP_Text _healthCount;

    private float _healthCounter;
    private EnemySCB _enemySCB;
    public event Action OnDie, OnTakeHit;

    public void Init(EnemySCB enemySCB)
    {
        _enemySCB = enemySCB;
        _healthCounter = enemySCB.Health;
        ChangeVisual();
    }
    public void Damage(float damage)
    {
        if (_healthCounter <= damage)
        {
            Die();
            return;
        }
        _healthCounter -= damage;
        _healthCount.text = _healthCounter.ToString();
        OnTakeHit?.Invoke();
    }
    public void Die()
    {
        Destroy(gameObject);
        //para düsürme;
        OnDie?.Invoke();
    }
    private void ChangeVisual()
    {
        _spriteRenderer.sprite = _enemySCB.EnemySprite;
        _nameTMP.text = _enemySCB.EnemyName;
    }
}