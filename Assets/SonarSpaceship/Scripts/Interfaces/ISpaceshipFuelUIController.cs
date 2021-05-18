namespace SonarSpaceship
{
    public interface ISpaceshipFuelUIController
    {
        float CurrentFuel { get; }

        float MaximalFuelCapacity { get; }

        float FuelRatio { get; }

        event FuelRatioChangedDelegate OnFuelRatioChanged;
    }
}
