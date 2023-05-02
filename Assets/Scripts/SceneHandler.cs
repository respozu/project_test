using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private const int MainMenuSceneIndex = 0;
    private const int GameSceneIndex = 1;
    private const int OptionsSceneIndex = 2;

    public void StartGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(OptionsSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}