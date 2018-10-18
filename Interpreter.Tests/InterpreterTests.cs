using System;
using Xunit;
using Moq;
using GangOfFour.Behaviorial;
using System.Collections;

namespace Interpreter.Tests
{
    public class InterpreterTests 
    {
        Circuit circuit = new Circuit();
        ArrayList list = new ArrayList();
        public InterpreterTests()
        {
            string resistorBand1 = "BR,RD,RD,RD";
            string resistorBand2 = "BR,RD,BK";

            circuit.AddResistor(resistorBand1);
            circuit.AddResistor(resistorBand2);

            list.Add(new SeriesExpression());
            list.Add(new ParallelExpression());
        }

        [Fact]
        public void CanCalculateResitorInSeriesCircuit()
        {
            Expression exp = (SeriesExpression)list[0]; 
            exp.Interpret(circuit);

            var expectedSeriesValue = exp.Series();
            Assert.Equal(expectedSeriesValue, 703);
        }
        [Fact]
        public void CanCalculateResitorInParallelCircuit()
        {
            Expression exp = (ParallelExpression)list[1]; 
            exp.Interpret(circuit);
            double expectedParallelValue = exp.Parallel();
            Assert.Equal(expectedParallelValue, 2.99, 2);
        }
    }
}
