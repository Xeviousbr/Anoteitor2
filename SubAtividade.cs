using System;
using System.Windows.Forms;

namespace Anoteitor
{
    public partial class SubAtividade : Form
    {
        private string Atividade = "";
        private string NomeSubAtividade = "";
        private string NomeSubAtividadeAnt = "";
        private int QtdSub = 0;        
        private int NrSub = 0;
        public SubAtividade(string Ativ)
        {
            InitializeComponent();
            this.Atividade = Ativ;
            this.lbAtividade.Text = "Atividade: " + Ativ;
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            this.Grava();
        }

        private void Grava()
        {
            this.NomeSubAtividade = txSub.Text;
            INI cIni;
#if DEBUG
            cIni = new INI(@"H:\Anoteitor\Anoteitor.ini");
#else
            cIni = new INI();
#endif
            this.QtdSub = cIni.ReadInt(this.Atividade, "QtdSub", 0) + 1;            
            if (this.NomeSubAtividadeAnt.Length==0)
            {
                this.QtdSub++;
                cIni.WriteInt(this.Atividade, "QtdSub", QtdSub);
                this.NrSub = this.QtdSub;
            } else
            {
                for (int j = 0; j < this.QtdSub; j++)
                {
                    string Sub = "Sub" + (j + 1).ToString();
                    string NomeSub = cIni.ReadString(this.Atividade, Sub, "");
                    if (NomeSub== this.NomeSubAtividadeAnt)
                    {
                        this.NrSub = j+1;
                        string PastaGeral = cIni.ReadString("Projetos", "Pasta", "");
                        string Atual = cIni.ReadString("Projetos", "Atual", "");
                        string PastaSubAtual = this.NomeSubAtividadeAnt;
                        string PastaRaiz = PastaGeral + @"\" + Atual + @"\";
                        Funcoes Fun = new Funcoes();
                        Fun.Renomeia(PastaRaiz, PastaSubAtual, this.NomeSubAtividade);
                        break;
                    }
                }
            }
            cIni.WriteString(this.Atividade, ("Sub"+ this.NrSub.ToString()), this.NomeSubAtividade);
            cIni.WriteString(this.Atividade, "SubAtual", this.NomeSubAtividade);
            this.DialogResult = DialogResult.OK;
            Close();
        }
        public string Nome()
        {
            return this.NomeSubAtividade;
        }

        private void txSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.Grava();
        }

        public int getQtdSub()
        {
            return this.QtdSub;
        }

        internal void SetNomeSubAtividade(string NomeSubAtividade)
        {
            this.NomeSubAtividadeAnt = NomeSubAtividade;
            txSub.Text = NomeSubAtividade;
        }

        //internal void SetNrSub(int v)
        //{
        //    this.NrSub = v;
        //}
    }
}
