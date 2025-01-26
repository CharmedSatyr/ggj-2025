using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject airBubble;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    float spawnRange;

    [SerializeField]
    float yOrigin = -10f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAirBubble), 0f, spawnInterval);
    }

    void SpawnAirBubble()
    {
        Instantiate(airBubble, GenerateSpawnPosition(), airBubble.transform.rotation);

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        return new(spawnPosX, yOrigin, 0);
    }
}
