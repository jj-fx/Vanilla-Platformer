using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    [SerializeField] private bool _canKillWalkers;
    public bool CanKillWalkers => _canKillWalkers;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();

        if (playerMovementController != null)
        {
            GameManager.Instance.KillPlayer();
        }
    }
}
