using System.ComponentModel;

namespace SPA.DocumentManager.Plans
{
    public enum UnitType
    {
        [Description("项")]
        Xiang = 0,
        [Description("幅")]
        Fu = 1,
        [Description("平方千米")]
        SquareKilometre = 2
    }
}
