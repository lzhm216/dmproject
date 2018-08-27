using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class SpecialPlanCostStatistic
    {
        public string Year { get; set; }

        public double TotalCost { get; set; }

        public List<SpecialPlanAndCost> items { get; set; }
    }

    public class SpecialPlanAndCost
    {
        public SpecialPlanAndCost()
        {
        }

        public SpecialPlanAndCost(int specialPlanTypeId, string specialPlanTypeName, double totalCost, int count, double percent)
        {
            SpecialPlanTypeId = specialPlanTypeId;
            SpecialPlanTypeName = specialPlanTypeName;
            TotalCost = totalCost;
            Count = count;
            Percent = percent;
        }

        public int SpecialPlanTypeId { get; set; }

        public string SpecialPlanTypeName { get; set; }

        public double TotalCost { get; set; }

        public int Count { get; set; }

        public double Percent { get; set; }
    }
}
