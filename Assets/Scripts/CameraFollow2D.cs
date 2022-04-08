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
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
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
