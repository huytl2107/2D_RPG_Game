using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishingState : PlayerBaseState
{
    public PlayerFishingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Tao la fishing");
        player.Rb.velocity = new Vector2(0f, 0f);
        player.Anim.SetInteger("State", (int)GameEnum.EPlayerState.fishing);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void CheckSwitchState()
    {
        //Tạm bỏ đó :v
    }

    public override void ExitState()
    {

    }
}