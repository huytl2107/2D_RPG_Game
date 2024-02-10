public abstract class PlayerBaseState
{
    protected PlayerStateManager player;
    protected PlayerStateFactory factory;

    public PlayerBaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    {
        player = currentContext;
        factory = playerStateFactory;
    }

    public abstract void EnterState();
    public virtual void UpdateState()
    {
        CheckSwitchState();
    }

    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void FixedUpdateState();

    protected void SwitchState(PlayerBaseState newState)
    {
        ExitState();
        newState.EnterState();
        player.CurrentState = newState;
    }
}
