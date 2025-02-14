using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<EnemySCB> _enemytypes = new();
    [SerializeField] private Holder _holder;
    [SerializeField] private GameManager _gameManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            int randNumber = Random.Range(0, _enemytypes.Count);
            SpawnAnEnemy(_enemytypes[Random.Range(0, _enemytypes.Count)]);
        }
    }
    public void SpawnAnEnemy(EnemySCB enemy)
    {
        if (_holder.IsAllBusy()) return;
        Enemy tempEnemy = Instantiate(_enemyPrefab);
        tempEnemy.Init(enemy, _gameManager);
        _holder.Add(tempEnemy.gameObject);
    }
}