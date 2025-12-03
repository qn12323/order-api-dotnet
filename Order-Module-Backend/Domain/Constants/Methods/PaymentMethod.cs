using System.ComponentModel;

namespace Domain.Constants.Methods
{
    public enum PaymentMethod
    {
        [Description("Thanh toán khi nhận hàng")]
        COD,

        [Description("Thẻ tín dụng / Thẻ ghi nợ")]
        CreditCard,

        [Description("Thanh toán VNPay")]
        VNPay
    }
}
