using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [Tooltip("Use Three Feet")]
    [SerializeField] private Transform[] _feet;
    [SerializeField] private float _maxDistance = 0.1f;
    [SerializeField] private LayerMask _layerMask;
    private Transform[] _groundedObject;

    public bool IsGrounded { get; private set; }
    public Vector3? GroundedDirection { get; private set; }

    private void Awake()
    {
        _groundedObject = new Transform[_feet.Length];
    }

    private void Update()
    {
        IsGrounded = false;

        for (int i = 0; i < _feet.Length; i++)
        {
            if (IsFootGrounded(i) == true)
            {
                IsGrounded = IsGrounded || true;
            }
        }

        StickToMovingObjects();
    }

    private void StickToMovingObjects()
    {
        Transform groundedObject = GetGroundedObject();
        
        if (groundedObject != null)
        {
            transform.parent = groundedObject;
        }
        else
        {
            transform.parent = null;
        }
    }

    private Transform GetGroundedObject()
    {
        Transform groundedObject;

        if (_groundedObject[0] == _groundedObject[1])
        {
            groundedObject = _groundedObject[0];
        }
        else if (_groundedObject[2] == _groundedObject[1])
        {
            groundedObject = _groundedObject[2];
        }
        else
        {
            groundedObject = null;
        }

        return groundedObject;
    }

    private bool IsFootGrounded(int foot)
    {
        var _raycatHit = Physics2D.Raycast(_feet[foot].position, _feet[foot].forward, _maxDistance, _layerMask);
        Debug.DrawRay(_feet[foot].position, _feet[foot].forward, Color.red, _maxDistance);

        if (_raycatHit.collider != null)
        {
            var collider = _raycatHit.collider;

            if (_groundedObject[foot] != collider.transform && 
                collider.GetComponent<Coin>() == null && 
                collider.GetComponent<Walker>() == null)
            {
                _groundedObject[foot] = collider.transform;
            }

            GroundedDirection = _feet[foot].forward;

            return true;
        }
        else
        {
            _groundedObject[foot] = null;
            return false;
        }
    }
}
