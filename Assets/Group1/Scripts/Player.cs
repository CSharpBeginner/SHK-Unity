using UnityEngine;

[RequireComponent(typeof(Speed))]
public class Player : MonoBehaviour
{
    private Speed _speed;

    private void Awake()
    {
        _speed = GetComponent<Speed>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _speed.Value * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -_speed.Value * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_speed.Value * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed.Value * Time.deltaTime, 0, 0);
        }
    }
}
