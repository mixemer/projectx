using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] Camera camera;
    public float interpVelocity;
    public float minDistance;
    public Vector3 offset;


    Vector3 targetPos;



    public float zoom1 = 5;
    public float zoom2 = 10;
    private float yOffset = .85f;

    private float minZoom;
    private float maxZoom;

    public float ypos1;
    public float ypos2;

    public float duration = 1.0f;
    private float elapsed = 0.0f;
    bool transition;

    private void Awake()
    {
        minZoom = zoom1;
        maxZoom = zoom2;
    }

    void Start()
    {
        targetPos = transform.position;
    }


    private void Update()
    {
        if (transition)
        {
            Zoom(zoom1, zoom2);
        }
    }

    private void Zoom(float startOrtagraphicSize, float endOrtagraphicSize)
    {
        elapsed += Time.deltaTime / duration;
        camera.orthographicSize = Mathf.Lerp(startOrtagraphicSize, endOrtagraphicSize, elapsed);
        if (elapsed > 1.0f)
        {
            transition = false;
            elapsed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("TopEdge"))
        {
            zoom1 = minZoom;
            zoom2 = maxZoom;
            offset.y += yOffset;
            transition = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TopEdge"))
        {
            zoom1 = maxZoom;
            zoom2 = minZoom;
            offset.y -= yOffset;
            transition = true;
            Debug.Log("Zoom1: " + zoom1 + " Zoom2: " + zoom2);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 posNoZ = camera.transform.position;
        posNoZ.z = transform.position.z;

        Vector3 targetDirection = (transform.position - posNoZ);

        interpVelocity = targetDirection.magnitude * 5f;

        targetPos = camera.transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

        camera.transform.position = Vector3.Lerp(camera.transform.position, targetPos + offset, 1f);

        //camera.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }
}
