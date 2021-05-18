using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class SpaceshipFuelUIControllerScript : MonoBehaviour, ISpaceshipFuelUIController
    {
        [SerializeField]
        private UnityEvent<float> onFuelRatioChanged = default;

        public float CurrentFuel { get; private set; }

        public float MaximalFuelCapacity { get; private set; }

        public float FuelRatio { get; private set; }

        public event FuelRatioChangedDelegate OnFuelRatioChanged;

        private void Update()
        {
            float current_fuel = 0.0f;
            float maximal_fuel_capacity = 0.0f;
            foreach (SpaceshipControllerScript spaceship_controller in SpaceshipControllerScript.EnabledControllers)
            {
                current_fuel += spaceship_controller.Fuel;
                maximal_fuel_capacity += spaceship_controller.MaximalFuelCapacity;
            }
            if ((CurrentFuel != current_fuel) || (MaximalFuelCapacity != maximal_fuel_capacity))
            {
                CurrentFuel = current_fuel;
                MaximalFuelCapacity = maximal_fuel_capacity;
                FuelRatio = (MaximalFuelCapacity > float.Epsilon) ? Mathf.Clamp(current_fuel / maximal_fuel_capacity, 0.0f, 1.0f) : 0.0f;
                if (onFuelRatioChanged != null)
                {
                    onFuelRatioChanged.Invoke(FuelRatio);
                }
                OnFuelRatioChanged?.Invoke(FuelRatio);
            }
        }
    }
}
