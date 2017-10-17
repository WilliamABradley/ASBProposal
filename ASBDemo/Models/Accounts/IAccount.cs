namespace ASBDemo.Models.Accounts
{
    public interface IAccount
    {
        string FriendlyIdentifier { get; }
        string Name { get; }
        decimal Balance { get; }
    }
}