using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject eSeaUrchins;

    private void Awake()
    {
        GameManager.OnGameStateChanged += HandleEnemy;
        EventManager.CreateEnemy += SpawnEnemy;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleEnemy;
        EventManager.CreateEnemy -= SpawnEnemy;
    }

    private void HandleEnemy(GameState state)
    {
        if (state == GameState.GameOver)
            this.enabled = false;
    }

    private void SpawnEnemy(Transform platf)
    {
        Vector3 newPos = platf.position;
        newPos.y += 0.5f;

        GameObject enemy = SimplePool.Spawn(eSeaUrchins, newPos, Quaternion.identity);
        enemy.transform.SetParent(platf.transform);
    }
}
