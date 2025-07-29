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


