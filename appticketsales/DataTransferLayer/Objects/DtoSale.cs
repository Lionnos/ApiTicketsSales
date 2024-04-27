namespace DataTransferLayer.Objects
{
    public class DtoSale
    {
        public string idSale { get; set; }
        public string idClient { get; set; }
        public string serie { get; set; }
        public DateTime resgisterDate { get; set; }
        public DateTime travelDate { get; set; }
        public TimeSpan travelTime { get; set; }
        public Decimal totalPrice { get; set; }
        public string state { get; set; }
        public string description { get; set; }
    }
}
