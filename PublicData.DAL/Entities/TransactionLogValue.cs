using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class TransactionLogValue : Entity
    {
        public TransactionLogValue()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int TransactionLogId { get; set; }

        public string TableName { get; set; }

        public string PreviousValue { get; set; }

        public string NewValue { get; set; }

        #endregion

        #region Generated Relationships
        public virtual TransactionLog TransactionLog { get; set; }

        #endregion

    }
}
