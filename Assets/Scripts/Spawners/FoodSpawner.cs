using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] food;

    public float spawnDelayAtBeginning = 2f;
    public float spawnDelayAtMid = 5f;
    public float spawnDelayAtEnding = 10f;
    //public int maxFoodCount = 20;
    //public int foodCount = 0;

    float spawnDelay;
    float delay = 0;
    BoxCollider2D boxCollider2D;
    GameSceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        sceneManager = FindObjectOfType<GameSceneManager>();
        spawnDelay = spawnDelayAtBeginning;
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        SetDelay();

        if (delay > spawnDelay)
        {
            delay = 0;
            Spawn();
        }
    }

    void SetDelay()
    {
        if (sceneManager.gameStage == GameSceneManager.GameStage.Starting)
        {
            spawnDelay = spawnDelayAtBeginning;
        }
        if (sceneManager.gameStage == GameSceneManager.GameStage.Mid)
        {
            spawnDelay = spawnDelayAtMid;
        }
        if (sceneManager.gameStage == GameSceneManager.GameStage.Ending)
        {
            spawnDelay = spawnDelayAtEnding;
        }
    }

    void Spawn()
    {
        if (food.Length == 0) return;

        Vector3 randomPos = Spawner.RandomPointInBounds(boxCollider2D.bounds);

        int i = Random.Range(0, food.Length);
        GameObject o = Instantiate(food[i], randomPos, Quaternion.identity);
    }
}
