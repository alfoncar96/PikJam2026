using UnityEngine;

public class CowardMovement : MonoBehaviour
{
    public float speed = 2.5f;

    public void FollowPlayerFromBehind(Transform player)
    {
        Vector2 playerPos2D = player.position;
        Vector2 playerForward2D = player.up;
        Vector2 behind = playerPos2D - playerForward2D * 1.5f;

        MoveTowards(behind);
    }

    public void FleeFrom(Transform player)
    {
        Vector2 playerPos2D = player.position;
        Vector2 dir = ((Vector2)transform.position - playerPos2D).normalized;
        Vector2 fleeTarget = (Vector2)transform.position + dir * 3f;

        MoveTowards(fleeTarget);
    }

    void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, target, speed * Time.deltaTime);
    }
}