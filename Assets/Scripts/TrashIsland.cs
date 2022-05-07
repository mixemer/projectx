using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashIsland : MonoBehaviour
{
    public GameSceneManager sceneManager;
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;

    // Start is called before the first frame update
    void Start()
    {
        part1.SetActive(true);
        part2.SetActive(false);
        part3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneManager.GetGameStage() == GameSceneManager.GameStage.Mid)
        {
            part2.SetActive(true);
        }

        if (sceneManager.GetGameStage() == GameSceneManager.GameStage.Ending)
        {
            part3.SetActive(true);
        }
    }
}
