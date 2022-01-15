using System.Collections;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private int _divisorOfSlowDown;
    [SerializeField] private float _delayToSlowDown;

    private Coroutine _currentCoroutine;

    public float Value => _value;

    private void Start()
    {
        _currentCoroutine = StartCoroutine(DelaySlowDown(_delayToSlowDown, _divisorOfSlowDown));
    }

    private IEnumerator DelaySlowDown(float delay, int divisor)
    {
        float time = 0f;

        while (time < delay)
        {
            time += Time.deltaTime;
            yield return null;
        }

        if (time >= delay)
        {
            SlowDown(divisor);
        }
    }

    private void SlowDown(int divisor)
    {
        _value /= divisor;
    }

    public void SpeedUp(int multiplier)
    {
        _value *= multiplier;

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(DelaySlowDown(_delayToSlowDown, _divisorOfSlowDown));
    }
}
