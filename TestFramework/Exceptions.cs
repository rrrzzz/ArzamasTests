using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{  
    [Serializable]
    public class IncorrectAuthorException: Exception
    {
        public IncorrectAuthorException() { }
        public IncorrectAuthorException(string message) : base(message) { }
        public IncorrectAuthorException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectAuthorException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    
}
