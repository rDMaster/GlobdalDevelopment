namespace GlobalDevelopment.Interfaces
{
    public interface IUserPackage : IPackage
    {
        string Name { get; set; }
        int Age { get; set; }
        string Email { get; set; }
        string Gender { get; set; }
    }
}
