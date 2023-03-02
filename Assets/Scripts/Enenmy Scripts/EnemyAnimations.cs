using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private GameObject damageCollider;

    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }

    public void PlayAttack()
    {
        animator.SetTrigger(TagManager.ANIMATION_ENEMY_ATTACK_TRIGGER);
    }

    public void PlayDeath()
    {
        animator.SetBool(TagManager.ANIMATION_ENEMY_DEATH_PARAMETER, true);
    }

    private void ActivateDamageCollider()
    {
        damageCollider.SetActive(true);
    }

    private void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }
}
