# Database independent application

This demo is having a DAL layer which is database independent. It takes provider name from
connection string and work for that database provider.
```csharp
namespace Dia.Dal
{
    // Common database works.
    internal class Common : IDisposable
    {
        private IDbConnection _con;
        private IDbCommand _cmd;
        private IDataReader _dr;
        private DbProviderFactory _factory;
        private ConnectionStringSettings _conStngInstitute;
        private bool _isDisposed;
        
// more code...
```
