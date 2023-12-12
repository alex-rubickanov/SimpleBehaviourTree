public class RootNode : Node
{
    public Node child;
    
    protected override void OnStart()
    {
        
    }

    protected override State OnUpdate()
    {
        if (child != null)
        {
            return child.Update();
        }
        else
        {
            return State.Failure;
        }
    }

    protected override void OnStop()
    {
        
    }
}
