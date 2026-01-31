using UnityEngine;

public class CowardAI : MonoBehaviour
{
    public CowardState state;

    PlayerVision vision;
    Transform player;
    CowardMovement movement;
    CowardAttack attack;

    void Awake()
    {
        vision = FindObjectOfType<PlayerVision>();
        player = GameObject.FindWithTag("Player").transform;
        movement = GetComponent<CowardMovement>();
        attack = GetComponent<CowardAttack>();
    }

    void Update()
    {
        bool seen = vision.CanSee(transform.position);

        if (seen)
            state = CowardState.Fleeing;
        else
            state = CowardState.Stalking;

        if (attack.CanAttack(player))
            state = CowardState.Attacking;

        HandleState();
    }

    void HandleState()
    {
        switch (state)
        {
            case CowardState.Stalking:
                movement.FollowPlayerFromBehind(player);
                break;

            case CowardState.Fleeing:
                movement.FleeFrom(player);
                break;

            case CowardState.Attacking:
                attack.Trigger(player);
                break;
        }
    }
}