using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coral : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    public bool isAlive = true;
    public bool isAlreadyShown = false;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameSceneManager.GetGameStage() == GameSceneManager.GameStage.Ending)
        {
            isAlive = false;
            spriteRenderer.enabled = false;
        }
    }


    /*
     * If player gets really close
     * Give UI an event to show a popup, giving informatio about coral.
     * If coral is dead show dead image, otherwise show alive image
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ui appear
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ui disappear
        }
    }
}
