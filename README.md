# AvaliacaoDesenvolvedor
Este projeto permite um CRUD completo das informações requeridas, além de permitir uma pesquisa por nome.

## Desenvolvido em .NET Core, utilizando Migrations, Data Annotation e Entity Framework.
    
##### Funcionalidades do Sistema:
    
    A tela de contatos adiciona um novo contato, onde o campo nome é obrigatório.
    A tela de telefones adiciona um telefone e associa para um contato existente.
    Todos os itens cadastrados podem ser listados, atualizados ou deletados, com exceção do ID correspondente.
    Um contato não pode ser deletado caso possua um telefone associado.  
    Uma busca por nomes pode ser realizada na tela de contatos.
    
###### Como configurar o banco:
    Abrir o Console do Gerenciador de Pacotes
    Utilizar o comando Update-Database via console no visual studio para que as tabelas e relacionamentos sejam criadas.
    
###### Instalações necessárias via NuGet:
    Microsoft.EntityFrameworkCore.SqlServer 3.0.0
    Microsoft.EntityFrameworkCore.Tools 3.0.0
    Microsoft.Extensions.Logging.Debug 3.0.0
    Microsoft.VisualStudio.Web.CodeGeneration.Design 3.0.0
