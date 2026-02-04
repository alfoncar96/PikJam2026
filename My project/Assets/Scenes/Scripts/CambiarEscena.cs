using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscena : MonoBehaviour
{
    public void LoadScene(string Bosque)
    {
        SceneManager.LoadScene(Bosque);
    }
}
