using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    public GameObject Target;
    public float orthoSize = 30;

    Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(
            Target.transform.position.x, Target.transform.position.y, -1);

        camera.orthographicSize = orthoSize;
    }
}
