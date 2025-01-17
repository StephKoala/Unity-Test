using UnityEngine;
using UnityEngine.SceneManagement;  

public class SceneChanger : MonoBehaviour
{
    
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
