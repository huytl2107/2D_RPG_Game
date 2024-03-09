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
        CheckAndChoseAnim();
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
        if(_lifeTime >= 0.4f)
        {
            SwitchState(factory.Idle());
        }
    }

    public override void ExitState()
    {

    }

    public void CheckAndChoseAnim()
    {
        if(player.OnPlantingArea)
        {
            player.Anim.SetInteger("State", (int)GameEnum.EPlayerState.seeding);
            GameObjectPrefab.Instance.GetPoolObject(GameEnum.EObjectPrefab.pumkimPrefab, player.transform.position);
        }
        else
        {
            Debug.Log("Cuoocs ddaast broo");
            player.Anim.SetInteger("State", (int)GameEnum.EPlayerState.plowing);
        }
    }
}