using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public Player player;
    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = player.hp / 100.0f;
    }
}
