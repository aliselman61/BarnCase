namespace BarnCase.DataAccess
{
    public interface IUserMoneyRepository
    {
        decimal GetMoney(string username);
        void SetMoney(string username, decimal money);
    }
}
