using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTestBehaviourTree : BehaviourTreeRunner
{
    protected override void SetupTree()
    {
        RepeatNode repeatNode = new RepeatNode();
        bt.rootNode.child = repeatNode;

        SequencerNode sequencerNode = new SequencerNode();
        repeatNode.child = sequencerNode;
        
        DebugNode debugNode1 = new DebugNode("1");
        sequencerNode.children.Add(debugNode1);

        WaitNode waitNode = new WaitNode(3, true);
        sequencerNode.children.Add(waitNode);
        
        DebugNode debugNode2 = new DebugNode("2");
        sequencerNode.children.Add(debugNode2);
        sequencerNode.children.Add(waitNode);

        DebugNode debugNode3 = new DebugNode("3");
        sequencerNode.children.Add(debugNode3);
        sequencerNode.children.Add(waitNode);

    }
}
