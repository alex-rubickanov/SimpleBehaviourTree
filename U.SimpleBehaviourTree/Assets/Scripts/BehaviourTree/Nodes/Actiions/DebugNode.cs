using UnityEngine;

public class DebugNode : ActionNode
{
    public string message;
    
    public DebugNode(string _message)
    {
        message = _message;
    }
    
    
    protected override void OnStart()
    {
        Debug.Log($"OnStart: {message}");
    }

    protected override State OnUpdate()
    {
        Debug.Log($"OnUpdate: {message}");
        return State.Success;
    }

    protected override void OnStop()
    {
        Debug.Log($"OnStop: {message}");
    }
}
