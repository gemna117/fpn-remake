using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;

    [SerializeField]
    private GameObject creditsMenuPanel;

    [SerializeField]
    private GameObject titleMenuPanel;

    public void loadgamescene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void showcredits()
    {
        creditsMenuPanel.SetActive(true);
    }

    public void showtitle()
    {
        titleMenuPanel.SetActive(true);
    }

    public void exitgame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
