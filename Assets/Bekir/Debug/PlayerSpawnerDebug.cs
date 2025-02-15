using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawnerDebug : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Holder _playerHolder;
    [SerializeField] private GameManager _gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerTypes[] playertypes = (PlayerTypes[])Enum.GetValues(typeof(PlayerTypes));
            SpawnPlayer(playertypes[Random.Range(0, playertypes.Length - 1)]);
        }
    }
    public void SpawnPlayer(PlayerTypes randomPlayerType)
    {
        if (_playerHolder.IsAllBusy()) return;
        Player tempPlayer = Instantiate(_playerPrefab);
        _playerHolder.Add(tempPlayer.gameObject);
        tempPlayer.Init(null, _gameManager);
    }
}