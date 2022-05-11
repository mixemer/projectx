using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotSlot.HandPainted2D;

public class PollutionDamager : MonoBehaviour
{
    // Dead fish sprite
    public Sprite deadFishSprite;
    public int maxDeathTime;

    // Start is called before the first frame update
    void Start()
    {
        if(maxDeathTime == 0) { maxDeathTime = 60; }

        // Get random amount of seconds between 0 and 1 minute
        int rand = Random.Range(10, maxDeathTime);

        // Start the timer based on the randomly generated int
        StartCoroutine(FishLifeSpanTick(rand));
    }

    private IEnumerator FishLifeSpanTick(int lifeSpan)
    {
        while (true)
        {
            // Wait for 'x' seconds
            yield return new WaitForSeconds(lifeSpan);

            // Kill the fish
            Die();

            // yield break to fully stop the coroutine
            yield break;
        }
    }

    private void Die()
    {
        // Disable fish movement
        GetComponent<AnimateTranslateLoop>().enabled = false;

        // Change the sprite to a random dead fish
        GetComponent<SpriteRenderer>().sprite = deadFishSprite;

        // Lower the scale of the
        transform.localScale = transform.localScale / 10;
    }
}
