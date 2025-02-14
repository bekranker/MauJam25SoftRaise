using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Pack", menuName = "SCBs/Enemy Pack")]
public class EnemyPackSCB : ScriptableObject
{
    public List<EnemySCB> Pack = new();
}