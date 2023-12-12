using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : CompositeNode
{
    private int currentChildIndex;
    protected override void OnStart()
    {
        
    }

    protected override State OnUpdate()
    {
        for (int i = currentChildIndex; i < children.Count; ++i) {
            currentChildIndex = i;
            var child = children[currentChildIndex];

            switch (child.Update()) {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    continue;
                case State.Success:
                    return State.Success;
            }
        }

        return State.Success;
    }

    protected override void OnStop()
    {
        
    }
}
