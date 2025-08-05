using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Replay : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
