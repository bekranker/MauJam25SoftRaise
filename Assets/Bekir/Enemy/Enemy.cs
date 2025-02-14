using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour, IDamage
{
    [SerializeField] private float _health;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _nameTMP;
    private float _healthCounter;
    private EnemySCB _enemySCB;
    public void Init(EnemySCB enemySCB)
    {
        _enemySCB = enemySCB;
        _healthCounter = _health;
    }
    public void Damage(float damage)
    {
        if (_healthCounter <= damage)
        {
            Die();
            return;
        }
    }
    public void Die()
    {

    }
    private void ChangeVisual()
    {
        _spriteRenderer.sprite = _enemySCB.EnemySprite;
        _nameTMP.text = _enemySCB.EnemyName;
    }
}