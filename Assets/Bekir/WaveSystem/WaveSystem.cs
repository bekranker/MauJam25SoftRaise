using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Day Day = Day.Morning;
    [SerializeField] private List<WaveType> _waveTypes = new();
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _waveTMP;
    [SerializeField] private List<EnemyPackSCB> _enemyPacks = new();
    private int _waveIndex, _packIndex, _enemyIndex;
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
        _packIndex = 0;
    }
    public void WaveInit()
    {
        List<EnemyPackSCB> temp = GetEnemies();

        for (int i = 0; i < temp[_packIndex].Pack.Count; i++)
        {
            _spawner.SpawnAnEnemy(temp[_packIndex].Pack[i]);
        }
        _packIndex++;
    }
    /// <summary>
    /// Recursive
    /// </summary>
    /// <returns></returns>
    private List<EnemyPackSCB> GetEnemies()
    {
        if (_count <= 0) return null;
        List<EnemyPackSCB> recursiveTotalPack = new();
        int randCountOfEnemyForAPack = Random.Range(0, 5);
        recursiveTotalPack.Add(_enemyPacks[randCountOfEnemyForAPack]);
        _count -= randCountOfEnemyForAPack;
        Debug.Log(" before if > 0" + _count);
        if (_count > 0)
        {
            Debug.Log("if > 0" + _count);
            recursiveTotalPack.AddRange(GetEnemies());
        }
        return recursiveTotalPack;
    }
}
public enum Day
{
    Morning,
    Night
}