using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugtext : Singleton<Debugtext>
{
    public Text text;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
