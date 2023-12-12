using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    public RootNode rootNode;
    public List<Node> nodes = new List<Node>();
    public Node.State treeState;

    public BehaviourTree()
    {
        this.rootNode = new RootNode();
    }

    public Node.State Update()
    {
        if (rootNode.state == Node.State.Running)
        {
            treeState = rootNode.Update();
        }

        return treeState;
    }
    
    
}
