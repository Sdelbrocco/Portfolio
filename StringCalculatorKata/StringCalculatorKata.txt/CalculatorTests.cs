using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.txt
{
    [TestFixture]
    class CalculatorTests
    {
        [Test]
        public void Step1_NoParameters()
        {
            Calculator calc = new Calculator();
            int result = calc.Add("");

            Assert.AreEqual(0, result);
        }

        [TestCase("",0)]
        [TestCase("1", 1)]
        [TestCase("17", 17)]
        public void Step1_OneParameter(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2", 3)]
        [TestCase("1234, 10000", 11234)]
        public void Step1_TwoParameters(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        [TestCase("1, 2, 3, 4", 10)]
        [TestCase("1\n2, 3", 6)]
        public void Step2(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        [TestCase("//;\n1;2",3)]
        [TestCase("//|\n1|2", 3)]
        public void Step4(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        [TestCase("-1,2", "Negatives not allowed: -1")]
        [TestCase("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void step5(string numbers, string expected)
        {
            Calculator calc = new Calculator();
            try
            {
                int result = calc.Add(numbers);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }
}
}
