using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemt_CheckRange : MonoBehaviour
{
    public float range;
    private Collider2D coll;
    public GameObject target;
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (coll.GetComponent<CircleCollider2D>())
        {
            coll.GetComponent<CircleCollider2D>().radius = range;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = null;
        }
    }
}
