using System.ComponentModel;

namespace Domain.Constants.Status
{
    public enum PaymentStatus
    {
        [Description("Chưa thanh toán")]
        Unpaid,

        [Description("Đã thanh toán")]
        Paid,

        [Description("Hoàn tiền")]
        Refunded
    }
}
