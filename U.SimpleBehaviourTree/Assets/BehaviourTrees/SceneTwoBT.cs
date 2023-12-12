using UnityEngine;

public class SceneTwoBT : BehaviourTreeRunner
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform pointOfWaiting;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;
    [SerializeField] private Death anotherRobot;
    
    protected override void SetupTree()
    {
        SequencerNode sequencerNode = new SequencerNode();
        bt.rootNode.child = sequencerNode;

        WaitAroundPointNode waitAroundPointNode = new WaitAroundPointNode(pointOfWaiting, targetTransform);
        sequencerNode.children.Add(waitAroundPointNode);

        GoToNode goToTarget = new GoToNode(pointOfWaiting, speed, this, animator);
        sequencerNode.children.Add(goToTarget);

        WaitNode waitNode = new WaitNode(3, true);
        sequencerNode.children.Add(waitNode);

        HitNode hit = new HitNode(anotherRobot, animator);
        sequencerNode.children.Add(hit);
    }
}
