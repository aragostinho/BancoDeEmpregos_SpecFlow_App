using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.SpecFlowTests
{
    public class Vaga
    {
        private decimal salario;
        private string local;
        private string cargo;
        private string empresa;
        private string contatos;

        public Vaga(decimal salario, string cargo, string local, string empresa, string contatos)
        {
            this.salario = salario;
            this.local = local;
            this.cargo = cargo;
            this.empresa = empresa;
            this.contatos = contatos;
            this.Categorias = new List<string>();
        }
        public int Id { get; set; }

        public List<string> Categorias { get; private set; }

        public void Save()
        {
            this.Id = 1;
        }

        public void ConfirmarCadastro(IEmailDispacher dispacher, string email)
        {
            dispacher.Send(email, string.Format("Olá, sua vaga foi registrada"));
        }

        public void AdicionarCategoria(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
                throw new VagaException("Selecione uma vaga");

            Categorias.Add(categoria);
        }
    }
}
