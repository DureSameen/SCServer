using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Enums;

namespace SCServer.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuditOperation : System.Attribute
    {
        public OperationType OperationType { get; set; }

        public AuditOperation(OperationType operationType)
        {
            OperationType = operationType;
        }
    }
}
