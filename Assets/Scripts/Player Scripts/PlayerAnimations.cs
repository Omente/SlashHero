using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] GameObject damageDetector;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayFromFallToRunning(bool running)
    {
        animator.SetBool(TagManager.ANIMATION_PLAYER_RUN_PARAMETER, running);
    }

    public void PlayJump(float vellocityY)
    {
        animator.SetFloat(TagManager.ANIMATION_PLAYER_JUMP_PARAMETER, vellocityY);
    }

    public void PlayDoubleJump()
    {
        animator.SetTrigger(TagManager.ANIMATION_PLAYER_DOUBLE_JUMP_PARAMETER);
    }

    public void PlayAttack()
    {
        animator.SetTrigger(TagManager.ANIMATION_PLAYER_ATTACK_PARAMETER);
    }

    public void PlayJumpAttack()
    {
        animator.SetTrigger(TagManager.ANIMATION_PLAYER_JUMP_ATTACK_PARAMETER);
    }

    private void ActivateDamageDetector()
    {
        damageDetector.SetActive(true);
    }

    private void DeactivateDamageDetector()
    {
        damageDetector.SetActive(false);
    }
}
