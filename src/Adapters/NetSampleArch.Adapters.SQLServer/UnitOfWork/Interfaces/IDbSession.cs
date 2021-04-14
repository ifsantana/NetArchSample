using System;
using System.Data;

namespace NetSampleArch.Adapters.SQLServer.UnitOfWork.Interfaces
{
    public interface IDbSession : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}
