using System;
using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class TransactionLog
    {
        public TransactionLog()
        {
            #region Generated Constructor
            TransactionLogValues = new HashSet<TransactionLogValue>();
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string UserId { get; set; }

        public string OperationType { get; set; }

        public DateTime CreatedAt { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<TransactionLogValue> TransactionLogValues { get; set; }

        #endregion

    }
}
