using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopSystem : MonoBehaviour
{
    public GameObject popUpBox;
    //public Animator animator;
    public TMP_Text popUpText;
    public string dialog;
    public bool Active;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Active)
        {
            if (popUpBox.activeInHierarchy)
            {
                popUpBox.SetActive(false);
            }
            else
            {
                popUpBox.SetActive(true);
                popUpText.text = dialog;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Active = false;
            popUpBox.SetActive(false);
        }
    }

}
