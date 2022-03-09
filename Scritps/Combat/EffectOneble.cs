using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOneble : MonoBehaviour
{

    public float liveTime;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        Destroy(gameObject, liveTime);
        audioSource.PlayDelayed(UnityEngine.Random.value * 0.1f);
    }


}
