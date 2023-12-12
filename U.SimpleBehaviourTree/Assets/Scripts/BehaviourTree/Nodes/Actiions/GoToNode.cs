using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNode : ActionNode
{
    public Transform targetPoint;
    public float speed;
    public Animator animator;

    public GoToNode(Transform _targetPoint, float _speed, BehaviourTreeRunner _treeRunner, Animator _animator)
    {
        targetPoint = _targetPoint;
        speed = _speed;
        treeRunner = _treeRunner;
        animator = _animator;
    }
    
    public GoToNode(Transform _targetPoint, float _speed, BehaviourTreeRunner _treeRunner)
    {
        targetPoint = _targetPoint;
        speed = _speed;
        treeRunner = _treeRunner;
    }
    protected override void OnStart()
    {
        if (animator)
        {
            animator.SetBool("Walking", true);
        }
    }

    protected override State OnUpdate()
    {
        if ((treeRunner.transform.position - targetPoint.position).magnitude >= 0.3f)
        {
            Vector3 direction = (targetPoint.position - treeRunner.transform.position).normalized;
            treeRunner.transform.position += direction * speed * Time.deltaTime;
            return State.Running;
        }

        return State.Success;
    }

    protected override void OnStop()
    {
        animator.SetBool("Walking", false);
    }
}
