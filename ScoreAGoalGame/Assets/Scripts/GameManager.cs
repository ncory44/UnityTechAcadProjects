using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState = GameState.Menu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void StartGame()
    {
        currentState = GameState.Playing;
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f; //reset time in case it was frozen

        //reset UI after the scene loads
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (UIManager.Instance != null)
            UIManager.Instance.ResetUI();

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void WinGame()
    {
        currentState = GameState.Won;
        Debug.Log("You Win!");
        Time.timeScale = 0f;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowKickMessage(false);
            UIManager.Instance.ShowWinMessage(true);
        }
    }
}
