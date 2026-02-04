using UnityEngine;

public class CowardAI : MonoBehaviour
{
    Animator animator;
    public CowardState state;
    private Transform player;
    private CowardMovement movement;
    private CowardAttack attack;

    bool active = false;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        movement = GetComponent<CowardMovement>();
        attack = GetComponent<CowardAttack>();
        animator = GetComponent<Animator>();

        // Opcional: empieza en estado Stalking
        state = CowardState.Stalking;
    }

    void Update()
    {
        if (!active) return;

        bool seen = CanSeePlayer();

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
                animator.SetTrigger("Stalking"); // reproduce clip Stalking
                break;

            case CowardState.Fleeing:
                movement.FleeFrom(player);
                animator.SetTrigger("Fleeing"); // reproduce clip Fleeing
                break;

            case CowardState.Attacking:
                attack.Trigger(player);
                animator.SetTrigger("Attacking"); // reproduce clip Attacking
                break;
        }
    }

    public void StartStalking(Transform targetPlayer)
    {
        player = targetPlayer;
        active = true;
    }

    // Verifica si el jugador lo mira
    bool CanSeePlayer()
    {
        Vector2 dirToEnemy = ((Vector2)transform.position - (Vector2)player.position).normalized;
        Vector2 playerLook = player.up; // o player.right según tu orientación

        float dot = Vector2.Dot(dirToEnemy, playerLook);
        // Si dot > 0.5 significa que el jugador está mirando al enemigo
        return dot > 0.5f;
    }
}