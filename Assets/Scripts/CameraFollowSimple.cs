using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    public GameObject Target;
    public float orthoSize = 30;

    Camera camera;
    Player playerScript;

    private void Start()
    {
        camera = GetComponent<Camera>();

        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.IsAlive()) return;
        camera.transform.position = new Vector3(
            Target.transform.position.x, Target.transform.position.y, -1);

        camera.orthographicSize = orthoSize;
    }
}
