namespace DapperServices.DataProcess
{
    public interface IDapperUnitOfWork : IDisposable
    {
        IDapperReposity GetRepository();
    }
}
