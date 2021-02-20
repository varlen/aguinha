using System;
using System.Collections.Generic;
using System.Text;

using Aguinha.Models;

namespace Aguinha.Contexts
{
    public class WaterIntakeContext
    {
        public List<Glass> Glasses = new List<Glass>{
            new Glass {
                Name = "Copo Americano",
                CapacityMililiters = 200,
                Image = new Uri("/Images/copo americano.jpg", UriKind.Relative)
            },
            new Glass
            {
                Name = "Copão",
                CapacityMililiters = 350,
                Image = new Uri("/Images/pint.jpg", UriKind.Relative)
            }
        };
        public Glass Glass { get; set; }
        
        public IntakeMililiters Intake { get; set; }

        public WaterIntakeContext()
        {
            Intake = new IntakeMililiters
            {
                Goal = 2500,
                Current = 0
            };

            Glass = Glasses[0];
        }

        public void Drink()
        {
            if (Glass != null && Intake != null)
                Intake.Current += Glass.CapacityMililiters;
        }
    }
}
