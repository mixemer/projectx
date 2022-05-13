using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPanel : MonoBehaviour
{
    private void OnEnable()
    {
        Globals.Instance.FreezeGame();
    }

    public void OnClose()
    {
        Globals.Instance.UnFreezeGame();
        gameObject.SetActive(false);
    }
}
