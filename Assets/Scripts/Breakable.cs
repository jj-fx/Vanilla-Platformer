using UnityEngine;

public class Breakable : MonoBehaviour, ITakeHits
{
    public void HandleHit(WalkerDead walkerDead)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer() && collision.WasHitFromBottom())
        {
            Destroy(gameObject);
        }
    }
}
