public class PlayerStateFactory
{
    PlayerStateManager _context;

    public PlayerStateFactory(PlayerStateManager currentContext)
    {
        _context = currentContext;
    }
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }
    public PlayerBaseState Run()
    {
        return new PlayerRunState(_context, this);
    }
    public PlayerBaseState Attack()
    {
        return new PlayerAttackState(_context, this);
    }
    public PlayerBaseState Farming()
    {
        return new PlayerFarmingState(_context, this);
    }
    public PlayerBaseState Fishing()
    {
        return new PlayerFishingState(_context, this);
    }
}