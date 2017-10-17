using ASBDemo.Viewmodels;
using Telerik.Data.Core;

namespace ASBDemo.Models.Grouping
{
    public class DayGrouping : IKeyLookup
    {
        public object GetKey(object instance)
        {
            return ((AccountHistoryModel)instance).Model.TransferTime.Date.ToString("yyyy/MM/dd");
        }
    }
}