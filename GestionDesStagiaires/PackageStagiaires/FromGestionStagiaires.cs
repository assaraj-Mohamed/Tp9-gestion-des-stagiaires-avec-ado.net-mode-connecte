﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionDesStagiaires.PackageStagiaires;


namespace PackageStagiaires
{
    public partial class FormGestionStagiaires : Form
    {
        public FormGestionStagiaires()
        {
            InitializeComponent();
        }


        public void actualiser() {
            List<Stagiaire> ls = new GestionStagiaires().Afficher();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ls;
        
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            FormStagiaire f = new FormStagiaire();
            f.FormulaireGestionStagiaires = this;
            f.Show();
        }

        private void bt_supprimer_Click(object sender, EventArgs e)
        {
            String message = "Voulez vous vraiement supprimer ce stagiaire";
            if (MessageBox.Show(message, "Message de confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                int id = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
                GestionStagiaires g = new GestionStagiaires();
                g.Supprimer(id);
                this.actualiser();
            }
          

        }

        private void FormGestionStagiaires_Load(object sender, EventArgs e)
        {
            this.actualiser();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            int id = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
            FormUpdateStagiaire f = new FormUpdateStagiaire();
            f.Show();
            f.Update(id);
            f.FormulaireGestionStagiaires = this;

        }
    }
}
