#  Projeto: Ulbraflix 🎥 :right_anger_bubble:
#### Projeto de Avaliação Semestral para disciplina de *Programação Orientada a Objetos* 💻. Consiste em um sistema simples simulando um reprodutor de vídeos (baseado no app Netflix).

## 📑 Class Diagram
![](Documentation/ClassDiagram.png)

## 👨‍💻 Padrões para Desenvolvimento  

### :octocat: GIT 

- Para criação de branch's, utilizar o prefixo ```feature-``` seguido do nome de quem está fazendo a tarefa.
- Para commits, utilizar o seguinte template **[NomeDaTask-Codigo] - função da tarefa**, ex: 
  ```
  [CreateEntities-1]-Create domain Entities
  ```
___
### 🔃 Ciclo de Desenvolvimento

- **Ready for Development**: Task escrita e pronta para ser desenvolvida (regras de negócio ou melhorias a serem implementadas)
- **In Development**: Autoexplicativa, é o processo de desenvolvimento e testes locais
- **In Code Review**: Após desenvolvido e criado o merge request, este processo entra em vigor e um dev responsabiliza-se por revisar o código escrito
- **Smoke Test**: Após desenvolvido, serve como uma etapa de testes para validar o código escrito.
- **Stable**: Última etapa de homologação, residem as features prontas para realizar o deploy na master/main. 
___
### 🧰 Ferramentas

- **Gestão de produção:** Trello
- **Linguagem**: C# (.NET v6.0.3, EntityFramework v6.0.3)
- **Database**: Heroku (PostgreSQL)
- **Testes Endpoint's:**: Postman
- **Documentação de Endpoint's**: Swagger
___
### :crocodile: Orientação para testes

❗ **Instalar o .NET SDK v6.0.3 ou superior**

##### Windows 
<a target="_blank"> https://dotnet.microsoft.com/en-us/download </a>

##### Ubuntu 20.04 - Via Terminal
```
sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-6.0
```
