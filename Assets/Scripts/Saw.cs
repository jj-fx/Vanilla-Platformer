using System.Threading;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    private SpriteRenderer _sawSprite;
    private float _positionPercent = 0;
    private float _direction = 1;

    private void Awake()
    {
        _sawSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        _positionPercent += Time.deltaTime * _direction;

        _sawSprite.transform.position = Vector3.Lerp(_start.position, _end.position, _positionPercent);

        if (_positionPercent >= 1 && _direction == 1)
        {
            _direction = -1;
        }
        else if (_positionPercent <= 0 && _direction == -1)
        {
            _direction = 1;
        }
    }
}
