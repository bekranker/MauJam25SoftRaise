using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour, IHoldObject, IDamage, IPlayer
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _health;
    private float _healthCounter;
    [SerializeField] private float _attackSpeed;
    private Transform _conflictArea;

    private GameManager _gameManager;
    private AttackHandler _attackHandler;
    private Holder _playerHolder;
    private Holder _enemyHolder;
    private int _myIndex;
    public PlayerTypes _playerType;
    public int TempAttackAmount;
    void Start()
    {
        _healthCounter = _health;
        Init(null, FindAnyObjectByType<GameManager>());
    }
    public void Init(EnemySCB enemySCB, GameManager gameManager)
    {
        _gameManager = gameManager;
        _conflictArea = gameManager.ConflictArea;
        _playerHolder = gameManager.Player_Holder;
        _enemyHolder = gameManager.Enemy_Holder;
        _myIndex = _playerHolder.GetIndex(this);
        _attackHandler = _gameManager.C_AttackHandler;

        if (_myIndex == 0)
        {
            _attackHandler.AttackList.Add(this);
        }
        else if (_myIndex == 1 && _playerType == PlayerTypes.Archer)
        {
            _attackHandler.AttackList.Add(this);
        }
    }
    public void Damage(float damage)
    {
        if (_health < damage) return;

        _healthCounter -= damage;
    }
    public void AttackAnimation()
    {
        DOTween.Kill(transform);
        if (_playerType == PlayerTypes.Melee)
        {
            _spriteRenderer.transform.DOMove(_gameManager.ConflictArea.position, _attackSpeed).SetEase(Ease.OutBack).OnComplete(() =>
            {
                _enemyHolder.HolderGameObjects[0].GetComponent<IDamage>().Damage(TempAttackAmount);
                _spriteRenderer.transform.DOMove(_playerHolder.GetTransform(_myIndex).position, _attackSpeed).SetEase(Ease.OutBack);
            });
        }
        else if (_playerType == PlayerTypes.Archer)
        {
            _enemyHolder.HolderGameObjects[0].GetComponent<IDamage>().Damage(TempAttackAmount);
            _spriteRenderer.transform.DOPunchPosition(Vector3.right, _attackSpeed).SetEase(Ease.OutBack);
        }
    }

    public void Die()
    {
    }

    public void OnMove()
    {
    }

}