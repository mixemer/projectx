using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    public string name;
    public int hp;

    public float hpDecreaseRate = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);

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

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;

    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}