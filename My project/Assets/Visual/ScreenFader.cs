using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadePanel;
    public float fadeSpeed = 1f;

    private void Awake()
    {
        // Empieza completamente negro si quieres
        if (fadePanel != null)
            fadePanel.color = new Color(0, 0, 0, 1);

        // Hacemos un fade-in al inicio
        StartCoroutine(FadeIn());
    }

    // Fade-in: de negro a transparente
    public IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadePanel.color = new Color(0, 0, 0, 0);
    }

    // Fade-out: de transparente a negro
    public IEnumerator FadeOut(string sceneToLoad)
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Carga la nueva escena cuando ya está negro
        SceneManager.LoadScene(sceneToLoad);
    }

    // Método público para iniciar fade-out desde otros scripts
    public void FadeToScene(string sceneToLoad)
    {
        StartCoroutine(FadeOut(sceneToLoad));
    }
}
