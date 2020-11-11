using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private float _speed = 4;
    private SpriteRenderer _sprite;
    private float _positionPercent = 0;
    private float _direction = 1;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();

        _endPosition = _end.position;
        _startPosition = _start.position;

        AdjustPositionsByColliderType();
    }

    private void Update()
    {
        var distance = Vector3.Distance(_startPosition, _endPosition);
        var speedByDistance = _speed / distance;

        _positionPercent += Time.deltaTime * _direction * speedByDistance;

        _sprite.transform.position = Vector3.Lerp(_startPosition, _endPosition, _positionPercent);

        if (_positionPercent >= 1 && _direction == 1)
        {
            _direction = -1;
        }
        else if (_positionPercent <= 0 && _direction == -1)
        {
            _direction = 1;
        }
    }

    private void AdjustPositionsByColliderType()
    {
        var radius = GetComponentInChildren<Collider2D>().bounds.size.x;
        _endPosition.x -= radius * 0.5f;
        _startPosition.x += radius * 0.5f;
    }
}
