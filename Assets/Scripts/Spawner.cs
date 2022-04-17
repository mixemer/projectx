using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BoxCollider2D collider2D;
    public GameObject[] food;
    public GameObject[] trash;

    public int maxFoodCount = 20;
    public int maxTrashCount = 20;

    public int foodCount = 0;
    public int trashCount = 0;

    public GameSceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 0.5f);
    }

    void Spawn()
    {
        int fort = Random.Range(0, 2);
        Vector3 randomPos = RandomPointInBounds(collider2D.bounds);

        GameObject o;

        if (fort == 0)
        {
            if (food.Length == 0) return;
            if (foodCount >= maxFoodCount) return;

            int i = Random.Range(0, food.Length);
            o = Instantiate(food[i], randomPos, Quaternion.identity);
            o.GetComponent<Drop>().spawner = this;
            foodCount++;
        }
        else
        {
            if (trash.Length == 0) return;
            if (trashCount >= maxTrashCount) return;

            int i = Random.Range(0, trash.Length);
            o = Instantiate(trash[i], randomPos, Quaternion.identity);
            o.GetComponent<Drop>().spawner = this;
            trashCount++;
        }

        o.GetComponent<Drop>().spawner = this;
    }

    private void Update()
    {
        SetFoodAndTrashCount();
    }

    void SetFoodAndTrashCount()
    {
        // TODO: be smarter about this
        if (sceneManager.gameStage == GameSceneManager.GameStage.Starting)
        {
            maxFoodCount = 20;
            maxTrashCount = 0;
        }
        if (sceneManager.gameStage == GameSceneManager.GameStage.Mid)
        {
            maxFoodCount = 10;
            maxTrashCount = 10;
        }
        if (sceneManager.gameStage == GameSceneManager.GameStage.Ending)
        {
            maxFoodCount = 5;
            maxTrashCount = 20;
        }
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0
        );
    }

    public void DescreaseCount(bool isFood)
    {
        if (isFood)
        {
            foodCount--;
        } else
        {
            trashCount--;
        }
    }
}
