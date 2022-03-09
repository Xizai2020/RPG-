using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectt : MonoBehaviour
{
    //œ‘ æ…À∫¶Ãÿ–ß
    public CharacterStates currentCharacter;
    public GameObject prefabEffect_Damage;
    private void Awake()
    {
        currentCharacter = GetComponent<CharacterStates>();
    }
    void Start()
    {
        currentCharacter.UpdateHealthOnAttack += Effect;
    }

    private void Effect(int currentHealth,int maxHealth,int damage)
    {
        if (damage > 0)
        {
            Instantiate(prefabEffect_Damage,transform);
        }
    }

    void Update()
    {
        
    }
}
