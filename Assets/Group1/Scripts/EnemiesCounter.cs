using UnityEngine;
using UnityEngine.Events;

public class EnemiesCounter : MonoBehaviour
{
    private Enemy[] _enemies;
    private int _count;

    public event UnityAction<int> Changed;

    private void Awake()
    {
        _enemies = GetComponentsInChildren<Enemy>();
        _count = _enemies.Length;
    }

    private void OnEnable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Destroyed += Decrease;
        }
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Destroyed -= Decrease;
        }
    }

    private void Decrease()
    {
        _count--;
        Changed?.Invoke(_count);
    }
}
