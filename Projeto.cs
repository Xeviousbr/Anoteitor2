﻿using System;
using System.Windows.Forms;

namespace Anoteitor
{    

    public partial class Projeto : Form
    {

        private string NomeAtividade = "";

        public Projeto()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            INI cIni = new INI();
            int Qtd = cIni.ReadInt("Projetos", "Qtd", 0) + 1;
            string Nome = textBox1.Text;
            this.NomeAtividade = Nome;
            string nmProjeto = "Pro" + Qtd.ToString();
            cIni.WriteInt("Projetos", "Qtd", Qtd);
            cIni.WriteString("NmProjetos", nmProjeto, Nome);
            cIni.WriteString("Projetos", "Atual", Nome);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        internal void SetNomeAtividade(string atual)
        {
            textBox1.Text = atual;
            this.Text = "Renomear Atividade";
        }

        internal string getNomeAtividade()
        {
            return this.NomeAtividade;
        }
    }
}
