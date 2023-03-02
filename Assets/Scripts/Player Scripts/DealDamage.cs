using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private bool deactivateGameObject;

    private bool damageDeal = false;

    private void OnEnable()
    {
        damageDeal = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageDeal) 
            return;

        if (collision.gameObject.CompareTag(TagManager.TAG_PLAYER))
        {
            Debug.Log("Deal damage to player");
            collision.gameObject.GetComponent<PlayerHealth>().SubtractHealth();

            if (deactivateGameObject)
            {
                gameObject.SetActive(false);
            }

            damageDeal = true;
        }

        if (collision.gameObject.CompareTag(TagManager.TAG_ENEMY) || collision.gameObject.CompareTag(TagManager.TAG_OBSTACLE))
        {
            Debug.Log("Deal damage to enemy");

            if (collision.gameObject.CompareTag(TagManager.TAG_ENEMY))
                SoundManager.instance.PlayEnemyDeathSound();
            else
                SoundManager.instance.PlayObstacleDestroySound();

            collision.gameObject.SetActive(false);
        }
    }
}