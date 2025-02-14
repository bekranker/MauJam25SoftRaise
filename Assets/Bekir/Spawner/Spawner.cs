using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<EnemySCB> _enemytypes = new();
    [SerializeField] private Holder _holder;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SpawnAnEnemy();
        }
    }
    public void SpawnAnEnemy()
    {
        if (_holder.IsAllBusy()) return;
        Enemy tempEnemy = Instantiate(_enemyPrefab);
        tempEnemy.Init(_enemytypes[Random.Range(0, _enemytypes.Count)]);
        _holder.Add(tempEnemy.gameObject);
    }
}