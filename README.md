<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]


<!-- ABOUT THE PROJECT -->
## Projeto Banco Atlantico
Exemplo de projeto utilizando Angular +2, .net para simular a criação de uma aplicação em Tempo real utilizando APIs.

### Tecnologias:
Utilizando as Tecnologias:

* [Angular](https://angular.io/)
* [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)

<!-- GETTING STARTED -->
## Getting Started

### Prerequisitos

* [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1)
* [Node](https://nodejs.org/pt-br/)
* Angular CLI(Depois de instalado o Node execute no terminal)
  ```sh
  npm install -g @angular/cli
  ```

### Iniciando a aplicação;

## 1. Instalando o Repositório:
  1.1 clone o repositório:
   ```sh
   git clone https://github.com/machlord/DesafioAtlantico.git
   ```
  1.2 Dentro do repositorio conterá as 3 pastas:<br/><br/>
      1.2.1 api   | *Backend do projeto em .net Core 3.1*<br/>
      1.2.2 front | *Frontend do projeto em angular+2*<br/>
      1.2.3 test  | *Teste criado em Nunit*<br/>
     
## <font color="red">NOTA: Para executar a ablipação e a API juntas, basta abrir dois terminais e executar passo 2 em um e o passo 3 em outro!</font>  
## 2. Configurando a API
2.1 Entre na pasta api e abra o terminal<br/>
2.2 Instale as dependencias com o comando:
   ```sh
   dotnet restore
   ```
 2.3 Caso deseje utilizar dados de teste ja cadastrado abra o arquivo DataContext.cs e descomente a linha 35 antes do proximo passo.<br/>
 2.4 Crie a migração que criará o banco de dados:
 ```sh
   dotnet ef migrations add Inicial
   ```
 2.5 Execute a migração:
 ```sh
   dotnet ef database update
   ```
 2.6 Execute a API:
 ```sh
   dotnet watch run
   ```
## 3. Configurando a Aplicação
3.1 Abra a pasta front e execute os próximos comandos<br />
3.2 Instalando as dependencias:
 ```sh
   npm install
   ```
3.3 Executando a aplicação:
 ```sh
  ng serve --open
   ```
## 4 Execução de testes
4.1 Abra a pasta teste<br />
4.2 Instale as dependencias com o comando:
   ```sh
   dotnet restore
   ```
4.3 Execute os testes:
   ```sh
   dotnet test
   ```

<!-- LICENSE -->
## licença
MIT License.


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/machlord/DesafioAtlantico.svg?style=for-the-badge
[contributors-url]: https://github.com/machlord/DesafioAtlantico/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/machlord/DesafioAtlantico.svg?style=for-the-badge
[forks-url]: https://github.com/machlord/DesafioAtlantico/network/members
[stars-shield]: https://img.shields.io/github/stars/machlord/DesafioAtlantico.svg?style=for-the-badge
[stars-url]: https://github.com/machlord/DesafioAtlantico/stargazers
[issues-shield]: https://img.shields.io/github/issues/machlord/DesafioAtlantico.svg?style=for-the-badge
[issues-url]: https://github.com/machlord/DesafioAtlantico/issues
[license-shield]: https://img.shields.io/github/license/machlord/DesafioAtlantico.svg?style=for-the-badge
[license-url]: https://github.com/machlord/DesafioAtlantico/blob/master/LICENSE.txt
