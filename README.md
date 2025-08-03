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
