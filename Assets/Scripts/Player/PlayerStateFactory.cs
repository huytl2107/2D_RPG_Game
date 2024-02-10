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
}