using ASBDemo.Enums;

namespace ASBDemo.Models.Transactions
{
    public class MaintenanceTransaction : ITransactionProvider
    {
        public MaintenanceType Type { get; set; }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}