using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public float viewDistance = 6f;
    public float viewAngle = 70f;
    public LayerMask obstacleMask;

    public bool CanSee(Vector2 targetPos)
    {
        Vector2 dir = (targetPos - (Vector2)transform.position);
        if (dir.magnitude > viewDistance) return false;

        float angle = Vector2.Angle(transform.up, dir);
        if (angle > viewAngle / 2f) return false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dir.magnitude, obstacleMask);
        return hit.collider == null;
    }
}