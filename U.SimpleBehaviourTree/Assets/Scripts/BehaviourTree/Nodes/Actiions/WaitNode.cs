using UnityEngine;

public class WaitNode : ActionNode
{
    public float duration = 1;
    private float startTime;

    private bool boolOutput;

    public WaitNode(float _duration, bool _boolOutput)
    {
        duration = _duration;
        boolOutput = _boolOutput;
    }
    protected override void OnStart()
    {
        startTime = Time.time;
    }

    protected override State OnUpdate()
    {
        if (Time.time - startTime > duration)
        {
            if (boolOutput)
            {
                return State.Success;
            }
            else
            {
                return State.Failure;
            }
        }

        return State.Running;
    }

    protected override void OnStop()
    {
        
    }
}
