using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para gestionar escenas

public class SceneChanger : MonoBehaviour
{
    // Método para ir a la escena "Tutorial"
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Método para ir a la escena "Level"
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level");
    }

    // Método para reiniciar la escena "Level"
    public void RetryLevel()
    {
        SceneManager.LoadScene("Level");
    }

    // Método para ir a la escena "MainMenu"
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
