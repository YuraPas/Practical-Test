using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class PressureSensor : IPressureSensor
    {
        protected const double PressureOffset = 16;

        private static Random _pressureSampleSimulator;

        public PressureSensor()
        {
            _pressureSampleSimulator = new Random();
        }

        public double GetPressurePsi()
        {
            double pressureTelemetryValue = GetTirePressureIndicator();

            return PressureOffset + pressureTelemetryValue;
        }

        private double GetTirePressureIndicator()
        {
            return 6 * _pressureSampleSimulator.NextDouble() * _pressureSampleSimulator.NextDouble();
        }
    }
}