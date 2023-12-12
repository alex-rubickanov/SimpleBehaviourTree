using UnityEngine;

public abstract class Node
{
    public BehaviourTreeRunner treeRunner;
    
    public enum State
    {
        Running,
        Failure,
        Success
    }
    
    [HideInInspector] public State state = State.Running;
    [HideInInspector] public bool started = false;

    public State Update()
    {
        if (!started)
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if (state is State.Failure or State.Success)
        {
            OnStop();
            started = false;
        }

        return state;
    }

    protected abstract void OnStart();
    protected abstract State OnUpdate();
    protected abstract void OnStop();
}
