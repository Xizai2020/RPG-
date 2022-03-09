using UnityEngine;
using System.Collections;

public class PlayAnimator : SkillAction 
{
    public PlayAnimator()
        :base()
    {
    }

    //要播放的动画
    public Status _name = Status.Idle;

    public override void Execute()
    {
        _skill.centerController.statusController.Play(_name);
    }
}
