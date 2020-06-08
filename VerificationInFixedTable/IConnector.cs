using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationInFixedTable
{
    public interface IConnector : IDisposable
    {
        //void Restart();
        //bool Relogin();
        void Subscribe();
        //dynamic SendMessage(dynamic message);
    }
}
