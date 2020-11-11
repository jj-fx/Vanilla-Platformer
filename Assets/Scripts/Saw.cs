using System.Threading;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private float _speed = 4;
    private SpriteRenderer _sawSprite;
    private float _positionPercent = 0;
    private float _direction = 1;

    private void Awake()
    {
        _sawSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        var distance = Vector3.Distance(_start.position, _end.position);
        var speedByDistance = _speed / distance;

        _positionPercent += Time.deltaTime * _direction * speedByDistance;

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
