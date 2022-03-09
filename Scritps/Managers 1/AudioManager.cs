using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public  List<AudioSource> audioSources;
    void Start()
    {
        var audios = GetComponentsInChildren<AudioSource>();
        foreach (var item in audios)
        {
            audioSources.Add(item);
        }
        
        
    }
    public void AttackSource()
    {
        foreach (var item in audioSources)
        {
            if (item.gameObject.name == "AttackSource")
            {
                item.Play();
            }
        }
    }
    public void Slill01Source()
    {
        foreach (var item in audioSources)
        {
            if (item.gameObject.name == "Skill01Source")
            {
                item.Play();
            }
        }
    }
}
