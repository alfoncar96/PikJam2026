using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public GameObject enemy;  // el enemigo cobarde
    public GameObject player; // tu jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != player) return;

        // Detener movimiento del jugador
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null)
            pm.enabled = false;

        // Activar IA del enemigo
        CowardAI ai = enemy.GetComponent<CowardAI>();
        if (ai != null)
            ai.enabled = true; // activa el Update y HandleState del enemigo

        // Optional: desactivar trigger para que no se vuelva a activar
        GetComponent<Collider2D>().enabled = false;
    }
}