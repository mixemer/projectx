using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(10, 5);
    [SerializeField] float rotationSpeed = 0.3f;

    Rigidbody2D body;
    Vector2 movement;
    float xInput;
    float yInput;
    bool lookingLeft = true;

    Quaternion lookLeft = Quaternion.Euler(0, 0, 0);
    Quaternion lookRight = Quaternion.Euler(0, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        movement = new Vector2(xInput * speed.x, yInput * speed.y);
        movement *= Time.deltaTime;

        Rotate();
    }

    private void FixedUpdate()
    {
        body.velocity = movement;
    }

    void Rotate()
    {
        if (xInput > 0.1f && lookingLeft)
        {
            lookingLeft = false;
            StopAllCoroutines();
            StartCoroutine(RotateOverTime(lookLeft, lookRight));
        }
        if (xInput < -0.1f && !lookingLeft)
        {
            lookingLeft = true;
            StopAllCoroutines();
            StartCoroutine(RotateOverTime(lookRight, lookLeft));
        }
    }
    IEnumerator RotateOverTime(Quaternion originalRotation, Quaternion finalRotation)
    {
        if (rotationSpeed > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + rotationSpeed;
            transform.rotation = originalRotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / rotationSpeed;
                // progress will equal 0 at startTime, 1 at endTime.
                transform.rotation = Quaternion.Slerp(originalRotation, finalRotation, progress);
                yield return null;
            }
        }
        transform.rotation = finalRotation;
    }
}
