using System.ComponentModel;

namespace Domain.Constants.Status
{
    public enum OrderReturnStatus
    {
        [Description("Chờ duyệt")]
        Pending,

        [Description("Đã duyệt")]
        Approved,

        [Description("Từ chối")]
        Rejected,

        [Description("Hoàn tất")]
        Completed
    }
}
