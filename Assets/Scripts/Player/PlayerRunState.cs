using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Tao la run");
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        player.Rb.velocity = new Vector2(player.DirX, player.DirY).normalized * player.MoveSpeed;
    }

    public override void CheckSwitchState()
    {
        if(player.DirX == 0 && player.DirY == 0)
        {
            SwitchState(factory.Idle());
        } 
    }

    public override void ExitState()
    {

    }
}
