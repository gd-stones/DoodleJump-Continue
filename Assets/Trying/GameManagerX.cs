using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    public static GameManagerX Instance;

    public GameStateX StateX;

    public static event Action<GameStateX> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameStateX.SelectColor);
    }

    public void UpdateGameState(GameStateX newState)
    {
        StateX = newState;

        switch (newState)
        {
            case GameStateX.SelectColor:
                HandleSelectColor();
                break;
            case GameStateX.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameStateX.EnemyTurn:
                HandleEnemyTurn();
                break;
            case GameStateX.Decide:
                HandleDecide();
                break;
            case GameStateX.Victory:
                break;
            case GameStateX.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeExeption(nameof(newState), null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private async void HandleDecide()
    {
        var units = FindObjectsOfType<Unit>();

        await Task.Delay(500);

        if (!units.Any(u => u.Faction == Faction.Enemy))
            UpdateGameState(GameStateX.Victory);
        else if (!units.Any(u => u.Faction == Faction.Player))
            UpdateGameState(GameStateX.Lose);
        else
            UpdateGameState(GameStateX.PlayerTurn);

    }

    private async void HandleEnemyTurn()
    {
        await Task.Delay(2000);

        //UnitManager.Instance.Attack(Faction.Enemy);

        await Task.Delay(2000);
    }

    private void HandlePlayerTurn()
    {
    }

    private void HandleSelectColor()
    {
    }
}

public enum GameStateX
{
    SelectColor,
    PlayerTurn,
    EnemyTurn,
    Decide,
    Victory,
    Lose,
}