using UnityEngine;

public interface IEnemy : IDamage
{
    public void Init(EnemySCB enemySCB, GameManager gameManager);
}