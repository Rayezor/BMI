using System.ComponentModel.DataAnnotations;

namespace BMI.Models
{
    public class BMIs
    {
        [Required]
        [Display(Name = "Weight (in stone)")]
        [Range(5, int.MaxValue, ErrorMessage = "Weight must be 5 pounds or more")]
        public int Stone { get; set; }
        public int Pounds { get; set; }
        [Required]
        [Display(Name = "Height (in feet)")]
        [Range(4, int.MaxValue, ErrorMessage = "Height must be 4 feet or more")]
        public int Feet {  get; set; }
        public int Inches { get; set; }
        public double WeightInStone
        {
            get
            {
                double weightInStone = 0;
                weightInStone = Stone + (Pounds * 0.07142857);
                return Math.Round(weightInStone, 2);
            }
        }
        public double HeightInFeet
        {
            get
            {
                double heightInFeet = 0;
                heightInFeet = Feet + (Inches * 0.08333333);
                return Math.Round(heightInFeet, 2);
            }
        }
        public double WeightInKg
        {
            get
            {
                double weightInKg = 0;
                weightInKg = WeightInStone * 6.35029318;
                return Math.Round(weightInKg, 2);
            }
        }
        public double HeightInM
        {
            get
            {
                double heightInM = 0;
                heightInM = HeightInFeet * 0.3048;
                return Math.Round(heightInM, 2);
            }
        }
        public double BodyMassIndex
        {
            get
            {
                double bmi = 0;
                bmi = WeightInKg / (HeightInM * HeightInM);
                return Math.Round(bmi, 1);
            }
        }
        private string bmiCat;
        [Display(Name = "BMI Category")]
        public string BMICat
        {
            get
            {
                if (BodyMassIndex <= 18.4)
                {
                    bmiCat = "Underweight";
                }
                else if (BodyMassIndex <= 24.9)
                {
                    bmiCat = "Normal";
                }
                else if (BodyMassIndex <= 29.9)
                {
                    bmiCat = "Overweight";
                }
                else
                {
                    bmiCat = "Obese";
                }
                return bmiCat;
            }
            set { }
        }
        private string bmiAdvice;
        public string BMIAdvice
        {
            get
            {
                if (BMICat == "Underweight")
                {
                    bmiAdvice = "Add some weight to gain a healthy BMI";
                }
                else if (BodyMassIndex <= 24.9)
                {
                    bmiAdvice = "You have a normal BMI";
                }
                else if (BodyMassIndex <= 29.9)
                {
                    bmiAdvice = "Lose some weight to gain a healthy BMI";
                }
                else
                {
                    bmiAdvice = "Things you can do to manage obesity include: " +
                        "getting good quality sleep, " +
                        "looking after your mental health, " +
                        "healthy eating, " +
                        "being active, " +
                        "managing other health conditions you have.";
                }
                return bmiAdvice;
            }
            set { }
        }
    }
}
