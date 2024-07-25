using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        // Reset time scale to normal
        Time.timeScale = 1;
        
        // Load the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
