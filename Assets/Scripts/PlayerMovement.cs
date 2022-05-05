using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(10, 5);
    [SerializeField] float rotationSpeed = 0.3f;

    public float lookUpDownMax = 20;

    Rigidbody2D body;
    Vector2 movement;
    float xInput;
    float yInput;

    bool lookingLeft = true;

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
        movement = new Vector2(xInput * speed.x * Time.deltaTime, yInput * speed.y * Time.deltaTime);

        RotateHorizontal();
        RotateVertical();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(xInput * speed.x * Time.fixedDeltaTime, yInput * speed.y * Time.fixedDeltaTime);
    }

    void RotateVertical()
    {
        if (yInput > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, -lookUpDownMax);
        }
        else if (yInput < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, lookUpDownMax);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }

    void RotateHorizontal()
    {
        if (xInput > 0.1f && lookingLeft)
        {
            lookingLeft = false;
            StopAllCoroutines();
            StartCoroutine(RotateOverTime(Quaternion.Euler(0, 180, transform.rotation.eulerAngles.z)));
        }
        if (xInput < -0.1f && !lookingLeft)
        {
            lookingLeft = true;
            StopAllCoroutines();
            StartCoroutine(RotateOverTime(Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z)));
        }
    }
    IEnumerator RotateOverTime(Quaternion finalRotation)
    {
        if (rotationSpeed > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + rotationSpeed;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / rotationSpeed;
                // progress will equal 0 at startTime, 1 at endTime.
                transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, progress);
                yield return null;
            }
        }
        transform.rotation = finalRotation;
    }
}
