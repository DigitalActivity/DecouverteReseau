using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace DecouverteReseau
{
    public static class Pinger
    {
        /// <summary>
        /// Envoie une requête de ping à l'adresse spécifiée
        /// </summary>
        /// <param name="adresse">Un IP ou un nom de domaine</param>
        /// <returns>Task de type PingReply si le ping est un succès, null sinon</returns>
        async public static Task<PingReply> TesterPingAsync(string adresse)
        {
            Ping testerPing = new Ping();
            Task<PingReply> t = null;
            System.Net.IPAddress ip;

            if (System.Net.IPAddress.TryParse(adresse, out ip) || Uri.CheckHostName(adresse) != UriHostNameType.Unknown)
            {
                try
                {
                    t = testerPing.SendPingAsync(adresse, 2000);
                    PingReply r = await t;
                    return t.Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ping fail : {0}", e.Message);
                }

            }
            return  null;
        }
    }
}
