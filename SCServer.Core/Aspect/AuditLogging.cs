using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Attributes;
using SCServer.Core.Enums;
using SCServer.Core.Infrastructure;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace SCServer.Core.Aspect
{
    public class AuditLogging : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var method = input.Target.GetType().GetMethod(input.MethodBase.Name);

            foreach (var attribute in method.GetCustomAttributes(true))
            {
                var auditAttribute = attribute as AuditOperation;

                if (auditAttribute.OperationType == OperationType.Create ||
                    auditAttribute.OperationType == OperationType.Update ||
                    auditAttribute.OperationType == OperationType.Delete)
                {
                    if (input.Arguments != null)
                    {
                        foreach (var argument in input.Arguments)
                        {
                            if (argument is Core.Model.Entity<Guid>)
                            {
                                if (argument is Core.Model.IAudit)
                                {
                                    var auditArgument = (Core.Model.IAudit)argument;

                                    if (auditAttribute.OperationType == OperationType.Create)
                                    {
                                        auditArgument.CreatedOn = DateTime.UtcNow;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var output = getNext()(input, getNext);

            return output;
        }
    }
}
