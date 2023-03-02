using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyAnimations enemyAnimations;

    private void Awake()
    {
        enemyAnimations = GetComponentInParent<EnemyAnimations>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.TAG_PLAYER))
        {
            enemyAnimations.PlayAttack();
            SoundManager.instance.PlayEnemyAttackSound();
        }
    }

}
