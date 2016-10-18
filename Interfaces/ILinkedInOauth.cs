namespace GlobalDevelopment.Interfaces
{
    public interface ILinkedInOauth
    {
        string AccessToken { get; set; }
        string PageID { get; set; }
        string AppSecret { get; set; }
        string AppId { get; set; }
        string PermissionScope { get; set; }
        string State { get; set; }
        string Url { get; set; }
        string UserID { get; set; }
        string Email { get; set; }
        string ResponseType { get; set; }
        string UserName { get; set; }
    }
}
