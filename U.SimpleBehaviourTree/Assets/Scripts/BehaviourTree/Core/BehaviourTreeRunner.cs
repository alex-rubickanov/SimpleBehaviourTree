using UnityEngine;

public abstract class BehaviourTreeRunner : MonoBehaviour
{
    protected BehaviourTree bt = new BehaviourTree();

    private void Awake()
    {
        SetupTree();
    }

    private void Update()
    {
        bt.Update();
    }

    protected void Bind()
    {
        foreach (var node in bt.nodes)
        {
            Debug.Log($"Node: {node} --- TreeRunner: {this}");
            node.treeRunner = this;
        }
    }

    protected abstract void SetupTree();
}
