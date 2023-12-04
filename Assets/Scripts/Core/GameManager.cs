using System;
using UnityEngine;

public enum GameState
{
    Menu,
    Running,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState currentState;
    public static event Action<GameState> OnGameStateChanged;

    public bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    void Update()
    {
        //if (currentState == GameState.Running)
        if (isGameOver)
        {
            UpdateGameState(GameState.GameOver);
            Time.timeScale = 0;
        }
    }

    void UpdateGameState(GameState newState)
    {
        currentState = newState;
        OnGameStateChanged?.Invoke(currentState);
    }
}
