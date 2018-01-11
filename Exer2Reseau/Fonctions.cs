using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace DecouverteReseau
{
    public static class Fonctions
    {
        /// <summary>
        /// Local Host Nom
        /// </summary>
        public static string ObtenirLocalHostName()
        {
            string hostName = "";
            try
            {
                // Get the local computer host name.
                hostName = Dns.GetHostName();
            }
            catch (Exception a)
            {
                Console.WriteLine("Exception : " + a.Message);
            }
            return hostName;
        }

        /// <summary>
        /// Trouver Interface Réseau Ethernet
        /// </summary>
        public static IEnumerable<NetworkInterface> TrouverInterfaceRéseauEthernet()
        {
            try
            {
                return NetworkInterface.GetAllNetworkInterfaces().Where(
                           network => network.NetworkInterfaceType == NetworkInterfaceType.Ethernet 
                           && network.OperationalStatus == OperationalStatus.Up);
            }
            catch{}

            return null;
        }

        /// <summary>
        /// Get Host Entry
        /// </summary>
        /// <param name="host">Un IP ou un nom de domaine</param>
        /// <returns>Task de type IPAddress, null sinon</returns>
        async public static Task<IPHostEntry> ObtenirHostEntry(string host)
        {
            Task<IPHostEntry> hostEntry = null;
            try
            {
                hostEntry = Dns.GetHostEntryAsync(host);
                IPHostEntry r = await hostEntry;
                return hostEntry.Result;
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("ArgumentNullException : {0}", a.Message);
            }
            catch (ArgumentOutOfRangeException a)
            {
                Console.WriteLine("ArgumentOutOfRangeException : {0}", a.Message);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("ArgumentException : {0}", a.Message);
            }
            catch (ObjectDisposedException a)
            {
                Console.WriteLine("ObjectDisposedException : {0}", a.Message);
            }
            catch (Exception a)
            {
                Console.WriteLine("Exception : {0}", a.Message);
            }
            return null;
        }

        /// <summary>
        /// Traceroute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string TraceRoute(string host)
        {
            Ping envoi = new Ping();
            PingOptions envoiOptions = new PingOptions(1, true);
            StringBuilder traceResults = new StringBuilder();
            try
            {
                // IPAddress ipAddress = Dns.GetHostEntry(host).AddressList[0];
                traceResults.AppendLine("Noeud \t adress \t\t Durée");

                Stopwatch stopWatch = new Stopwatch();      // durée pour chaque adresse entre notre machine et la destination
                uint duréetotale = 0;                       // durée total pour atteindre l'adresse de la destination.
                for (envoiOptions.Ttl = 1; envoiOptions.Ttl <= 30; envoiOptions.Ttl++)
                {
                    stopWatch.Reset();                      // Reset pour chaque adresse
                    stopWatch.Start();

                    PingReply réponse = envoi.Send(
                                            host,
                                            1000,
                                            Encoding.ASCII.GetBytes("allo"),
                                            envoiOptions);

                    stopWatch.Stop();
                    duréetotale += (uint)stopWatch.Elapsed.Milliseconds;

                    if (réponse.Status != IPStatus.Success)
                    { 
                    traceResults.AppendLine("# " 
                                            + envoiOptions.Ttl + "\t : "
                                            + (réponse.Address == null ? "Inconu" : réponse.Address.ToString())
                                            + "\t\t en " + stopWatch.Elapsed.Milliseconds + " ms");
                    }
                    else
                    {
                        traceResults.AppendLine("# " 
                                            + envoiOptions.Ttl + "\t : " 
                                            + "La destination " + réponse.Address + " est atteinte en "
                                            + duréetotale + " ms"); 
                        break;
                    }
                }
            }
            catch (Exception a)
            {
                traceResults.AppendLine("erreur" + a.Message + Environment.NewLine);
            }
            finally
            {
                if (envoi != null)
                    ((IDisposable)envoi).Dispose();
            }

            return traceResults.ToString();
        }
    }
}
