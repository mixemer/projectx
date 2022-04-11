using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Cloud : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] bool randomSpeed = true;

    const int leftX = -350;
    const int rightX = 350;

    private float minSpeed = 0.05f;
    private float maxSpeed = 0.1f;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        SelectSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Translate(speed, 0, 0);

        if (rectTransform.anchoredPosition.x > rightX)
        {
            rectTransform.anchoredPosition = new Vector2(leftX, rectTransform.anchoredPosition.y);
            SelectSpeed();
        }
    }

    void SelectSpeed()
    {
        if (randomSpeed)
        {
            speed = Random.Range(minSpeed, maxSpeed);
        }
    }
}
