using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform initialSpawnPoint;

    void Start()
    {
        if (initialSpawnPoint != null)
        {
            transform.position = initialSpawnPoint.position;
        }
    }
}
