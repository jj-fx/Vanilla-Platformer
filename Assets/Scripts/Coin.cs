using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isPlayer = collision.GetComponent<PlayerMovementController>();

        if (isPlayer)
        {
            GameManager.Instance.GainCoin();
            Destroy(gameObject);
        }
    }
}
