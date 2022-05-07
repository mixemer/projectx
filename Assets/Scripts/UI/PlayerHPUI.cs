using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public Player player;
    public Image bar;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        bar.fillAmount = 1;
    }

    void Update()
    {
        bar.fillAmount = player.GetHp() / 100.0f;
    }
}
