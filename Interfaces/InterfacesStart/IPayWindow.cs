using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesStart
{
    interface IPayWindow
    {
        // alles hier is publiek
        // je kan er geen object van aanmaken, er is geen constructor en new IPayWindow() gaat niet.
        void OpenPaymentScreen();
        bool PaymentSucceeded { get; }
        string PaymentSucceededMessage { get; }
        string PaymentFailedMessage { get; }
    }
}
