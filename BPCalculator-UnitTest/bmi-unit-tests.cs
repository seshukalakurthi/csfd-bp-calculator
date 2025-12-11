using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BPCalculator_UnitTest
{
    [TestClass]
    public class BmiTests
    {
        [TestMethod]
        public void BMI_Normal_When_Height170_Weight65()
        {
            var bp = new BloodPressure
            {
                HeightCm = 170,
                WeightKg = 65
            };

            Assert.AreEqual(22.5, bp.BMI);
            Assert.AreEqual(BMICategory.Normal, bp.BMICategory);
        }

        [TestMethod]
        public void BMI_Underweight_When_Height180_Weight55()
        {
            var bp = new BloodPressure
            {
                HeightCm = 180,
                WeightKg = 55
            };

            Assert.AreEqual(BMICategory.Underweight, bp.BMICategory);
        }

        [TestMethod]
        public void BMI_Obese_When_Height160_Weight95()
        {
            var bp = new BloodPressure
            {
                HeightCm = 160,
                WeightKg = 95
            };

            Assert.AreEqual(BMICategory.Obese, bp.BMICategory);
        }
    }
}
