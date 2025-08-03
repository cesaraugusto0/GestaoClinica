# Configuração do SQL Server no Linux via Docker

Primeiramente instale o docker e garanta que ele esteja devidamente instalado.

```bash
docker --version
```

## Comando para executar o contêiner

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Senha123" \
  -e "MSSQL_PID=Evaluation" -p 1433:1433 --name sqlserver --hostname sqlserver \
  -d mcr.microsoft.com/mssql/server:2019-latest
```

## Dados para conexão com SGBD

Para conectar um cliente de banco de dados (como SSMS, Azure Data Studio ou DBeaver) ao SQL Server no Docker, use os seguintes parâmetros:

- **Servidor/Host**: localhost,1433 (ou IP da máquina Docker)
- **Autenticação**: SQL Server Authentication
- **Usuário**: sa
- **Senha**: Senha123
- **Banco de dados**: (deixe em branco para conectar ao banco mestre)

Escolha o SGBD de sua preferência, conecte o banco com o SGBD e execute o script de criação do banco e as suas tabelas.


------------------------------------------------------------------

# Configuração do Ambiente de Desenvolvimento

Este projeto utiliza um arquivo de configuração `appsettings.json` para definir as configurações necessárias ao funcionamento da aplicação, como conexão com banco de dados, URLs de serviços e outros parâmetros de ambiente.

## Arquivo de Exemplo

O arquivo `appsettings.json.example` é um modelo com a estrutura necessária para o correto funcionamento do sistema. Ele **não contém dados sensíveis** (como nomes de banco, senhas ou chaves de API), pois essas informações variam de acordo com o ambiente (desenvolvimento, homologação, produção).

### Estrutura do Arquivo

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=nome_do_banco;User Id=usuario;Password=senha;"
    },
    "AllowedHosts": "*",
    "DetailedErrors": true
}
```
⚠️ Importante: Este arquivo (appsettings.json.example) é apenas um modelo. Nunca adicione informações sensíveis (como senhas ou chaves) nele, pois ele é versionado. O arquivo real (appsettings.json) é gerado localmente e ignorado pelo Git.

### Primeiros Passos Após o Clone 

Após clonar o repositório, siga os passos abaixo para configurar o ambiente local: 

1. Navegue até a raiz do projeto.
2. Localize o arquivo appsettings.json.example.
3. Copie e renomeie o arquivo para appsettings.json:
```bash
cp appsettings.json.example appsettings.json
```
4. Edite o novo arquivo appsettings.json com as credenciais e configurações do seu ambiente local.

### Observações 
- O arquivo appsettings.json está listado no .gitignore e não será versionado, evitando vazamento de dados sensíveis.
- Sempre que mudar de máquina ou configurar um novo ambiente, repita o processo acima.
- Em ambientes de produção, utilize variáveis de ambiente ou um sistema de gerenciamento de configurações seguro.
     
------------------------------------------------------------------

 1 - Branches de Funcionalidades (Feature Branches):

- agendamento	-> CRUD de agendamentos + calendário.
clientes -> Cadastro de clientes, histórico e vinculação com Pessoa.

- autenticacao -> Login, perfis (IdentityServer) e controle de acesso.

- notificacoes -> Lembretes automáticos (e-mail/WhatsApp) para agendamentos.

- relatorios -> Dashboards e relatórios (ex: taxa de ocupação, serviços mais solicitados).

- fichas-atendimento -> Fichas digitais de atendimento vinculadas a clientes.


 2 - Ver todas as branches disponíveis:
    git branch       # Lista branches locais
    git branch -a    # Lista TODAS (locais + remotas)
    
 3 - Trocar para uma branch existente
    git checkout nome_da_branch
    
 4 - Verifique em qual branch você está 
    git branch
    
 
 
 -------------------------- Fazer commit na branch que estou usando -------------------------
    1 - Verifique em qual branch você está (confirme que está na correta):
    git branch

    2 - Adicione as alterações ao staging area (preparação para commit):
    git add .
    
    3 - Faça o commit com uma mensagem descritiva:
    git commit -m "Descrição clara do que foi alterado"

    4 - Envie para o repositório:
    git push origin nome-da-branch

 ----------------------------- DICAS -------------------------
 
 Sempre atualize sua branch local antes de trocar:

    git pull origin nome_da_branch

teste de commit
