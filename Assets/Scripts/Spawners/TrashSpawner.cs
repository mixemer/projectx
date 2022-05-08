using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trash;

    public float spawnDelayAtBeginning = 20f;
    public float spawnDelayAtMid = 10f;
    public float spawnDelayAtEnding = 3f;

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
        if (trash.Length == 0) return;

        Vector3 randomPos = Spawner.RandomPointInBounds(boxCollider2D.bounds);

        int i = Random.Range(0, trash.Length);
        GameObject o = Instantiate(trash[i], randomPos, Quaternion.identity);
    }
}
