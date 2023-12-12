using UnityEngine;

public class SmashDoorNode : ActionNode
{
    private Animator animator;
    private Transform door;

    public SmashDoorNode(Transform _door, Animator _animator)
    {
        door = _door;
        animator = _animator;
    }
    protected override void OnStart()
    {
        animator.SetTrigger("SmashDoor");
        door.position += new Vector3(0, -10, 0);
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    protected override void OnStop()
    {
        
    }
}
