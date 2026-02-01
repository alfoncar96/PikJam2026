using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionMuelle : MonoBehaviour
{
    [Header("Configuración de la zona")]
    public string Muelle;           // Nombre de la escena a cargar
    public Transform spawnPoint;         // Spawn point en la nueva escena (opcional)

    [Header("Condición")]
    public bool fase1 = true;            // Solo permite cambiar de zona si está activado

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica que sea el jugador
        if (!other.CompareTag("Player")) return;

        // Verifica la condición
        if (!fase1) return;
        print("Aqui pone mensaje de que no está ready jaja :D");

        // Si hay un spawnPoint, guardamos su posición en el GameManager
        if (spawnPoint != null)
        {
            GameManager.Instance.nextSpawnPoint = spawnPoint.position;
        }

        ScreenFader fader = Object.FindFirstObjectByType<ScreenFader>();
        if (fader != null)
        {
            fader.FadeToScene(Muelle);
        }
        else
        {
            SceneManager.LoadScene(Muelle);
        }
    }
}