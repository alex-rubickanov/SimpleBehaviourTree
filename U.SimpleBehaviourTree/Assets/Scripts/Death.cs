using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animator;
    private SceneOneBT bt;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        bt = GetComponent<SceneOneBT>();
    }

    public void Die()
    {
        bt.enabled = false;
        animator.SetTrigger("Die");
    }
}
