using UnityEngine;

public class Breakable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer() && collision.WasHitFromBottom())
        {
            Destroy(gameObject);
        }
    }
}
