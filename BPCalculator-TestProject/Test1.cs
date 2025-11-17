using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BPCalculator;

namespace BPCalculator_TestProject
{
    [TestClass]
    public class BloodPressureTests
    {
        #region Low Blood Pressure Tests

        [TestMethod]
        [TestCategory("Low")]
        public void Category_SystolicBelow90_ReturnsLow()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 85, Diastolic = 60 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Low, category);
        }

        [TestMethod]
        [TestCategory("Low")]
        public void Category_DiastolicBelow60_ReturnsLow()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 100, Diastolic = 55 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Low, category);
        }

        [TestMethod]
        [TestCategory("Low")]
        public void Category_BothLowValues_ReturnsLow()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 85, Diastolic = 55 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Low, category);
        }

        [TestMethod]
        [TestCategory("Low")]
        public void Category_MinimumValues_ReturnsLow()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 70, Diastolic = 40 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Low, category);
        }

        #endregion

        #region Ideal Blood Pressure Tests

        [TestMethod]
        [TestCategory("Ideal")]
        public void Category_IdealRange_ReturnsIdeal()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 110, Diastolic = 70 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        [TestMethod]
        [TestCategory("Ideal")]
        public void Category_LowerBoundaryIdeal_ReturnsIdeal()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 90, Diastolic = 60 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        [TestMethod]
        [TestCategory("Ideal")]
        public void Category_UpperBoundaryIdeal_ReturnsIdeal()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 119, Diastolic = 79 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        [TestMethod]
        [TestCategory("Ideal")]
        public void Category_MidRangeIdeal_ReturnsIdeal()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 105, Diastolic = 68 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        #endregion

        #region Pre-High Blood Pressure Tests

        [TestMethod]
        [TestCategory("PreHigh")]
        public void Category_SystolicInPreHighRange_ReturnsPreHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 130, Diastolic = 75 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [TestMethod]
        [TestCategory("PreHigh")]
        public void Category_DiastolicInPreHighRange_ReturnsPreHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 115, Diastolic = 85 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [TestMethod]
        [TestCategory("PreHigh")]
        public void Category_LowerBoundaryPreHigh_ReturnsPreHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 120, Diastolic = 70 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [TestMethod]
        [TestCategory("PreHigh")]
        public void Category_UpperBoundaryPreHigh_ReturnsPreHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 139, Diastolic = 89 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [TestMethod]
        [TestCategory("PreHigh")]
        public void Category_DiastolicAt80_ReturnsPreHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 110, Diastolic = 80 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        #endregion

        #region High Blood Pressure Tests

        [TestMethod]
        [TestCategory("High")]
        public void Category_SystolicAt140OrAbove_ReturnsHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 140, Diastolic = 75 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        [TestMethod]
        [TestCategory("High")]
        public void Category_DiastolicAt90OrAbove_ReturnsHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 115, Diastolic = 90 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        [TestMethod]
        [TestCategory("High")]
        public void Category_BothHigh_ReturnsHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 160, Diastolic = 95 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        [TestMethod]
        [TestCategory("High")]
        public void Category_MaximumValues_ReturnsHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 190, Diastolic = 100 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        [TestMethod]
        [TestCategory("High")]
        public void Category_VerySystolicHigh_ReturnsHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 180, Diastolic = 70 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        #endregion

        #region Validation Tests

        [TestMethod]
        [TestCategory("Validation")]
        [ExpectedException(typeof(ArgumentException))]
        public void Category_SystolicEqualsToDiastolic_ThrowsException()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 100, Diastolic = 100 };

            // Act
            var category = bp.Category;

            // Assert - Exception expected
        }

        [TestMethod]
        [TestCategory("Validation")]
        [ExpectedException(typeof(ArgumentException))]
        public void Category_SystolicLessThanDiastolic_ThrowsException()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 80, Diastolic = 90 };

            // Act
            var category = bp.Category;

            // Assert - Exception expected
        }

        [TestMethod]
        [TestCategory("Validation")]
        public void Category_SystolicOneAboveDiastolic_ValidCalculation()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 91, Diastolic = 90 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        #endregion

        #region Boundary Tests

        [TestMethod]
        [TestCategory("Boundary")]
        [DataRow(89, 65, BPCategory.Low)]
        [DataRow(90, 60, BPCategory.Ideal)]
        [DataRow(119, 79, BPCategory.Ideal)]
        [DataRow(120, 70, BPCategory.PreHigh)]
        [DataRow(139, 79, BPCategory.PreHigh)]
        [DataRow(140, 75, BPCategory.High)]
        public void Category_BoundaryValues_ReturnsCorrectCategory(int systolic, int diastolic, BPCategory expected)
        {
            // Arrange
            var bp = new BloodPressure { Systolic = systolic, Diastolic = diastolic };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(expected, category);
        }

        [TestMethod]
        [TestCategory("Boundary")]
        [DataRow(100, 59, BPCategory.Low)]
        [DataRow(100, 60, BPCategory.Ideal)]
        [DataRow(100, 79, BPCategory.Ideal)]
        [DataRow(100, 80, BPCategory.PreHigh)]
        [DataRow(100, 89, BPCategory.PreHigh)]
        [DataRow(100, 90, BPCategory.High)]
        public void Category_DiastolicBoundaries_ReturnsCorrectCategory(int systolic, int diastolic, BPCategory expected)
        {
            // Arrange
            var bp = new BloodPressure { Systolic = systolic, Diastolic = diastolic };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(expected, category);
        }

        #endregion

        #region Edge Case Tests

        [TestMethod]
        [TestCategory("EdgeCase")]
        public void Category_Example100Over80_ReturnsIdeal()
        {
            // Arrange - Example from specification
            var bp = new BloodPressure { Systolic = 100, Diastolic = 80 };

            // Act
            var category = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [TestMethod]
        [TestCategory("EdgeCase")]
        public void Category_MultipleCalls_ReturnsSameResult()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 110, Diastolic = 70 };

            // Act
            var category1 = bp.Category;
            var category2 = bp.Category;
            var category3 = bp.Category;

            // Assert
            Assert.AreEqual(category1, category2);
            Assert.AreEqual(category2, category3);
        }

        #endregion
    }
}