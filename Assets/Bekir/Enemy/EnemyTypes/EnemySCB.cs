using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SCBs/enemy", order = 1)]
public class EnemySCB : ScriptableObject
{
    public float Health;
    public Sprite EnemySprite;
    public string EnemyName;
    public float AttackAmount;
}