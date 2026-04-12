using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("ForestHill");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
