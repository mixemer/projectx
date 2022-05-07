using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleReset : MonoBehaviour
{
    void Start()
    {
        Globals.Instance.UnFreezeGame();
    }
}
