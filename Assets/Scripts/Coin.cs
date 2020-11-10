using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isPlayer = collision.GetComponent<PlayerMovementController>();
        if (isPlayer)
        {
            GameManager.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
