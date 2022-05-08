using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;

    public float speed = 1;
    public bool IsIdle = true;
    public bool isMovingLeft = true;
    public float idleDuration = 10;
    public float movingDuration = 10;

    const string IS_IDLE = "IsIdle";

    float duration = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;

        if (!IsIdle)
        {
            rigidbody2D.velocity = new Vector2(isMovingLeft ? -speed * Time.deltaTime : speed * Time.deltaTime, rigidbody2D.velocity.y);
        }

        if (IsIdle && duration > idleDuration)
        {
            UpdateState(false);
        }

        if (!IsIdle && duration > movingDuration)
        {
            UpdateState(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopColliderForPeople"))
        {
            UpdateState(true);
        }
    }

    void UpdateState(bool IsIdle)
    {
        this.IsIdle = IsIdle;
        animator.SetBool(IS_IDLE, IsIdle);
        duration = 0;
        ChangeMoveDirection();
    }

    void ChangeMoveDirection()
    {
        isMovingLeft = Random.Range(0f, 1f) > 0.5 ? true : false;
        if (isMovingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
