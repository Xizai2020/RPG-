using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public CharacterStates characterStates;
    private Rigidbody2D rb;
    private Animator animator;
    public  Behaviour behaviour;

    public List<Collider2D> collider2Ds; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Start()
    {
        behaviour = GetComponent<Behaviour>();
        characterStates = GetComponent<CharacterStates>();
        foreach (var item in GetComponents<Collider2D>())
        {
            collider2Ds.Add(item);
        }
        foreach (var item in GetComponentsInChildren<Collider2D>())
        {
            collider2Ds.Add(item);
        }
    }

    void Update()
    {
        if (characterStates.CurrentHealth <= 0)
        {
            DeadState();
        }
    }
    private void DeadState()
    {
        behaviour.enabled = false;
        foreach (var item in collider2Ds)
        {
            item.enabled = false;
        }
        Destroy(gameObject, 1);
    }
}
