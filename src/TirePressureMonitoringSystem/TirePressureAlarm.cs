namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class TirePressureAlarm
    {
        private const double LowPressureThreshold = 17;

        private const double HighPressureThreshold = 21;

        private IPressureSensor _pressureSensor;

        public TirePressureAlarm(IPressureSensor pressureSensor)
        {
            _pressureSensor = pressureSensor;
        }

        public bool IsTireAlarmOn()
        {
            var tirePsiPressure = _pressureSensor.GetPressurePsi();

            if (tirePsiPressure < LowPressureThreshold || tirePsiPressure > HighPressureThreshold)
            {
                return true;
            }

            return false;
        }
    }
}