using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _colorSelectPanel;
    [SerializeField] private TextMeshProUGUI _stateText;
    [SerializeField] private Button _attackButton;

    private void Awake()
    {
        GameManagerX.OnGameStateChanged += GameManagerXOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManagerX.OnGameStateChanged -= GameManagerXOnOnGameStateChanged;
    }

    private void GameManagerXOnOnGameStateChanged(GameStateX state)
    {
        _colorSelectPanel.SetActive(state == GameStateX.SelectColor);

        _attackButton.interactable = state == GameStateX.PlayerTurn;
    }

    public void AttackPressed()
    {
        //UnitManager.Instance.Attack(Faction.Player);

        GameManagerX.Instance.UpdateGameState(GameStateX.EnemyTurn);
    }
}
