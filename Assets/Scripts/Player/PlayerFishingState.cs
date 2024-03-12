using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishingState : PlayerBaseState
{
    private float _lifeTime;

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
        _lifeTime += Time.deltaTime;
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void CheckSwitchState()
    {
        // Tạm check như vầy để test;
        if(_lifeTime >= 3f)
        {
            SwitchState(factory.Idle());
        }
    }

    public override void ExitState()
    {
        _lifeTime = 0;
    }
}