using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrownState : PlantBaseState
{
    public override void EnterState(PlantStateManager plant)
    {
        Debug.Log("Chaoo taoo laa GrownnState");
        plant.Anim.SetInteger("State", (int)GameEnum.EPlantState.grown);
    }
    
    public override void UpdateState(PlantStateManager plant)
    {
        base.UpdateState(plant);
        plant.Anim.SetInteger("State", (int)GameEnum.EPlantState.grown);
    }

    public override void CheckSwitchState(PlantStateManager plant)
    {

    }

    public override void OnCollisionEnter2D(PlantStateManager plant)
    {

    }
}
