using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Transform playerSpawnPoint;
    public bool changePerspectiveTo45 = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Transition(other.gameObject));
        }
    }

    private IEnumerator Transition(GameObject player)
    {
        UIManager.Instance.FadeOut();
        yield return new WaitForSeconds(0.5f); 

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        player.transform.position = playerSpawnPoint.position;

        UIManager.Instance.FadeIn();
    }
}