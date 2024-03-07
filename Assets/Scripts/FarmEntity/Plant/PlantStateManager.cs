using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateManager : FarmEntity
{
    private PlantBaseState _currentState;

    public PlantNonGrownState NonGrownState;
    public PlantGrownState GrownState;

    [SerializeField] private int _timeToGrown;

    public PlantBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public int TimeToGrown { get => _timeToGrown; set => _timeToGrown = value; }

    public override void Awake()
    {
        base.Awake();

        //Khởi tạo State
        NonGrownState = new PlantNonGrownState();
        GrownState = new PlantGrownState();
    }

    void Start()
    {
        CurrentState = NonGrownState;
        CurrentState.EnterState(this);
    }

    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(PlantBaseState state)
    {
        CurrentState = state;
        CurrentState.EnterState(this);
    }


}
