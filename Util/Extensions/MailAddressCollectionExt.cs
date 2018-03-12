using System.Collections.Generic;
using System.Net.Mail;

namespace Nh.Util
{
    public static class MailAddressCollectionExt
    {
        public static void CopyAddressesFrom(this MailAddressCollection destination, IEnumerable<string> source)
        {
            foreach (var address in source)
            {
                destination.Add(address);
            }
        }
    }
}
