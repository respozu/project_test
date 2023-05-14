using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private const int MainMenuSceneIndex = 0;
    private const int GameSceneIndex = 1;
    private const int OptionsSceneIndex = 2;
    private const int ShopSceneIndex = 3;
    private const int SingleplayerSceneIndex = 4;
    private const int MultiplayerSceneIndex = 5;
    private const int LobbySceneIndex = 6;

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

    public void LoadShop()
    {
        SceneManager.LoadScene(ShopSceneIndex);
    }

    public void LoadSingleplayer()
    {
        SceneManager.LoadScene(SingleplayerSceneIndex);
    }

    public void LoadMultiplayer()
    {
        SceneManager.LoadScene(MultiplayerSceneIndex);
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene(LobbySceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}