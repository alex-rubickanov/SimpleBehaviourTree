using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryOpenDoorNode : ActionNode
{
    private Animator animator;
    private int chanceToOpen;
    private Transform door;
    private bool isSuccess;
    
    public TryOpenDoorNode(int _chanceToOpen, Animator _animator, Transform _door)
    {
        chanceToOpen = _chanceToOpen;
        animator = _animator;
        door = _door;
    }
    
    protected override void OnStart()
    {
        int random = Random.Range(0, 101);
        if (random <= chanceToOpen)
        {
            isSuccess = true;
        }
        else
        {
            isSuccess = false;
        }
    }

    protected override State OnUpdate()
    {
        if (isSuccess)
        {
            
            animator.SetTrigger("SucceedOpenDoor");
            
            door.eulerAngles = new Vector3(0, 90, 0);
            Debug.Log(isSuccess);
            return State.Success;
        }
        else
        {
            Debug.Log(isSuccess);
            animator.SetTrigger("FailedOpenDoor");
            return State.Failure;
        }
    }

    protected override void OnStop()
    {
        
    }
}
