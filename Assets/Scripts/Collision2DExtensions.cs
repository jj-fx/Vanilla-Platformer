using UnityEngine;

public static class Collision2DExtensions
{
    public static bool WasHitFromBottom(this Collision2D collision)
    {
        var hitPoint = collision.contacts[0].normal;
        return hitPoint.y > 0.5f;
    }

    public static bool WasHitByPlayer(this Collision2D collision)
    {
        var isPlayer = collision.collider.GetComponent<PlayerMovementController>();
        return isPlayer != null;
    }
}