/***
 * Description: Programme de découverte réseau. Ce programme permet d'effectuer des requetes sur le réseau 
 * 
 *          Principal.cs : Form Principal Fonctions
 *                  - buttonPing_Click
 *                  - buttonGetHostEntry_Click
 *                  - buttongetLocalHostName_Click
 *                  - buttonTrace_Click 
 *                  - buttonEffacer_Click 
 *                  - FormPrincipal_Load 
 *                  - textBoxAdress_TextChanged
 *                  - FormPrincipal_SizeChanged
 *                  - textBoxAdress_KeyDown
 *                  - textBoxAdress_TextChanged
 *           
 *          Fonctions.cs : Fonctions
 *                  - ObtenirLocalHostName
 *                  - TrouverInterfaceRéseauEthernet
 *                  - ObtenirHostEntry
 *                  - TraceRoute (A continuer )
 * 
 *          TextBoxWriter : Rediriger Console.WriteLine vers TextBox                 
 * 
 *          TestPing.csproj Pinger.cs :
 *                  - TesterPingAsync
 ****************************************************************************
 * 
 *Par  : Josiane Leta - Younes Rabdi
 *Created On : 2/13/2016
 *Last Modified On : 2/16/2016
**/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace DecouverteReseau
{
    public partial class FormPrincipal : Form
    {
        /// <summary>
        /// Form Principal
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            dataGridView.ColumnCount = 2;
            ActiveControl = textBoxAdress;

            IEnumerable<NetworkInterface> ethernet = Fonctions.TrouverInterfaceRéseauEthernet();   // trouver interface réseau Ethernet active

            foreach (NetworkInterface adatper in ethernet)
            {
                LabelNomAdaptateur.Text = adatper.Description;                     // Afficher l'interface réseau Ethernet trouvée

                string[] row = new string[] { "Id", adatper.Id };
                dataGridView.Rows.Add(row);
                row = new string[] { "IsReceiveOnly", adatper.IsReceiveOnly.ToString() };
                dataGridView.Rows.Add(row);
                row = new string[] { "Name", adatper.Name };
                dataGridView.Rows.Add(row);
                row = new string[] { "Type", adatper.NetworkInterfaceType.ToString() };
                dataGridView.Rows.Add(row);
                row = new string[] { "Status", adatper.OperationalStatus.ToString() };
                dataGridView.Rows.Add(row);
                row = new string[] { "Speed", adatper.Speed.ToString() };
                dataGridView.Rows.Add(row);
                row = new string[] { "Support Multicast", adatper.SupportsMulticast.ToString() };
                dataGridView.Rows.Add(row);
                row = new string[] { "MAC", string.Join(":", (from z in adatper.GetPhysicalAddress().GetAddressBytes()
                                                                select z.ToString("X2")).ToArray()) };
                dataGridView.Rows.Add(row);
            }
        }

        /// <summary>
        /// button Ping_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void buttonPing_Click(object sender, EventArgs e)
        {
            PingReply réponse = null;
            string adresse = textBoxAdress.Text.Trim();
            if (!string.IsNullOrWhiteSpace(adresse))
            {
                réponse = await Pinger.TesterPingAsync(adresse);
            }

            if (réponse != null)
            {
                try
                {
                    textBoxResultat.AppendText("Type: " + Uri.CheckHostName(adresse) + Environment.NewLine +
                            "Address: " + réponse.Address.ToString() + Environment.NewLine +
                            "Status: " + réponse.Status + Environment.NewLine +
                            "RoundTrip time: " + réponse.RoundtripTime + Environment.NewLine +
                            "Time to live: " + réponse.Options.Ttl + Environment.NewLine +
                            "Do not fragment: " + réponse.Options.DontFragment + Environment.NewLine +
                            "Buffer size: " + réponse.Buffer.Length + Environment.NewLine);
                }
                catch
                {
                    textBoxResultat.AppendText("Une reference de cette adresse n'est pas disponible : " + Environment.NewLine);
                }
            }
            else 
            {
                textBoxResultat.AppendText("Adresse non valide." + Environment.NewLine);
            }
        }

        /// <summary>
        /// button getLocalHostName_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttongetLocalHostName_Click(object sender, EventArgs e)
        {
           textBoxResultat.AppendText("Host Name: " + Fonctions.ObtenirLocalHostName() + Environment.NewLine);
        }

        /// <summary>
        /// button GetHostEntry_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void buttonGetHostEntry_Click(object sender, EventArgs e)
        {
            Task<IPHostEntry> t = null;
            IPHostEntry hostEntry = new IPHostEntry();
            string adresse = textBoxAdress.Text.Trim();

            if (!string.IsNullOrWhiteSpace(adresse))
            {
                t = Fonctions.ObtenirHostEntry(adresse);
                hostEntry = await t;
            }
            
            if (hostEntry != null)
            {
                textBoxResultat.AppendText(String.Join<IPAddress>(Environment.NewLine, hostEntry.AddressList) +
                    Environment.NewLine + hostEntry.AddressList[0].AddressFamily.ToString() + Environment.NewLine +
                    "Host Name : " + hostEntry.HostName + Environment.NewLine);
            }
        }

        /// <summary>
        /// button Traceroute_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void buttonTrace_Click(object sender, EventArgs e)
        {
            Task<string> t = Task.Run(()=> Fonctions.TraceRoute(textBoxAdress.Text.Trim()));
            buttonTrace.Enabled = false;    // Desactiver le button pendant le trace route
            string reponseTrace = await t;  // Attendre que la tâche t finisse;
            buttonTrace.Enabled = true;     // Réactiver le boutton traceroute
            textBoxResultat.AppendText(reponseTrace);
        }

        
        /// <summary>
        /// button Effacer_Click : Clear resultats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            textBoxResultat.Clear();
        }

        /// <summary>
        /// Form Principal_Load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Console.SetOut(new TextBoxWriter(textBoxResultat));
            buttonGetHostEntry.Enabled  = false;
            buttonPing.Enabled          = false;
            buttonTrace.Enabled         = false;
        }

        /// <summary>
        /// textBoxAdress_TextChanged : Disable buttonPing et buttonGetHostEntry si textBox vide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {
            buttonGetHostEntry.Enabled  = !string.IsNullOrEmpty(textBoxAdress.Text.Trim());
            buttonPing.Enabled          = !string.IsNullOrEmpty(textBoxAdress.Text.Trim());
            buttonTrace.Enabled         = !string.IsNullOrEmpty(textBoxAdress.Text.Trim());
        }

        /// <summary>
        /// textBoxAdress_KeyDown : Ping adresse si la touche "Enter" du clavier est pressée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxAdress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPing.PerformClick();
            }
        }

        /// <summary>
        /// FormPrincipal_SizeChanged : Pour que le boutton Effacer suit le textboxResultats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_SizeChanged(object sender, EventArgs e)
        {
            buttonEffacer.Location = new Point(this.buttonEffacer.Location.X, (textBoxResultat.Location.Y + textBoxResultat.Height + 8));
        }
    }
}
