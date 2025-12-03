namespace Domain.Definitions.Messages
{
    public static class NotificationMessage
    {
        #region Order
        public const string SentRequest = "Đơn hàng #{0} đang chờ xác nhận";
        public const string ConfirmedRequest = "Đơn hàng #{0} đã được xác nhận";
        public const string Cancelled = "Đã huỷ thành công đơn hàng #{0}";
        public const string ReturnRequest = "Yêu cầu hoàn trả đơn hàng #{0} đã được gửi";
        public const string ReturnSuccess = "Yêu cầu hoàn trả đơn hàng #{0} đã được chấp nhận";
        #endregion

        #region Account

        #endregion
    }
}
