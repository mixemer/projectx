using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public bool isFood = true;
    public Spawner spawner;
    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddTorque(20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BottomCollider"))
        {
            spawner.DescreaseCount(isFood);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            if (isFood)
            {
                Destroy(gameObject, 3f);
            }
        }
        else if (collision.CompareTag("Player"))
        {
            spawner.DescreaseCount(isFood);
            collision.GetComponent<Player>().Heal(isFood ? 5 : -2);
            Destroy(gameObject);
        }
    }
}
