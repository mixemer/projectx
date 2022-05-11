using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotSlot.HandPainted2D;

public class EnemyFishFollow : MonoBehaviour
{
    private Transform player;
    public float distanceBeforeAttacking;
    private bool isInRange = false;

    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if player is near the enemy
        float dist = Vector2.Distance(player.transform.position, transform.position);

        AnimateTranslateLoop translateLoop = GetComponent<AnimateTranslateLoop>();

        // If in range
        if (dist < distanceBeforeAttacking)
        {
            // Check that TranslateLoop is turned off
            if (translateLoop.enabled) { translateLoop.enabled = false; }

            // Check that swim toward trigger is set
            if (!isInRange) { isInRange = true; }
        }
        // If not in range
        else
        {
            // Check that TranslateLoop is turned on
            if (!translateLoop.enabled) { translateLoop.enabled = true; }

            // Check that swim toward trigger is set
            if (isInRange) { isInRange = false; }
        }

        if (isInRange)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
