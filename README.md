# 📌 Visão Geral

Este é o backend do sistema de gestão de clínica, desenvolvido em .NET. Ele fornece a API RESTful para o frontend em React, com autenticação JWT e operações CRUD para gerenciamento de clientes, atendimentos, serviços e profissionais.

## 🚀 Como Executar o Projeto

Pré-requisitos

- .NET 9 SDK ou superior
- SQL Server (ou Docker para rodar em container)
- Visual Studio ou VS Code (opcional)

## Configuração

Clone o repositório:

```bash
git clone https://github.com/cesaraugusto0/GestaoClinica.git
cd GestaoClinica
```

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
## Execução de scripts de criação do banco 

Com o banco de dados SqlServer devidamente instalado, execute os scripts de criação do banco. Na projeto, é possivel encontrar uma pasta chamada scripts que possui os scripts sql de criação do banco de dados, com tabelas e relacionamentos.

## Configure a conexão com o banco de dados:

Este projeto utiliza um arquivo de configuração `appsettings.json` para definir as configurações necessárias ao funcionamento da aplicação, como conexão com banco de dados, URLs de serviços e outros parâmetros de ambiente.

### Arquivo de Exemplo

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
    "DetailedErrors": true,
    "Jwt": {
        "Key":  "key_hash",
        "Issuer": "GestaoClinicaAPI",
        "Audience": "GestaoClinicaClient"
    }
}
```
⚠️ Importante: Este arquivo (appsettings.json.example) é apenas um modelo. Nunca adicione informações sensíveis (como senhas ou chaves) nele, pois ele é versionado. O arquivo real (appsettings.json) é gerado localmente e ignorado pelo Git.


# 🌐 Integração com Frontend

O frontend em React está configurado para consumir esta API. Certifique-se de que as URLs no frontend apontem para o endereço correto do backend.

Segue o repositório de frontend: https://github.com/CaioVAzeredo/front-end-gestao-clinica


