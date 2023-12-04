using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject homeScreen;

    void Awake()
    {
        GameManager.OnGameStateChanged += HandleMenu;
        GameManager.OnGameStateChanged += HandleGameOver;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleMenu;
        GameManager.OnGameStateChanged -= HandleGameOver;
    }

    void HandleMenu(GameState state)
    {
        if (state == GameState.Menu)
            homeScreen.SetActive(true);
    }

    void HandleGameOver(GameState state)
    {
        if (state == GameState.GameOver)
            Lose();
    }

    #region Menu
    void PlayButton()
    {
        homeScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    void TopScores()
    {
    }

    void SettingButton()
    {
    }
    #endregion

    #region In Game Screen
    void PauseButton()
    {
    }

    void DisplayScore()
    {
    }

    #endregion

    void Lose()
    {
        inGameScreen.SetActive(false);
        loseScreen.SetActive(true);
    }
}