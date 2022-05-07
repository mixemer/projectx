using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.Instance.FreezeGame();
    }

    public void OnClose()
    {
        Globals.Instance.UnFreezeGame();
        gameObject.SetActive(false);
    }
}
