using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f, jumpForce = 20f;
    [SerializeField] private float attackWaitTime = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    private bool canJump = false, canSecondJump = false;
    private float attackTimer;
    private new Rigidbody2D rigidbody2D;
    private CapsuleCollider2D capsuleCollider2D;
    private Transform groundCheack;
    private Vector2 moveVector;
    private RaycastHit2D grounHit;
    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        attackTimer = Time.time;
    }

    private void FixedUpdate()
    {
        MovePalyer();
    }

    private void Update()
    {
        GroundCheack();
        GetJumpInput();
        GetAttackInput();
        AnimatePlayer();
    }

    private void MovePalyer()
    {
        moveVector = rigidbody2D.velocity;
        moveVector.x = moveSpeed;
        rigidbody2D.velocity = moveVector;
    }

    private void GroundCheack()
    {
        grounHit = Physics2D.BoxCast(capsuleCollider2D.transform.position, capsuleCollider2D.size, 0f, Vector2.down, 0.5f, groundLayer);

        if(grounHit)
        {
            canJump = true;
            canSecondJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void Jump()
    {
        moveVector = rigidbody2D.velocity;
        moveVector.y = jumpForce;
        rigidbody2D.velocity = moveVector;
        SoundManager.instance.PlayPlayerJumpSound();
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            canJump = false;
            canSecondJump = true;
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && canSecondJump)
        {
            playerAnimations.PlayDoubleJump();
            Jump();
            canSecondJump = false;
            return;
        }
    }

    private void AnimatePlayer()
    {
        playerAnimations.PlayJump(rigidbody2D.velocity.y);
        playerAnimations.PlayFromFallToRunning(canJump);
    }

    private void GetAttackInput()
    {
        if(Input.GetKeyDown(KeyCode.K) && (Time.time > attackTimer))
        {
            attackTimer = Time.time + attackWaitTime;
            HandleAttackAction();

        }
    }

    private void HandleAttackAction()
    {
        if(canJump)
        {
            playerAnimations.PlayAttack();
        }
        else
        {
            playerAnimations.PlayJumpAttack();
        }

        SoundManager.instance.PlayPlayerAttackSound();
    }
}
