using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public bool isFood = true;
    public Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BottomCollider"))
        {
            spawner.count--;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Heal(isFood ? 5 : -2);
            Destroy(gameObject);
        }
    }
}
