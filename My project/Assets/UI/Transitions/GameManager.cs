using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Vector3 nextSpawnPoint; // posición a usar en la siguiente escena
    public GameObject player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (nextSpawnPoint != Vector3.zero && player != null)
            player.transform.position = nextSpawnPoint;
    }
}