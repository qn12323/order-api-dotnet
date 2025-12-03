using System.ComponentModel;

namespace Domain.Constants.Status
{
    public enum OrderStatus
    {
        [Description("Chưa duyệt")]
        Pending,

        [Description("Đã duyệt")]
        Approved,

        [Description("Đã huỷ")]
        Cancelled,

        [Description("Hoàn thành")]
        Completed,

        [Description("Đã trả hàng")]
        Returned
    }
}
