using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtroller : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    private Animator animator;
    private CharacterStates characterStates;
    [SerializeField]
    public bool isEnble;
    [Header("Basic Setting")]
    public float speed;

    private FixedJoystick fixedJoystick;
    private void OnEnable()
    {
        GameManager.Instance.RigisterPlayer(characterStates);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterStates = GetComponent<CharacterStates>();
        fixedJoystick = GetComponentInChildren<FixedJoystick>();
    }
    void Start()
    {
        isEnble = true;
    }

    void Update()
    {
        if (isEnble)
        {
            MoveMent();
        }
        
        AttackMent();
        AnimatorMent();
    }

    private void AttackMent()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void AnimatorMent()
    {
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    private void MoveMent()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX == 0 && moveY == 0)
        {
            moveX = fixedJoystick.Horizontal;
            moveY = fixedJoystick.Vertical;
        }
        rb.velocity = new Vector2(moveX, moveY).normalized * speed;
        if (moveX < 0&&isEnble)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (moveX > 0&&isEnble)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
}
