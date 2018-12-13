namespace ShoppingModule.DTOS
{
    public interface IMemberRegisterDtos
    {
        string address { get; set; }
        string email { get; set; }
        string memberName { get; set; }
        string memberTel { get; set; }
        string password { get; set; }
    }
}