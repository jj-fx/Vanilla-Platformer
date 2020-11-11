using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [Tooltip("Use Three Feet")]
    [SerializeField] private Transform[] _feet = new Transform[3];
    [SerializeField] private float _maxDistance = 0.25f;
    [SerializeField] private LayerMask _layerMask;
    private Transform[] _groundedObject = new Transform[3];

    public bool IsGrounded { get; private set; }


    private void Update()
    {
        var leftFoot = IsFootGrounded(0);
        var middleFoot = IsFootGrounded(1);
        var rightFoot = IsFootGrounded(2);

        if (leftFoot || middleFoot || rightFoot)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
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
        var _raycatHit = Physics2D.Raycast(_feet[foot].position, Vector2.down, _maxDistance, _layerMask);

        if (_raycatHit.collider != null)
        {
            var collider = _raycatHit.collider;

            if (collider.GetComponent<Coin>() == null)
            {
                _groundedObject[foot] = collider.transform;
            }
            else
            {
                _groundedObject[foot] = null;
            }

            return true;
        }
        else
        {
            _groundedObject[foot] = null;
            return false;
        }
    }
}
