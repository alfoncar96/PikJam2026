using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    public string sceneToLoad;
    public float fadeOutTime = 1.2f;
    public float blackHoldTime = 0.5f; 
    public float fadeInTime = 1.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FadeManager.Instance != null)
                FadeManager.Instance.FadeOut();
            else
                Debug.LogError("FadeManager no encontrado");

            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        FadeManager.Instance.FadeOut();

        // esperar a que termine FadeOut
        yield return new WaitForSeconds(fadeOutTime);

        // pantalla negra
        yield return new WaitForSeconds(blackHoldTime);

        // cambiar escena durante el negro
        SceneManager.LoadScene(sceneToLoad);
    }
}
