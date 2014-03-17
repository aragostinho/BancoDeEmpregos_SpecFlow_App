using Moq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Projeto.SpecFlowTests
{
    [Binding]
    public class BancoDeEmpregosSteps
    {
        Vaga vaga = null;

        [Given(@"que ao preencher dados da vaga como salário de (.*) reais, local de trabalho ""(.*)"", cargo ""(.*)"", nome da empresa como ""(.*)"" e contatos da vaga como ""(.*)""")]
        public void DadoQueAoPreencherDadosDaVagaComoSalarioDeReaisLocalDeTrabalhoCargoNomeDaEmpresaComoEContatosDaVagaComo(Decimal salario, string local, string cargo, string empresa, string contatos)
        {
            vaga = new Vaga(salario, cargo, local, empresa, contatos);
        }

        [Given(@"selecionar a categoria ""(.*)"" na vaga")]
        public void DadoSelecionarACategoriaNaVaga(string categoria)
        {
            try
            {
                vaga.AdicionarCategoria(categoria);
            }
            catch (Exception ex)
            {
                ScenarioContext.Current["error"] = ex;
            }
        }

        [Given(@"preencher o captcha")]
        public void DadoPreencherOCaptcha()
        {

        }

        [When(@"cadastrar a vaga")]
        public void QuandoCadastrarAVaga()
        {
            vaga.Save();
        }

        [Then(@"registar no sistema")]
        public void EntaoRegistarNoSistema()
        {
            Assert.AreNotEqual(0, vaga.Id);
        }

        [Then(@"dispara um email de confirmação para o contato ""(.*)""")]
        public void EntaoDisparaUmEmailDeConfirmacaoParaOContato(string email)
        {
            var IEmailDispacherMock = new Mock<IEmailDispacher>(MockBehavior.Strict);

            IEmailDispacherMock.Setup(x => x.Send(email, It.IsAny<string>()));

            vaga.ConfirmarCadastro(IEmailDispacherMock.Object, email);
        }

        [Then(@"retorna um erro")]
        public void EntaoRetornaUmErro()
        {
            Type expected = typeof(VagaException);

            Assert.AreEqual(expected, (ScenarioContext.Current["error"] as Exception).GetType());
        }



    }
}
