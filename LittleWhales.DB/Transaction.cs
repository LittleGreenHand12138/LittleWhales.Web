using System;
using System.Data;

namespace LittleWhales.DB
{
    public class Transaction : ITransaction
    {
        Database _db;

        public Transaction(Database db, IsolationLevel isolationLevel)
        {
            _db = db;
            _db.BeginTransaction(isolationLevel);
        }

        public virtual void Complete()
        {
            _db.CompleteTransaction();
            _db = null;
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.TransactionIsAborted = true;
                _db.AbortTransaction();
            }
        }
    }

    public interface ITransaction : IDisposable
    {
        void Complete();
    }
}