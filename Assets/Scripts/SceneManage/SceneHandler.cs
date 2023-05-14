using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private const int MainMenuSceneIndex = 0;
    private const int GameSceneIndex = 1;
    private const int OptionsSceneIndex = 2;
    private const int ShopSceneIndex = 3;

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

    public void LoadShop()
    {
        SceneManager.LoadScene(ShopSceneIndex);
    }
}