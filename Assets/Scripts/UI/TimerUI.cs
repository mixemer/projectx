using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public GameSceneManager sceneManager;
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Timer: "+sceneManager.RemaininTimerSeconds.ToString("F2");
    }
}
