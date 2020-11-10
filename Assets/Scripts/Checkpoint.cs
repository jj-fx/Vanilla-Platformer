using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Passed { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var _isPlayer = collision.GetComponent<PlayerMovementController>();

        if (_isPlayer)
        {
            Passed = true;
        }
    }
}
