using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Day Day = Day.Morning;
    [SerializeField] private List<WaveType> _waveTypes = new();
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _waveTMP;
    [SerializeField] private List<EnemyPackSCB> _enemyPacks = new();
    [SerializeField] private AttackHandler _attackHandler;
    private int _waveIndex;
    private int _count;

    public void ChangeDayState(Day day)
    {
        Day = day;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        _count = _waveTypes[_waveIndex].MaxEnemyCount;
        _waveTMP.text = _waveTypes[_waveIndex].WaveName;

        WaveInit();
    }
    public void NextWave()
    {
        if (_waveIndex > _waveTypes.Count) return;
        _waveIndex++;
        _count = _waveTypes[_waveIndex].MaxEnemyCount;
        _waveTMP.text = _waveTypes[_waveIndex].WaveName;
    }
    public void WaveInit()
    {
        List<EnemyPackSCB> temp = GetEnemies();

        for (int i = 0; i < temp.Count; i++)
        {
            for (int x = 0; x < temp[i].Pack.Count; x++)
            {
                _spawner.SpawnAnEnemy(temp[i].Pack[x]);
            }
        }
        _attackHandler.Init();
    }
    /// <summary>
    /// Recursive
    /// </summary>
    /// <returns></returns>
    private List<EnemyPackSCB> GetEnemies()
    {
        if (_count <= 0)
        {
            return new List<EnemyPackSCB>();
        }
        List<EnemyPackSCB> recursiveTotalPack = new();
        int randCountOfEnemyForAPack = 0;
        randCountOfEnemyForAPack = Random.Range(1, _count + 1);
        recursiveTotalPack.Add(_enemyPacks[randCountOfEnemyForAPack]);
        _count -= randCountOfEnemyForAPack;
        if (_count > 0)
        {
            recursiveTotalPack.AddRange(GetEnemies());
        }
        return recursiveTotalPack;
    }
}
