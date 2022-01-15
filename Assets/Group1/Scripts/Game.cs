using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private EnemiesCounter _enemiesCounter;

    private void OnEnable()
    {
        _enemiesCounter.Changed += TryOverGame;
    }

    private void OnDisable()
    {
        _enemiesCounter.Changed += TryOverGame;
    }

    private void TryOverGame(int enemiesCount)
    {
        if (enemiesCount == 0)
        {
            OverGame();
        }
    }

    public void OverGame()
    {
        _endScreen.SetActive(true);
        _player.enabled = false;
    }
}
