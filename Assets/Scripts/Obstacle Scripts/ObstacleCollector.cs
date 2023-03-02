using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.TAG_ENEMY)
            || collision.gameObject.CompareTag(TagManager.TAG_OBSTACLE) || collision.gameObject.CompareTag(TagManager.TAG_HEALTH))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.TAG_ENEMY)
            || collision.gameObject.CompareTag(TagManager.TAG_OBSTACLE))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
