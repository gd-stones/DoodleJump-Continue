using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerMovement playerMovement;

    void Awake()
    {
        GameManager.OnGameStateChanged += HandlePlayer;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandlePlayer;
    }

    void HandlePlayer(GameState state)
    {
        if (state == GameState.GameOver)
        {
            playerAttack.enabled = false;
            playerMovement.enabled = false;
            return;
        }
    }
}
