using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int hp;

    public float hpDecreaseRate = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        InvokeRepeating("DecreaseHP", 1f, hpDecreaseRate);
    }

    public void Heal(int amount)
    {
        if (hp >= 100)
        {
            hp = 100;
            return;
        }

        hp += amount;
    }

    void DecreaseHP()
    {
        if (hp < 0)
        {
            hp = 0;
            return;
        }

        hp -= 1;
    }
}
