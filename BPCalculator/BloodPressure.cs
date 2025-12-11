using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")] Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High
    };

    // BMI categories
    public enum BMICategory
    {
        [Display(Name = "Underweight")] Underweight,
        [Display(Name = "Normal")] Normal,
        [Display(Name = "Overweight")] Overweight,
        [Display(Name = "Obese")] Obese
    };

    public class BloodPressure : IValidatableObject
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // Optional BMI inputs
        [Range(50, 250, ErrorMessage = "Invalid Height (cm)")]
        [Display(Name = "Height in cm")]
        public double? HeightCm { get; set; }

        [Range(20, 300, ErrorMessage = "Invalid Weight (kg)")]
        [Display(Name = "Weight in Kgs")]
        public double? WeightKg { get; set; }

        // Custom validation: systolic must be greater than diastolic
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Systolic <= Diastolic)
            {
                yield return new ValidationResult(
                    "Systolic value must be greater than Diastolic value",
                    new string[] { }
                );
            }
        }

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                if (Systolic >= 140 || Diastolic >= 90)
                    return BPCategory.High;

                if ((Systolic >= 120 && Systolic <= 139) ||
                    (Diastolic >= 80 && Diastolic <= 89))
                    return BPCategory.PreHigh;

                if (Systolic >= 90 && Systolic <= 119 &&
                    Diastolic >= 60 && Diastolic <= 79)
                    return BPCategory.Ideal;

                return BPCategory.Low;
            }
        }

        // calculate BMI (optional)
        public double BMI =>
            (HeightCm.HasValue && HeightCm.Value > 0 && WeightKg.HasValue)
                ? Math.Round(WeightKg.Value / Math.Pow(HeightCm.Value / 100.0, 2), 1)
                : 0;

        public BMICategory BMICategory =>
            BMI < 18.5 ? BMICategory.Underweight :
            BMI < 25 ? BMICategory.Normal :
            BMI < 30 ? BMICategory.Overweight : BMICategory.Obese;
    }
}
