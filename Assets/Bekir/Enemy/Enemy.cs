using UnityEngine;
using TMPro;
using System;
using DG.Tweening;
using Random = UnityEngine.Random;
public class Enemy : MonoBehaviour, IDamage, IHoldObject, IEnemy
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _nameTMP;
    [SerializeField] private TMP_Text _healthCount;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private AttackHandler _attackHandler;
    private bool _moving;
    private float _healthCounter;
    private EnemySCB _enemySCB;
    public event Action OnDie, OnTakeHit;
    private GameManager _gameManager;
    public int MyIndex;
    private Transform _conflictArea;
    private Holder _enemyHolder;
    private Holder _playerHolder;

    public GameObject RootGameObject { get => gameObject; set => value = gameObject; }

    public void Init(EnemySCB enemySCB, GameManager gameManager)
    {
        _gameManager = gameManager;
        _enemyHolder = _gameManager.Enemy_Holder;
        _enemySCB = enemySCB;
        _healthCounter = enemySCB.Health;
        _conflictArea = gameManager.ConflictArea;
        _attackHandler = gameManager.C_AttackHandler;
        _playerHolder = _gameManager.Player_Holder;
        RootGameObject = gameObject;
        ChangeVisual();
        MyIndex = _enemyHolder.GetIndex(this);
        print(MyIndex);
        if ((MyIndex == 1 || MyIndex == 0) && _enemySCB.EnemyTypes == EnemyTypes.Archer)
        {
            _attackHandler.AttackList.Add(this);
        }
        else if (MyIndex == 0 && _enemySCB.EnemyTypes == EnemyTypes.Melee)
        {
            _attackHandler.AttackList.Add(this);
        }

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
        //para düsürme;
        OnDie?.Invoke();
        OnMove();
        Destroy(gameObject);
    }
    private void ChangeVisual()
    {
        _spriteRenderer.sprite = _enemySCB.EnemySprite;
        _nameTMP.text = _enemySCB.EnemyName;
    }

    public void OnMove()
    {
        _enemyHolder.SetEmpty(MyIndex);
    }
    public void AttackAnimation()
    {
        IDamage playerIDamage = _playerHolder.GetFirstOne().GetComponent<IDamage>();
        if (_spriteRenderer == null) return;
        if (playerIDamage != null)
        {
            if (_enemySCB.EnemyTypes == EnemyTypes.Melee)
            {
                _spriteRenderer.transform.DOMove(_gameManager.ConflictArea.position, _attackSpeed).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    playerIDamage.Damage(_enemySCB.AttackAmount);
                    _spriteRenderer.transform.DOMove(_enemyHolder.GetTransform(MyIndex).position, _attackSpeed).SetEase(Ease.OutBack);
                });
            }
            else if (_enemySCB.EnemyTypes == EnemyTypes.Archer)
            {
                _spriteRenderer.transform.DOPunchPosition(Vector3.left, _attackSpeed).SetEase(Ease.OutBack);
                playerIDamage.Damage(_enemySCB.AttackAmount);
            }
        }
    }
    void OnDestroy()
    {
        DOTween.Kill(_spriteRenderer.transform);
    }
}