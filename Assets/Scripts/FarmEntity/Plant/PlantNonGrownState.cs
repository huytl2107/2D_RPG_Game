using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantNonGrownState : PlantBaseState
{
    private float _lifeTime;

    public override void EnterState(PlantStateManager plant)
    {
        Debug.Log("Chaoo taoo laa NonGrownnState");
        plant.Anim.SetInteger("State", (int)GameEnum.EPlantState.nonGrown1);
    }

    public override void UpdateState(PlantStateManager plant)
    {
        base.UpdateState(plant);
        _lifeTime += Time.deltaTime;
        SwitchAnim(plant);
    }

    public override void CheckSwitchState(PlantStateManager plant)
    {
        if (_lifeTime > plant.TimeToGrown)
        {
            _lifeTime = 0;
            plant.SwitchState(plant.GrownState);
        }
    }

    public override void OnCollisionEnter2D(PlantStateManager plant)
    {

    }

    public void SwitchAnim(PlantStateManager plant)
    {
        float timeFraction = _lifeTime / plant.TimeToGrown;
        int state = 0;

        if (timeFraction > 0.75f)
        {
            state = (int)GameEnum.EPlantState.nonGrown4;
        }
        else if (timeFraction > 0.5f)
        {
            state = (int)GameEnum.EPlantState.nonGrown3;
        }
        else if (timeFraction > 0.25f)
        {
            state = (int)GameEnum.EPlantState.nonGrown2;
        }
        
        plant.Anim.SetInteger("State", state);
    }
}
