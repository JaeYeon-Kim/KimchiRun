using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    public float minSpawnDelay;
    public float maxSpawnDelay;



    [Header("References")]
    public GameObject[] gameObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));        // 최소 delay와 최대 delay값 사이에서 랜덤
    }

    void Spawn() {
        // Spwner에서 랜덤 오브젝트 생성 
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];

        Instantiate(randomObject, transform.position, Quaternion.identity);     // 마지막값: 오브젝트를 생성할때 별도의 회전값을 주지 않음 
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));        // 2초후에 Spawn 호출 

    }
}
