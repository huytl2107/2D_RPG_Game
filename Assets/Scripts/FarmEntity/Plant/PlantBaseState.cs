public abstract class PlantBaseState
{
    public abstract void EnterState(PlantStateManager plant);
    public virtual void UpdateState(PlantStateManager plant)
    {
        CheckSwitchState(plant);
    }
    public abstract void OnCollisionEnter2D(PlantStateManager plant);
    public abstract void CheckSwitchState(PlantStateManager plant);
}
