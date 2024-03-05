using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFarmingState : PlayerBaseState
{
    private float _lifeTime;

    public PlayerFarmingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Tao la farming");
        player.Rb.velocity = new Vector2(0f, 0f);
        player.Anim.SetInteger("State", (int)GameEnum.EPlayerState.farming);
        GameObjectPrefab.Instance.GetPlantingArea(player.transform.position);
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
        if(_lifeTime >= 0.3f)
        {
            SwitchState(factory.Idle());
        }
    }

    public override void ExitState()
    {

    }
}