using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _radius;
    [SerializeField] private int _speed;

    private Vector3 _target;

    public event UnityAction Destroyed;

    private void Start()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
        {
            _target = Random.insideUnitCircle * _radius;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke();
    }
}
