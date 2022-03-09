using UnityEngine;
using System.Collections;

public class PlayerEffect : SkillAction
{
    public string effectName = "";
    private GameObject effectGo = null;
    public PlayerEffect()
        :base()
    {
    }

    public override void Execute()
    {
        //haver = _skill.haverTr;
        GameObject effect = Resources.Load("Effect/" + effectName) as GameObject;
        if (effect != null)
        {
            //Debug.Log(_skill.centerController.gameObject.transform);
             //effect.transform.parent = _skill.centerController.gameObject.transform;
            effectGo = GameObject.Instantiate(effect, _skill.centerController.gameObject.transform,false) as GameObject;
        }
    }

    public override void Finish()
    {
        if (effectGo != null)
        {
            Destroy(effectGo);
        }
    }
}
