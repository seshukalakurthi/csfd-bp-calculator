using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Reqnroll;

using BPCalculator;

namespace BPCalculator_BDDTest.Steps
{
    [Binding]
    public class BmiSteps
    {
        private BloodPressure bp;

        [Given(@"a height of (.*) cm")]
        public void GivenAHeightOf(double height)
        {
            bp = bp ?? new BloodPressure();
            bp.HeightCm = height;
        }

        [Given(@"a weight of (.*) kg")]
        public void GivenAWeightOf(double weight)
        {
            bp = bp ?? new BloodPressure();
            bp.WeightKg = weight;
        }

        [When(@"I calculate the BMI")]
        public void WhenICalculateTheBMI()
        {
            // BMI is calculated via property, no explicit action needed
        }

        [Then(@"the BMI value should be (.*)")]
        public void ThenTheBMIValueShouldBe(double expected)
        {
            Assert.AreEqual(expected, bp.BMI);
        }

        [Then(@"the BMI category should be ""(.*)""")]
        public void ThenTheBMICategoryShouldBe(string expected)
        {
            Assert.AreEqual(expected, bp.BMICategory.ToString());
        }
    }
}
