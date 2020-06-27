using Moq;
using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem.TirePressureMonitoringSystem.Tests
{
    [TestFixture]
    public class TirePressureMonitoringSystemTests
    {
        public const double LowPressureThreshold = 17;

        public const double HighPressureThreshold = 21;

        [Test]
        public void IsAlarmOn_PsiPressureGreaterThanHighPressureThreshold_True()
        {
          // Arrange
          var pressureOffset = 10;
          var mockPressureSensor = new Mock<IPressureSensor>();
          mockPressureSensor.Setup(m => m.GetPressurePsi()).Returns(HighPressureThreshold + pressureOffset);
          var tirePressureAlarm = new TirePressureAlarm(mockPressureSensor.Object);

          // Act
          var isAlarmOn = tirePressureAlarm.IsTireAlarmOn();

          // Assert
          Assert.True(isAlarmOn);
        }

        [Test]
        public void IsAlarmOn_PsiPressureLessThanLowPressureThreshold_True()
        {
            // Arrange
            var pressureOffset = 10;
            var mockPressureSensor = new Mock<IPressureSensor>();
            mockPressureSensor.Setup(m => m.GetPressurePsi()).Returns(LowPressureThreshold - pressureOffset);
            var tirePressureAlarm = new TirePressureAlarm(mockPressureSensor.Object);

            // Act
            var isAlarmOn = tirePressureAlarm.IsTireAlarmOn();

            // Assert
            Assert.True(isAlarmOn);
        }

        [Test]
        public void IsAlarmOn_PsiPressureLessThanHighPressureAndGreaterThanLowPressure_False()
        {
            // Arrange
            var mockPressureSensor = new Mock<IPressureSensor>();
            mockPressureSensor.Setup(m => m.GetPressurePsi())
                              .Returns((HighPressureThreshold + LowPressureThreshold)/2);
            var tirePressureAlarm = new TirePressureAlarm(mockPressureSensor.Object);

            // Act
            var isAlarmOn = tirePressureAlarm.IsTireAlarmOn();

            // Assert
            Assert.False(isAlarmOn);
        }
    }
}
