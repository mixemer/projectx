using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public bool isFood = true;
    public bool canFloat = false;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddTorque(Random.Range(0f, 1f) > 0.5f ? 20f : -20f);

        if (canFloat && Random.Range(0f, 1f) > 0.5f)
        {
            body.constraints = RigidbodyConstraints2D.FreezeAll;
            DestroyFoodDelayed(15);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BottomCollider"))
        {
            body.constraints = RigidbodyConstraints2D.FreezeAll;
            DestroyFoodDelayed(3);
        }
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Heal(isFood ? 5 : -2);
            Destroy(gameObject);
        }
    }

    void DestroyFoodDelayed(float delay)
    {
        if (isFood)
        {
            Destroy(gameObject, delay);
        }
    }
}
