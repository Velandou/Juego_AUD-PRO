using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance;

    public GameObject[] enemyPrefabs;

    public float spawnInterval = 2f;

    private float cameraHeight;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", 0f, spawnInterval);
        cameraHeight = FindObjectOfType<cameraController>().transform.position.y;
    }

    public void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), cameraHeight + 5f, 0f);
        GameObject enemyObject = Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        Rigidbody2D rb = enemyObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = enemyObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 1f;
    }

}
