using Modeling;
using Moq;
using Xunit;

namespace Test
{
    public class SimulationTest
    {
        [Fact]
        public void ForwardSimulation()
        {
            var mockSource = new Mock<ISource>(MockBehavior.Strict);
            var mockSeismogram = new Mock<ISeismogram>(MockBehavior.Strict);
            var simulation = new Simulation(mockSource.Object, mockSeismogram.Object);

            mockSource.Setup(s => s.Sample(It.IsInRange(0.09, 0.11, Range.Exclusive))).Returns(1).Verifiable();
            mockSeismogram.Setup(s => s.Store(It.IsInRange(0.09, 0.11, Range.Exclusive), 1)).Verifiable();

            mockSource.Setup(s => s.Sample(It.IsInRange(0.14, 0.16, Range.Exclusive))).Returns(2).Verifiable();
            mockSeismogram.Setup(s => s.Store(It.IsInRange(0.14, 0.16, Range.Exclusive), 2)).Verifiable();

            mockSource.Setup(s => s.Sample(It.IsInRange(0.19, 0.21, Range.Exclusive))).Returns(3).Verifiable();
            mockSeismogram.Setup(s => s.Store(It.IsInRange(0.19, 0.21, Range.Exclusive), 3)).Verifiable();

            simulation.Execute(0.1, 0.05, 0.2);

            mockSource.Verify();
            mockSeismogram.Verify();
        }

        [Fact]
        public void ReversalSimulation()
        {
            var mockSource = new Mock<ISource>(MockBehavior.Strict);
            var mockSeismogram = new Mock<ISeismogram>(MockBehavior.Strict);
            var simulation = new Simulation(mockSource.Object, mockSeismogram.Object);

            mockSource.Setup(s => s.Sample(It.IsInRange(0.19, 0.21, Range.Exclusive))).Returns(3).Verifiable();
            mockSeismogram.Setup(s => s.Store(It.IsInRange(0.19, 0.21, Range.Exclusive), 3)).Verifiable();

            mockSource.Setup(s => s.Sample(It.IsInRange(0.14, 0.16, Range.Exclusive))).Returns(2).Verifiable();
            mockSeismogram.Setup(s => s.Store(It.IsInRange(0.14, 0.16, Range.Exclusive), 2)).Verifiable();

            mockSource.Setup(s => s.Sample(It.IsInRange(0.09, 0.11, Range.Exclusive))).Returns(1).Verifiable();
            mockSeismogram.Setup(s => s.Store(It.IsInRange(0.09, 0.11, Range.Exclusive), 1)).Verifiable();

            simulation.Execute(0.2, -0.05, 0.1);

            mockSource.Verify();
            mockSeismogram.Verify();
        }
    }
}