#language: pt-br

Funcionalidade: Banco de empregos
 O banco de empregos é um sistema para cadastro de vagas

 Cenario: Cadastrar uma vaga para Ajudante
 Dado que ao preencher dados da vaga como salário de 560,50 reais, local de trabalho "São Paulo", cargo "Ajudante", nome da empresa como "Condomínio Teste" e contatos da vaga como "João e Maria"
 E selecionar a categoria "Ajudante" na vaga
 E preencher o captcha
 Quando cadastrar a vaga
 Entao registar no sistema
 E dispara um email de confirmação para o contato "teste@sindiconet.com.br"


 Cenario: Não pode cadastrar sem selecionar uma vaga
 Dado que ao preencher dados da vaga como salário de 560,50 reais, local de trabalho "São Paulo", cargo "Ajudante", nome da empresa como "Condomínio Teste" e contatos da vaga como "João e Maria"
 E selecionar a categoria "" na vaga
 Entao retorna um erro




