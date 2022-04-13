using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BoxCollider2D collider2D;
    public GameObject[] food;
    public GameObject[] trash;

    public int maxCount = 20;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 0.5f);
    }

    void Spawn()
    {
        int fort = Random.Range(0, 2);
        Vector3 randomPos = RandomPointInBounds(collider2D.bounds);

        if (food.Length == 0) return;
        if (count >= maxCount) return;

        int i = Random.Range(0, food.Length);
        GameObject o = Instantiate(food[i], randomPos, Quaternion.identity);
        o.GetComponent<Drop>().spawner = this;
        count++;

/*        if (fort == 0)
        {
            if (food.Length == 0) return;

            int i = Random.Range(0, food.Length);

        } else
        {
            if (trash.Length == 0) return;

            int i = Random.Range(0, trash.Length);
        }*/
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0
        );
    }

}
