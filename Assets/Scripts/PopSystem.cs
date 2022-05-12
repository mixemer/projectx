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
    public float popupTime;
    private string dialog;
    private bool Active;

    private List<string> popUpTexts;

    private void Awake()
    {
        popUpTexts = new List<string>(0);
        popUpTexts.Add("Did you know an estimated 8 million tons of plastic enters our oceans every year?");
        popUpTexts.Add("Did you know there are 5.25 trillion pieces of plastic waste estimated to be in our oceans?");
        popUpTexts.Add("In the past 10 years, we have made more plastic than the last century.");
        popUpTexts.Add("By 2050, the pollution of fish will be outnumbered by our dumped plastic.");
        popUpTexts.Add("It takes 100’s of years to decompose plastic. That means every bit of plastic that was ever created in 1907 still exists in some form in our oceans.");
        popUpTexts.Add("Annually, the Mississippi River flows 1.5 million tons of nitrogen pollution into the Gulf of Mexico.");
        popUpTexts.Add("90% of global debris comes from 10 rivers alone. 8 in Asia and 2 in Africa.");
        popUpTexts.Add("Seabirds, seals, turtles, and whales get entangled in plastic matter which cause them to suffocate, drown, or become easier prey for predators.");
        popUpTexts.Add("Did you know many microplastics that enter the ocean come from our clothing!");
        popUpTexts.Add("More than 800 coastal and marine species are directly affected by the plastic waste in our oceans.");
        popUpTexts.Add("Did you know a million seabirds and 100,000 marine animals die annually because of plastic waste?");
        popUpTexts.Add("Did you know coastal water contamination is responsible for 250 million clinical cases of human diseases annually?");
        popUpTexts.Add("The largest dead zone ever measured was the size of New Jersey.");
        popUpTexts.Add("There are more microplastic in the ocean than there are stars in the Milky Way.");
        popUpTexts.Add("70% of ocean garbage sinks to the seafloor, so it’s unlikely ever to be able to clean it up.");

        if (popupTime == 0) { popupTime = 5; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUpBox.SetActive(true);
            dialog = ChooseRandomText();
            popUpText.text = dialog;

            Active = true;

            StartCoroutine(PopupDelay());
        }
    }

    private IEnumerator PopupDelay()
    {
        Time.timeScale = .001f;
        float pauseEndTime = Time.realtimeSinceStartup + popupTime;

        while (Time.realtimeSinceStartup < pauseEndTime)
            yield return 0;

        popUpBox.SetActive(false);
        Active = false;
        Time.timeScale = 1;

        yield break;
    }

    private string ChooseRandomText()
    {
        int rand = Random.Range(0, popUpTexts.Count - 1);

        return popUpTexts[rand];
    }
}
