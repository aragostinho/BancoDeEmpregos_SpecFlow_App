using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.SpecFlowTests
{
    public interface IEmailDispacher
    {
        void Send(string email, string body);
    }
}
