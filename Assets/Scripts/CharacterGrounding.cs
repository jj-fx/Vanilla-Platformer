using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [Tooltip("Use Two Feet")]
    [SerializeField] private Transform[] _feet = new Transform[2];
    [SerializeField] private float _maxDistance = 0.25f;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        if (IsFootGrounded(_feet[0]) || IsFootGrounded(_feet[1]))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    private bool IsFootGrounded(Transform foot)
    {
        var _raycatHit = Physics2D.Raycast(foot.position, Vector2.down, _maxDistance, _layerMask);

        if (_raycatHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
