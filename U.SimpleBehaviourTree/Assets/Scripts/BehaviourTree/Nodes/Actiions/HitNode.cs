using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNode : ActionNode
{
    private Animator animator;
    private Death anotherRobot;

    public HitNode(Death _anotherRobot, Animator _animator)
    {
        animator = _animator;
        anotherRobot = _anotherRobot;
    }
    
    protected override void OnStart()
    {
        animator.SetTrigger("Hit");
        anotherRobot.Die();
    }

    protected override State OnUpdate()
    {
        
        return State.Running;
    }

    protected override void OnStop()
    {
        
    }
}
