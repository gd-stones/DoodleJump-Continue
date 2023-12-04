using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public GameObject rocketI;
    public GameObject springsI;
    public GameObject swordI;
    public GameObject shieldI;
    public GameObject buffPlatfI;
    private GameObject[] items;

    private void Awake()
    {
        GameManager.OnGameStateChanged += HandleItem;
        EventManager.CreateItem += SpawnItem;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleItem;
        EventManager.CreateItem -= SpawnItem;
    }

    private void Start()
    {
        items = new GameObject[] { rocketI, springsI, swordI, shieldI, buffPlatfI };
    }

    private void HandleItem(GameState state)
    {
        if (state == GameState.GameOver)
            this.enabled = false;
    }

    public void SpawnItem(Transform platf)
    {
        Vector3 newPos = platf.position;

        int index = Random.Range(0, items.Length);
        if (index == 1)
            newPos.y += 0.25f;
        else
            newPos.y += 0.5f;

        GameObject enemy = SimplePool.Spawn(items[index], newPos, Quaternion.identity);
        enemy.transform.SetParent(platf.transform);
    }
}
