using UnityEngine;

public class WaitAroundPointNode : ActionNode
{
    private Transform targetTransform;
    private Transform pointOfWaiting;

    public WaitAroundPointNode(Transform _pointOfWaiting, Transform _targetTransform)
    {
        pointOfWaiting = _pointOfWaiting;
        targetTransform = _targetTransform;
    }
    
    protected override void OnStart()
    {
        
    }

    protected override State OnUpdate()
    {
        if ((pointOfWaiting.position - targetTransform.position).magnitude >= 0.5f)
        {
            return State.Running;
        }
        else
        {
            return State.Success;
        }
    }

    protected override void OnStop()
    {
        
    }
}
