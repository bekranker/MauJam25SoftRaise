using UnityEngine;

public class PlayerSpawnerDebug : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Holder _playerHolder;
    [SerializeField] private GameManager _gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnPlayer();
        }
    }
    public void SpawnPlayer()
    {
        if (_playerHolder.IsAllBusy()) return;
        Player tempPlayer = Instantiate(_playerPrefab);
        _playerHolder.Add(tempPlayer.gameObject);
        tempPlayer.Init(null, _gameManager);
    }
}