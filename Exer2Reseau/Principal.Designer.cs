namespace DecouverteReseau
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.labelAdaptateur = new System.Windows.Forms.Label();
            this.LabelNomAdaptateur = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valeur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxEthernetNom = new System.Windows.Forms.GroupBox();
            this.groupBoxPing = new System.Windows.Forms.GroupBox();
            this.getLocalHostName = new System.Windows.Forms.Button();
            this.buttonGetHostEntry = new System.Windows.Forms.Button();
            this.buttonPing = new System.Windows.Forms.Button();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.textBoxResultat = new System.Windows.Forms.TextBox();
            this.buttonEffacer = new System.Windows.Forms.Button();
            this.buttonTrace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxEthernetNom.SuspendLayout();
            this.groupBoxPing.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAdaptateur
            // 
            resources.ApplyResources(this.labelAdaptateur, "labelAdaptateur");
            this.labelAdaptateur.Name = "labelAdaptateur";
            // 
            // LabelNomAdaptateur
            // 
            resources.ApplyResources(this.LabelNomAdaptateur, "LabelNomAdaptateur");
            this.LabelNomAdaptateur.Name = "LabelNomAdaptateur";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.element,
            this.valeur});
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // element
            // 
            resources.ApplyResources(this.element, "element");
            this.element.Name = "element";
            this.element.ReadOnly = true;
            // 
            // valeur
            // 
            this.valeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.valeur, "valeur");
            this.valeur.Name = "valeur";
            this.valeur.ReadOnly = true;
            // 
            // groupBoxEthernetNom
            // 
            this.groupBoxEthernetNom.Controls.Add(this.labelAdaptateur);
            this.groupBoxEthernetNom.Controls.Add(this.LabelNomAdaptateur);
            this.groupBoxEthernetNom.Controls.Add(this.dataGridView);
            resources.ApplyResources(this.groupBoxEthernetNom, "groupBoxEthernetNom");
            this.groupBoxEthernetNom.Name = "groupBoxEthernetNom";
            this.groupBoxEthernetNom.TabStop = false;
            // 
            // groupBoxPing
            // 
            resources.ApplyResources(this.groupBoxPing, "groupBoxPing");
            this.groupBoxPing.Controls.Add(this.buttonTrace);
            this.groupBoxPing.Controls.Add(this.getLocalHostName);
            this.groupBoxPing.Controls.Add(this.buttonGetHostEntry);
            this.groupBoxPing.Controls.Add(this.buttonPing);
            this.groupBoxPing.Controls.Add(this.textBoxAdress);
            this.groupBoxPing.Controls.Add(this.textBoxResultat);
            this.groupBoxPing.Controls.Add(this.buttonEffacer);
            this.groupBoxPing.Name = "groupBoxPing";
            this.groupBoxPing.TabStop = false;
            // 
            // getLocalHostName
            // 
            resources.ApplyResources(this.getLocalHostName, "getLocalHostName");
            this.getLocalHostName.Name = "getLocalHostName";
            this.getLocalHostName.UseVisualStyleBackColor = true;
            this.getLocalHostName.Click += new System.EventHandler(this.buttongetLocalHostName_Click);
            // 
            // buttonGetHostEntry
            // 
            resources.ApplyResources(this.buttonGetHostEntry, "buttonGetHostEntry");
            this.buttonGetHostEntry.Name = "buttonGetHostEntry";
            this.buttonGetHostEntry.UseVisualStyleBackColor = true;
            this.buttonGetHostEntry.Click += new System.EventHandler(this.buttonGetHostEntry_Click);
            // 
            // buttonPing
            // 
            resources.ApplyResources(this.buttonPing, "buttonPing");
            this.buttonPing.Name = "buttonPing";
            this.buttonPing.UseVisualStyleBackColor = true;
            this.buttonPing.Click += new System.EventHandler(this.buttonPing_Click);
            // 
            // textBoxAdress
            // 
            resources.ApplyResources(this.textBoxAdress, "textBoxAdress");
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.TextChanged += new System.EventHandler(this.textBoxAdress_TextChanged);
            this.textBoxAdress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAdress_KeyDown);
            // 
            // textBoxResultat
            // 
            resources.ApplyResources(this.textBoxResultat, "textBoxResultat");
            this.textBoxResultat.Name = "textBoxResultat";
            this.textBoxResultat.ReadOnly = true;
            // 
            // buttonEffacer
            // 
            resources.ApplyResources(this.buttonEffacer, "buttonEffacer");
            this.buttonEffacer.Name = "buttonEffacer";
            this.buttonEffacer.UseVisualStyleBackColor = true;
            this.buttonEffacer.Click += new System.EventHandler(this.buttonEffacer_Click);
            // 
            // buttonTrace
            // 
            resources.ApplyResources(this.buttonTrace, "buttonTrace");
            this.buttonTrace.Name = "buttonTrace";
            this.buttonTrace.UseVisualStyleBackColor = true;
            this.buttonTrace.Click += new System.EventHandler(this.buttonTrace_Click);
            // 
            // FormPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPing);
            this.Controls.Add(this.groupBoxEthernetNom);
            this.Name = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.SizeChanged += new System.EventHandler(this.FormPrincipal_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxEthernetNom.ResumeLayout(false);
            this.groupBoxEthernetNom.PerformLayout();
            this.groupBoxPing.ResumeLayout(false);
            this.groupBoxPing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAdaptateur;
        private System.Windows.Forms.Label LabelNomAdaptateur;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBoxEthernetNom;
        private System.Windows.Forms.GroupBox groupBoxPing;
        private System.Windows.Forms.Button getLocalHostName;
        private System.Windows.Forms.Button buttonGetHostEntry;
        private System.Windows.Forms.Button buttonPing;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.TextBox textBoxResultat;
        private System.Windows.Forms.DataGridViewTextBoxColumn element;
        private System.Windows.Forms.DataGridViewTextBoxColumn valeur;
        private System.Windows.Forms.Button buttonEffacer;
        private System.Windows.Forms.Button buttonTrace;
    }
}

