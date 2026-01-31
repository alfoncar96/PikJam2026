using UnityEngine;

public class CowardMovement : MonoBehaviour
{
    public float speed = 2.5f;

    public void FollowPlayerFromBehind(Transform player)
    {
        Vector2 behind = player.position - player.up * 1.5f;
        MoveTowards(behind);
    }

    public void FleeFrom(Transform player)
    {
        Vector2 dir = (transform.position - player.position).normalized;
        MoveTowards((Vector2)transform.position + dir * 3f);
    }

    void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}