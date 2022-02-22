using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anoteitor
{
    public class Funcoes
    {
        public void Renomeia(string PastaRaiz, string NomeOrig, string NovoNome)
        {
            string Orig = PastaRaiz + NomeOrig;
            string Dest = PastaRaiz + NovoNome;
            Directory.Move(Orig, Dest);
            DirectoryInfo info = new DirectoryInfo(Dest);
            FileInfo[] arquivos = info.GetFiles();
            foreach (FileInfo arquivo in arquivos)
            {
                string Novo = arquivo.FullName.Replace(NomeOrig, NovoNome);
                File.Move(arquivo.FullName, Novo);
            }
        }
    }
}
