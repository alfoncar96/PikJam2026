using UnityEngine;

public class CowardAttack : MonoBehaviour
{
    public float killDistance = 0.7f;
    bool attacking = false;

    public bool CanAttack(Transform player)
    {
        return Vector2.Distance(transform.position, player.position) < killDistance;
    }

    public void Trigger(Transform player)
    {
        if (attacking) return;
        attacking = true;

        Debug.Log("JUMPSCARE por la espalda");
        // aquí cámara, sonido, muerte…
    }
}