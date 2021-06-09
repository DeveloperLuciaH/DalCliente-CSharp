using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_DALCliente
{
    class Cliente
    {
        public Cliente()
        {
            this.Id = 0;
            this.Nome = "";
            this.CPF = "";
            this.RG = "";
            this.Email = "";
        }

        public Cliente (int Id, string Nome, string CPF, string RG, string Email)
        {
            this.Id = 0;
            this.Nome = Nome;
            this.CPF = CPF;
            this.RG = RG;
            this.Email = Email;
        }

        private int con_Id;
        private string con_Nome;
        private string con_CPF;
        private string con_RG;
        private string con_Email;

        public int Id { get => con_Id; set => con_Id = value; }
        public string Nome { get => con_Nome; set => con_Nome = value; }
        public string CPF { get => con_CPF; set => con_CPF = value; }
        public string RG { get => con_RG; set => con_RG = value; }
        public string Email { get => con_Email; set => con_Email = value; }

        

    }
}
