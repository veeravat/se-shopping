namespace ShoppingModule.Interface
{
    interface iMember
    {
        int memberID { get; set; }
        string memberName { get; set; }
        string memberTel { get; set; }
        string memberEmail { get; set; }
        string password { get; set; }
        string address { get; set; }

    }
}
