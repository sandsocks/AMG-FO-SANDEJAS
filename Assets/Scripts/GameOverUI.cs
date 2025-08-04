using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void GameOver()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
