using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.SpecFlowTests
{
    public class VagaException : Exception
    {
        public VagaException(string message)
            : base(message)
        {
        }
    }
}
