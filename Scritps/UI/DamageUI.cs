using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DamageUI : MonoBehaviour
{
    void Start()
    {

        if (this.gameObject != null)
        {
            transform.DOMove(this.transform.position + Vector3.up, 1f);
            Destroy(gameObject, 1.1f);
        }

    }

    void Update()
    {
        
    }
}
