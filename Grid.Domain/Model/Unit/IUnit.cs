namespace Grid.Domain.Model
{
    public abstract class IUnit
    {
        public IUnit unit;
        public GridInfo gridInfo;

        public void SetUnit(IUnit unit)
        {
            this.unit = unit;
            unit.Execute(gridInfo);
        }

        public abstract void Execute(GridInfo gridInfo);
    }

    public class BaseGridUnit : IUnit
    {
        public BaseGridUnit(GridInfo gridInfo)
        {
            this.gridInfo = gridInfo;
        }

        public override void Execute(GridInfo gridInfo)
        {
            unit.Execute(gridInfo);
        }
    }    
}
