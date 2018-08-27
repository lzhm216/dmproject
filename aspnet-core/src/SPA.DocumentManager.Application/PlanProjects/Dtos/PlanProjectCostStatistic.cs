using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectCostStatistic
    {

        public PlanProjectCostStatistic()
        {

        }

        public PlanProjectCostStatistic(string year, List<PlanProjectAndCost> items)
        {
            Year = year;
            this.items = items;
        }

        public PlanProjectCostStatistic(string year, double totalCost, List<PlanProjectAndCost> items)
        {
            Year = year;
            TotalCost = totalCost;
            this.items = items;
        }

        public string Year { get; set; }

        public double TotalCost { get; set; }

        public List<PlanProjectAndCost> items { get; set; }

    }

    public class PlanProjectAndCost
    {
        public PlanProjectAndCost()
        {
        }

        public PlanProjectAndCost(int planProjectTypeId, string planProjectTypeName, double totalCost, int count)
        {
            PlanProjectTypeId = planProjectTypeId;
            PlanProjectTypeName = planProjectTypeName;
            TotalCost = totalCost;
            Count = count;
        }


        public int PlanProjectTypeId { get; set; }

        public string PlanProjectTypeName { get; set; }

        public double TotalCost { get; set; }

        public int Count { get; set; }

        public double Percent { get; set; }
    }
}
