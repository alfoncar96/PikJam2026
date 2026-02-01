using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public Vector3 nextSpawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            nextSpawnPoint = Vector3.zero;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}