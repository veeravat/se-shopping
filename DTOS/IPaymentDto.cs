namespace ShoppingModule.DTOS
{
    public interface IPaymentDto
    {
        string cardname { get; set; }
        string cardNumber { get; set; }
        string cvCode { get; set; }
        string expityMonth { get; set; }
        string expityYear { get; set; }
    }
}