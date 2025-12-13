namespace Application.DTOs
{
    public class RevenueStatisticDto
    {
        // ===== ĐƠN HÀNG =====

        /// <summary>
        /// Tổng số đơn hàng (bao gồm mọi trạng thái)
        /// </summary>
        public int TotalOrderCount { get; set; }

        /// <summary>
        /// Số đơn hàng đã thanh toán
        /// </summary>
        public int PaidOrderCount { get; set; }

        /// <summary>
        /// Số đơn hàng đã hoàn tiền
        /// </summary>
        public int RefundedOrderCount { get; set; }


        // ===== DOANH THU =====

        /// <summary>
        /// Tổng doanh thu của tất cả đơn hàng
        /// (bao gồm cả chưa thanh toán và đã thanh toán)
        /// </summary>
        public decimal GrossRevenue { get; set; }

        /// <summary>
        /// Doanh thu thực tế đã thanh toán
        /// (chỉ tính các đơn đã PAID)
        /// </summary>
        public decimal PaidRevenue { get; set; }

        /// <summary>
        /// Tổng số tiền đã hoàn lại (refund)
        /// </summary>
        public decimal RefundedAmount { get; set; }


        // ===== SẢN PHẨM =====

        /// <summary>
        /// Tổng số lượng sản phẩm đã bán ra
        /// (chỉ tính các đơn đã thanh toán)
        /// </summary>
        public int TotalProductSold { get; set; }


        // ===== PHÂN TÍCH =====

        /// <summary>
        /// Doanh thu theo từng phương thức thanh toán
        /// (VD: COD, VNPay, PayPal, Stripe...)
        /// </summary>
        public List<RevenueByPaymentMethodDto> RevenueByPaymentMethod { get; set; }

        /// <summary>
        /// Doanh thu theo ngày / tháng (phục vụ biểu đồ)
        /// </summary>
        public List<RevenueByPeriodDto> RevenueByPeriod { get; set; }
    }

    public class RevenueByPeriodDto
    {
        public DateTime Period { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; }
    }

    public class RevenueByPaymentMethodDto
    {
        public string PaymentMethod { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; }
    }

}
