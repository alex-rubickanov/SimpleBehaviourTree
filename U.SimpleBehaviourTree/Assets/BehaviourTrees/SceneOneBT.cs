using UnityEngine;
using UnityEngine.Serialization;

public class SceneOneBT : BehaviourTreeRunner
{
    [SerializeField] private Transform doorTarget;
    [SerializeField] private Transform afterDoorTarget;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform door;
    
    [SerializeField] private float speed;
    [SerializeField] private int chanceToOpen;
    
    private const string WALKING = "Walking";
    private const string IDLE = "Idle";
    
    protected override void SetupTree()
    {
        SequencerNode sequencer = new SequencerNode();
        bt.rootNode.child = sequencer;
        
        GoToNode goToNode = new GoToNode(doorTarget, speed, this, animator);
        sequencer.children.Add(goToNode);

        WaitNode waitNodeTrue = new WaitNode(4, true);
        sequencer.children.Add(waitNodeTrue);

        SelectorNode selectorNode = new SelectorNode();
        sequencer.children.Add(selectorNode);

        TryOpenDoorNode tryOpenDoorNode = new TryOpenDoorNode(chanceToOpen, animator, door);
        selectorNode.children.Add(tryOpenDoorNode);

        WaitNode waitNodeFalse = new WaitNode(4, false);
        selectorNode.children.Add(waitNodeFalse);

        SmashDoorNode smashDoorNode = new SmashDoorNode(door, animator);
        selectorNode.children.Add(smashDoorNode);
        
        sequencer.children.Add(waitNodeTrue);
        
        GoToNode walkThroughTheDoor = new GoToNode(afterDoorTarget, speed, this, animator);
        sequencer.children.Add(walkThroughTheDoor);
    }
}
