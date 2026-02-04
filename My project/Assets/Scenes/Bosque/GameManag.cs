using UnityEngine;

public class GameManag : MonoBehaviour
{
    public static GameManag Instance;

    [HideInInspector] public Vector3 nextSpawnPoint; // posición donde aparecerá el jugador

    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persiste entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject player; // referencia al jugador en escena

    void Start()
    {
        // Si nextSpawnPoint tiene valor, colocar al jugador allí
        if (nextSpawnPoint != Vector3.zero && player != null)
        {
            player.transform.position = nextSpawnPoint;
        }
    }
}