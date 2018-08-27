namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class GetSpecialPlanCountInput
    {
          /// <summary>
		 /// 模糊搜索使用的关键字
		 ///</summary>
        public string Filter { get; set; }

        public int FilterSpecialPlanTypeId { get; set; }

        public string FilterYear { get; set; }

    }
}
