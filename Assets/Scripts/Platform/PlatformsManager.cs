using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    public GameObject normalPlatf;
    public GameObject movementPlatf;
    public GameObject disappearingPlatf;
    public GameObject fragilePlatf;

    public GameObject platformContainer;

    public float halfScreenWidth = 2f; // Need to be adjusted depending on each screen
    public float minY = 1.5f;
    public float maxY = 2.5f;

    private Vector3 spawnPos = new Vector3(0, -4.5f, 0);
    private GameObject[] platfPrefabs;

    [SerializeField] private Transform mainCamera;

    private List<GameObject> platforms = new List<GameObject>();

    private void Awake()
    {
        if (platformContainer == null)
            platformContainer = new GameObject("PlatformContainer");

        GameManager.OnGameStateChanged += HandlePlatform;

        EventManager.OnCamMove += CreateMorePlatforms;
        EventManager.ScalePlatfs += ScalePlatf;
        EventManager.DescalePlatfs += DescalePlatf;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandlePlatform;

        EventManager.OnCamMove -= CreateMorePlatforms;
        EventManager.ScalePlatfs -= ScalePlatf;
        EventManager.DescalePlatfs -= DescalePlatf;
    }

    private void Start()
    {
        platfPrefabs = new GameObject[] { normalPlatf, movementPlatf, fragilePlatf, disappearingPlatf };
        InitializePlatforms();
    }

    private void HandlePlatform(GameState state)
    {
        if (state == GameState.GameOver)
            this.enabled = false;
    }

    private void LateUpdate()
    {
        DestroyItemAndEnemy();
    }

    private void DestroyItemAndEnemy()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            GameObject platform = platforms[i];
            if (platform.activeSelf == false)
            {
                if (platform.transform.childCount > 1)
                {
                    for (int j = 1; j < platform.transform.childCount; j++)
                        Destroy(platform.transform.GetChild(j).gameObject);
                }

                platforms.RemoveAt(i);
                i--;
            }
        }
    }

    private float nextSpawnPointY;
    private void InitializePlatforms()
    {
        // First platform initialization
        GameObject firstPlatf = SimplePool.Spawn(normalPlatf, spawnPos, Quaternion.identity);
        firstPlatf.transform.SetParent(platformContainer.transform);

        while (spawnPos.y <= (mainCamera.position.y + 10f))
            SpawnPlatf();

        nextSpawnPointY = Random.Range(minY, maxY);
    }

    private float totalDistance = 0f;
    private void CreateMorePlatforms(float distance)
    {
        totalDistance += distance;

        if (totalDistance >= nextSpawnPointY && spawnPos.y <= mainCamera.position.y + 20f)
        {
            SpawnPlatf();
            totalDistance = 0f;
            nextSpawnPointY = Random.Range(minY, maxY);
        }
    }

    private bool isScaling = false;
    private void ScalePlatf() => isScaling = true;
    private void DescalePlatf() => isScaling = false;

    private bool isSpawnEnemy = false;
    private bool isSpawnItem = false;
    private GameObject platform;
    private int indexPlatfPrefab;
    private void SpawnPlatf()
    {
        indexPlatfPrefab = Random.Range(0, platfPrefabs.Length);

        platform = SimplePool.Spawn(platfPrefabs[indexPlatfPrefab], SetupPos(), Quaternion.identity);
        platforms.Add(platform);

        if (isScaling)
            platform.GetComponent<BasePlatform>().ScalePlatf();
        else
            platform.GetComponent<BasePlatform>().DescalePlatf();

        platform.transform.SetParent(platformContainer.transform);

        if (platfPrefabs[indexPlatfPrefab] == fragilePlatf || platfPrefabs[indexPlatfPrefab] == disappearingPlatf)
        {
            platform = SimplePool.Spawn(normalPlatf, SetupPos(), Quaternion.identity);
            platforms.Add(platform);

            if (isScaling)
                platform.GetComponent<BasePlatform>().ScalePlatf();
            else
                platform.GetComponent<BasePlatform>().DescalePlatf();

            platform.transform.SetParent(platformContainer.transform);
        }

        // Spawn item
        isSpawnItem = Random.Range(1, 5) == 1; // 1 -> 15 <=> probability = 6.66%
        if (!isSpawnEnemy && isSpawnItem)
            EventManager.SpawnItem(platform.transform);

        // Spawn enemy - temporarily deactivated
        //isSpawnEnemy = Random.Range(1, 5) == 1;
        //if (isSpawnEnemy && !isSpawnItem)
        //    EventManager.SpawnEnemy(platform.transform);
    }

    private Vector3 SetupPos()
    {
        spawnPos.y += Random.Range(minY, maxY);
        spawnPos.x = Random.Range(-halfScreenWidth, halfScreenWidth);

        return spawnPos;
    }
}