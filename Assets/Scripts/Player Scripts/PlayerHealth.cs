using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject[] healthBars = new GameObject[5];

    private int health;
    private int currentHealthBarIndex;

    private void Awake()
    {
        health = healthBars.Length;
        currentHealthBarIndex = health - 1;

        for (int i = 0; i < healthBars.Length; i++)
        {
            healthBars[i] = GameObject.FindGameObjectWithTag("HB"+i.ToString());
        }
    }

    public void SubtractHealth()
    {
        healthBars[currentHealthBarIndex].SetActive(false);
        health--;
        currentHealthBarIndex--;

        if(health <= 0)
        {
            SoundManager.instance.PlayGameOverSound();
            GameObject.FindWithTag(TagManager.TAG_GAMEPLAY_CONTROLLER).GetComponent<GameOverController>().ShowGameOverCanvas();

            Destroy(gameObject);
        }
    }

    private void AddHealth()
    {
        if (health == healthBars.Length) 
            return;

        currentHealthBarIndex++;
        health++;
        healthBars[currentHealthBarIndex].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.TAG_HEALTH))
        {
            AddHealth();
            SoundManager.instance.PlayCollectableSound();
            collision.gameObject.SetActive(false);
        }
    }
}
