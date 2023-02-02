# Aplicacao Web MVC

Anotações feitas baseadas no curso ["ASP .NET Core MVC- Criando um Site do Zero(NET 6)"](https://www.udemy.com/course/curso-de-asp-net-core-mvc-criando-um-site-do-zero/) do professor Macoratti.

---

## Tabela de Conteúdo
- [Modelo de Domínio](#modelo-de-domínio)
- [Ferramenta ORM](#ferramenta-orm)
- [Entity Framework Core](#entity-framework-core)
   - [Convenções](#convenções-usadas)
   - [Funcionamento](#funcionamento)
   - [Data Annotations](#data-annotations)
- [Migrations](#migrations)
- [SQL Server](#sql-server)
- [Transferir Dados Para View](#transferir-dados-para-views)
   - [ViewData](#viewdata)
   - [ViewBag](#viewbag)
   - [TempData](#tempdata)
- [View Model](#viewmodel)
- [Partial View](#partial-view)
- [View Component](#view-components)
- [Session](#session)
- [Tag Helpers](#tag-helpers)
- [Áreas](#áreas)
- [Roteamento de Endpoint](#roteamento-de-endpoint)
- [Autenticação de Login](#autenticação-de-login)

---

## Modelo de domínio

**Classes que representam a sua lógica de domínio**.

Por que não iniciar criando um banco de dados e tabelas antes do modelo de domínio usando classes?

Pois podemos usar uma ferramenta ORM.

## Ferramenta ORM

 Uma ferramenta ORM (Object Relational Mapping) mapeia as classes para as tabelas do banco de dados. Elimina a necessidade da maior parte do código de acesso a dados que precisamos escrever manualmente. **Entity Framework Core** é uma dessas ferramentas, e é recomendada pela Microsoft.

### Abordagem Code-First

- **Gera o banco de dados e tabelas a partir das classes**
- Primeiro criamos as classes do modelo de domínio, para depois, usando o EF Core (usando **Migrations**), criarmos o banco de dados e tabelas com base nas classes feitas.

#### Vantagens do Code-First:

- Permite definir as propriedades e relacionamentos usando **código C#**
- Permite abstrair **comandos SQL** e objetos ADO.NET
- Permite gerenciar o **versionamento** do banco de dados usando **Migrations**
- Auxilia na produtividade reduzindo o tempo de desenvolvimento

---

## Entity Framework Core  

### Convenções usadas

- A propriedade Id ou <nome_entidade>Id vai gerar uma chave primária na tabela
- As **propriedades** definidas na classes irão gerar colunas com o **mesmo nome** na tabela
- O tipo de dados das colunas geradas a partir dos tipos definidos nas propriedades das classes depende do provedor do banco de dados usado
- A definição do relacionamento entre as entidades é definido em uma **propriedade de navegação**.
- 
### Funcionamento

 Possui duas classes principais: 
 - DbContext (Possui um ou mais DbSet< T >)
    - Conexão com a Database
    - Operações com dados
    - Consulta e Persistência
    - Mapeamento dos dados
    - Gestão de transações
 - DbSet< T >
    - Coleção para entidade do modelo
    - Coleções na memória
    - Para persistir usar **SaveChanges()**

Para cada classe que desejamos criar uma tabela correspondente, temos que criar um **DbSet< T >**(do tipo da classe que estamos manipulando ) e adicioná-lo ao **DbContext**. Usamos o linq pelo DbContext que traduz nossos requests para SQL para passar para cada DbSet< T > correspondente.

### Data Annotations

São **atributos** que podem ser aplicados a **classes e seus membros** para realizar as seguintes tarefas:
   - Definir as regras de **validação** para o modelo
   - Definir como o dado devem ser **exibidos** na interface
   - Especificar o **relacionamento** entre as entidades do modelo
   - Sobrescrever as **convenções** padrão do Entity Framework Core

Namespaces:
```cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
```
### `Utilização`

1- Front-End: Atributos de validação

- Usados para impor regra de validação nas Views. Podem ser usados para validar e-mail, dados, campos com máscaras, etc.
- Como fazer: Definir os atributos nas propriedades das classes do **modelo de domínio**. Definir os critérios de validação em um local (**Model**) e isso produz os efeitos em qualquer lugar que o Model for usado. A validação é aplicadana no modelo de domínio através da **definição de atributos**, e não na interface do usuário.
- Atributos de Validação do modelo:

   - **Required** - Especifica uma propriedade como obrigatória e não aceita *null* no banco e dados.
   - **Range** - Especifica as restrições de intervalo numérico para o valor de um campo de dados.
   - **EmailAddres** - Valida o formato de um endereço de e-mail.
   - **Phone** - Valida o formato de telefone.
   - **MinLenght** - Especifica o comprimento mínimo dos dados de cadeia de caracteres da propriedade.
   - **MaxLenght** - Especifica o comprimento máximo dos dados de cadeia de caracteres da propriedade.
   - **StringLenght** - Especifica o comprimento mínimo e máximo de caracteres permitidos na propriedade.
   - **RegularExpression** - Permite definir expressões regulares para validações específicas.
   - **Display** - Especifica como os campos de dados são exibidos e formatados na **View**.
   - **DisplayFormat** - Aplica um formato definido a uma propriedade que será exibido na **View**.

2- Front-End: Atributos de exibição

- Usados para especificar como as propriedades do modelo serão exibidas(podem ser usados em **Resources** para exibir um valor diferente dependendo do idioma do usuário).
- Atributos de Modelagem de dados
   - **Key(*)** - Identifica a propriedade como uma chave primária na tabela.
   - **Table** - Define o nome da tabela para a qual a classe será mapeada.
   - **Column** - Define o nome na tabela para a qual a propriedade será mapeada.
   - **DataType(*)** - Associa um tipo de dados adicional a uma propriedade.
   - **ForeignKey** - Especifica que a propriedade é usada como uma chave estrangeira.
   - **NotMapped** - Exclui a propriedade do mapeamento.

3- Back-End: Atributos de Modelagem de dados

   - Usados para especificar as limitações da tabela e o relacionamento entre as classes. Podem ser usados para definir o tipo de campo,tamanho,formatação, etc.

---

## Migrations

Permite **atualizar** de forma incremental o **esquema do banco de dados** e assim mantê-lo sincronizado com o modelo de dados do seu projeto, preservando os dados existentes.
Principais tarefas do Migration:
   - **Atualizar o banco de dados**: Aplica migrações pendentes para atualizar o esquema do banco de dados.
   - **Personalizar o código de migração**: Modificar e suplementar o código gerado.
   - **Remover uma migração**: Modificar e suplementar o código gerado.
   - **Reverter uma migração**: Desfazer as alterações no banco de dados;
   - **Gerar scripts SQL**: Gerar scripts para atualizar ou solucionar problemas.
   - **Aplicar migrações em tempo de execução**: Usar o método ***Migrate()*** para migrações em *runtime*.

### Requisitos para uso do Migrations

Instalar **as ferramentas do Entity Framework Core** (o próprio core, tools e design), que ajudam nas tarefas de desenvolvimento em tempo de projeto e são usadas para gerar migrações e fazer engenharia reversa do esquema do banco de dados.

### Para aplicar o Migrations no projeto temos que definir:

   - Um modelo de entidades que são **classes** com propriedades.
   - Uma classe de contexto que herda de **DbContext** e os **DbSets** para as entidades a mapear.
   - Definir a string de conexão com o banco de dados no arquivo **appsettings.json**.
   - Registrar o contexto como um serviço usando **AddDbContext**.
   - Definir o provedor do banco de dados e a **string de conexão** usada.

### Como usar Migrations

Podemos usar as ferramentas no Visual Studio na janela **Package Manager Console** ou usar as ferramentas de linha de comando (**NET CLI**) com o VS Code.

O processo de criar e aplicar o **Migrations** envolve duas etapas:
   - 1 - **Criar a migração** - Executa o arquivo de script gerado e aplica os comandos ao banco de dados.
   - 2 - **Aplicar a migração** - Executa o arquivo de script gerado e aplica os comandos ao banco de dados.

Package Manager Console:

   - 1- **Criar Migração**
      ```
      add-migration NomeDaMigração[options]
      ```
   - 2- **Aplicar Migração**
      ```
      update-database[options]
      ```
   - 3 **Remover Migração**
      ```
      remove-migration
      ```

---

## SQL Server

- Connection String: A **string de conexão** é uma expressão que contém os parâmetros necessários para que os aplicativos se conectem a um servidor de banco de dados.

No SQL Server as strings de conexão incluem:
   - 1- A instância do servidor
   - 2- O nome do banco de dados
   - 3- Os detalhes de autenticação
   - 4- Outras configurações para se comunicar com o servidor do banco de dados

SQL Server Authentication
```
Server=ServerName;Database=DatabaseName;User Id=UserName;Password=UserPassword;
```
Windows Authentication
```
Server=ServerName;Database=DatabaseName;Trusted_Connection=True;
``` 
LocalDB
```
Server=(localdb)\MinhaInstancia;Integrated Security=true;
```
SQL Express
```
Data Source=nome_server\\sqlexpres;Initial Catalog=Database1;Integrated Security=True;
```

### Populando as tabelas com dados iniciais

1 - Incluir dados manualmente usando a instrução **INSERT INTO**

2 - Usar o método **OnModelCreating** do arquivo de contexto e definir o código usando a propriedade **HasData** do EF Core para preencher as tabelas com dados

3 - Criar um método estático e definir o código para incluir dados usando o método **AddRange()** do EF Core

4 - Criar uma migração vazia usando o **Migrations** e usar os métodos **Up()** e **Down()** e definir nestes métodos as instruções **INSERT INTO** para incluir dados nas tabelas. Para usar este método vamos:
   - Criar uma nova migração vazia para popular as tabelas. Obs: será criado o arquivo de script contendo os métodos Up() e Down() vazios
   - Incluir no método **Up()** as instruções **INSERT INTO** para popular as tabelas
   - Incluir no método **Down()** as instruções **DELETE FROM** para desfazer a migração

---

## Transferir dados para Views

### ViewData

Transfere dados do **Controller** para a **View**, é do tipo *ViewDataDicitionary*. É um dicionário que armazena dados no formato *chave/valor*. Exige a conversão de tipos para: verificar valores nulos, obter dados, evitar erros.

Sintaxe:
```
// no Controller
ViewData["Titulo"] = "Meu título";
ViewData["Data"] = DateTime.Now;

// na View
@ViewData["Titulo"]
@ViewData["Data"]
```

Obs: Tempo de vida de uma ViewData é = ao request.

### ViewBag

Transfere dados do **Controller** para a **View**, é uma propriedade dinâmica (dynamic). É um tipo **object** que armazena dados no formato *chave/valor*. **Não** requer a conversão de tipos. O tipo mais comum de ser usado, por ser mais "enxuto".


Sintaxe:
```
// no Controller
ViewBag.Titulo = "Meu Titulo";
ViewBag.Data = DateTime.Now;

// na View
@ViewBag.Titulo
@ViewBag.Data
```

Obs: Tempo de vida de uma ViewBag é = ao request.

### TempData

Transfere dados do: **Controller** para a **View**, da **View** para o **Controller** ou de método **Action** para outro método **Action** no mesmo Controlador ou para um Controlador diferente. É um objeto dicionário do tipo **TempDataDictionary**, que armazena dados no formato *chave/valor*. Armazena os dados temporariamente e os remove automaticamente após recuperar um valor. **Exige a conversão de tipos**.

Sintaxe:
```
// no Controller
TempData["Titulo"] = "Meu Titulo";
TempData["Data"] = DateTime.Now;

// na View
@TempData["Titulo"]
@TempData["Data"]
```
Obs: Verificar se a TempData tem a informação que você quer:
```
@if(TempData.ContainsKey("Titulo"))
{
   <h1>@TempData["Titulo"];</h1>
}
```
**Característica especial da TempData**: o valor só pode ser recuperado uma vez, isto é, ao utilizar o valor de uma chave TempData, esse valor desaparece.

---

## ViewModel

### Definição

É um padrão de projeto que permite separar as responsabilidades do **modelo de domínio** dos modelos que atendem as **Views**. Representa o conjuto de uma ou mais entidades do **modelo de domínio** e de outras informações que serão exibidas em uma **View**. Permite isolar e **desacoplar** o modelo de domínio da **lógica de exibição da View**.

- 1- Contém apenas as propriedades que serão representadas na **View**
- 2- Pode possuir regras específicas de validação (DataAnnotations)
- 3- Pode conter **múltiplas entidades** ou objetos dos modelo de domínio
- 4- Contém a **lógica da interface do usuário**
- 5- Contém somente dados e comportamentos relacionados às **Views**
- 
### Utilização

- Gerenciar ou criar **listas suspensas** para uma entidade
- Criar **Views** Mestre-Detalhes
- Usadas em carrinhos de compras
- Usadas em paginação de dados
- Usadas para implementar o **Login** e o **Registro**

---

## Partial View

É uma view que é renderizada em outra **view**. São usadas para **encapsular a lógica** reutilizada nas views permitindo simplificar a complexidade das **views**.
Podem ser usadas em múltiplas views onde é necessário uma lógica similar, evitando assim **duplicidade** de código.

obs: Uma partial view criada em uma pasta especifica das views de um controlador pode ser usada por **todas** as views desta pasta. Agora, uma partial view criada na pasta **Shared** (dentro da pasta Views) pode ser usada por **todas as views existentes na pasta views**.

**Principais usos**:
- Renderizar Menus de Navegação;
- Desenvolver formulários de entrada comuns;
- Renderizar dados comuns às views (reduz duplicação)
- Dividir arquivos de marcação grandes em arquivos menores

**Características**:
- Possuem a extensão *.cshtml*
- Podem ser retornadas em um método **Action(ViewResult)**
- São iguais a views (a nível de código)
- São renderizadas de forma diferente (não rexecutam o arquivo _ViewStart.cshtml)
- São armazenadas na pasta **Views** ou na pasta **Shared**, dentro da pasta **Views**.
- O nome do arquivo de uma **partial view** começa com um sublinhado (_)

**Como utilizar**:

**Tag Helper**
```html
<partial name="_PartialName" />

<partial name="~/Pages/_PartialName.cshtml"/>
```
A Tag Helper *partial* renderiza o conteúdo de forma assíncrona. Ao definir uma **extensão** (como no primeiro exemplo) no arquivo da partial view, a **taghelper** referencia uma partial view que deve estar na mesma pasta que o arquivo que chama a partial view.

**HTML Helper**
```
@await Html.PartialAsync("_PartialName");
@await Html.RenderPartialAsync("_PartialName");
```
Usar a **Html Helper** *PartialAsync* ou *RenderPartialAsync*.

```
@await Html.PartialAsync("_PartialName.cshtml");
@await Html.RenderPartialAsync("_PartialName.cshtml");
```
Quando a extensão do arquivo está presente, o **HTML Helper** faz referência a uma partial view que deve estar **na mesma pasta** que o arquivo de marcação que chama a partial view.

Obs: **Não** é recomendado usar @Html.Partial, nem @Html.RenderPartial, que são síncronos

**Acessando dados**
```html
<partial name="_PartialName" for="Model"/>
```
```
@await Html.PartialAsync("_PartialName", model);
@await Html.RenderPartialAsync("_PartialName", model);
```
Quando uma partial view é instanciada (e definimos um modelo), ela receber uma **cópia do dicionário ViewData** do pai. As atualizações feitas nos dados dentro da partial view **não são** persistidas na view pai. As alterações no **ViewData** em uma partiel view **são perdidas** quando a partial view retorna.

---

## View Components

Permitem criar funcionalidades semelhantes a um método **Action** de um controlador, independente de um controlador (São parecidas com **Partial Views**).

### Consistem em duas partes:

- 1- A classe (derivada de ViewComponent)
- 2- O resultado que ela retorna (uma **View**)

### Criando uma ViewComponent (VC)

Uma classe VC pode ser criada da seguintes maneiras:
- a- Derivando de **ViewComponent**
- b- Decorando a classe com o atributo **[ViewComponent]**
- c- Criando uma classe onde o nome tem o sufixo **ViewComponent**

Uma classe VC deve ser pública, não aninhada e não abstrata.

A classe deve expor o método publico **InvokeAsync**
```cs
Nome = nome_da_ClasseViewComponent
```

### O Resultado que a ViewComponent retorna (uma *View*)

A view retornada deve ser criada na pasta:
```
Views/Shared/Components/nomes_vc
```
- Onde o nome_vc é o nome do prefixo usado na VC criada

### Usando uma ViewComponent

- 1- A partir de uma **View**

```
@Component.InvokeAsync("nome_vc", <tipo anonimo com parametros>)
```

A partir da ASp .Net Core 1.1 podemos invocar uma VC usando uma tag helper:
```
<vc:nome_vc parm="..."></vc:nome_vc>
```
Devemos usar a diretiva: @addTagHelper;nomeAssembly

- 2- A partir de um controlador
```
return ViewComponent("nome_vc", new {param="..."})
```

---

## Session

Namespace: Microsoft.AspNetCore.Session

Com base em um dicionário ou tabela hash no servidor, o estado da sessão persiste os dados através das requisições de um navegador.

O ASP.NET Core mantém o estado da sessão, dando ao cliente um cookie que contém o ID da sessão, que é enviado ao servidor com cada solicitação.

O servidor mantém uma sessão por tempo limitado após a última requisição (você pode definir o tempo limite da sessão ou usar o valor padrão que é *20 minutos*).

O estado da sessão é ideal para armazenar os dados do usuário específicos de uma determinada sessão. Dados são excluídos do cache quando:
   - A sessão expira
   - Quando usamos **Session.Clear()** no código

### Configurando a Sessão

A Classe **Startup** deve conter:
- Qualquer um dos caches de memória **IDistributedCache**.
- Uma chama a **AddSession** em *ConfigureServices()*
- A chamada **UseSession** em **Configure()**

```cs
public void ConfigureServices(IServiceCollection services)
{
   //Adiciona uma implementação padrão de IdistributedCache
   services.AddMemoryCache();
   services.AddSession();
}


public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
   ...
   app.UseSession();
}
```
Precisamos também resgistrar a interface IHttpContextAcessor() para injeção de dependência no método ConfigureServices:
```cs
public void ConfigureServices(IServiceCollection services)
{
   ...
   services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
}
```

### Guardando dados da Sessão

```cs
const string SessionKeyNome = "_Nome";
const string SessionKeyIdade = "_Idade";

HttpContext.Session.SetString(SessionKeyNome, "Exemplo");
HttpContext.SEssion.SetInt32(SessionKeyIdade, 20);

var nome = context.Session.GetString(SessionKeyNome);
var idade = context.Session.GetInt32(SessionKeyIdade);

```

---

## Tag Helpers

As **Tag Helpers** permitem que o código do lado do servidor participe na criação e renderização de elementos HTML em arquivos Razor. Elas são uma sintaxe alternativa aos **Html Helpers** e obtém o mesmo resultado final gerando o código HTML. A sintaxe parece com HTML (elementos e atributos), mas é processado pelo Razor no servidor.

`Exemplos`
```
<input type="text" asp-for="Nome"/>
<label asp-for="Email"></label>

<form asp-controller="Conta" asp-action="Login">
//Os elementos do formulário
</form>
```
```
<input id="nome" name="nome" type="text" value=""/>
<label for="Email">Email</label>

<form action="/Conta/Login" method="post">
//Os elementos do formulário
</form>
```
A diretiva **@addTagHelper** torna as Tag Helpers disponíveis para uma View.

Ao criar uma aplicação ASP .NET Core, o arquivo Views/_ViewsImports.cshtml que será herdado por todas as views da pasta /Views e subpastas. Será criado com o seguinte conteúdo:
```
@addTagHelper*,Microsoft.AspNetCore.Mvc.TagHelpers
```

### Formulários com Tag Helpers

Para a criação de elementos de formulário, temos um conjunto de Tag Heleprs descritos a seguir:
- Input Tag Helper
- TextArea Tag Helper
- Validation Tag Helper
- Label Tag Helper
- Select Tag Helper

O recurso do Intellisense também está disponível para as Tag Helpers.

### **Tag Helper Form**

- Gera o valor de atributo Action **HTML< FORM >** para uma Action de um controlador MVC ou uma rota nomeada;
- Gera um **Token de Verificação de Solicitação** oculto para evitar a falsificação de solicitações entre sites (quando usado com o atributo **[ValidateAntiForgeryToen]** no método de action HTTP Post);
- Fornece o atributo asp-route- < Nome do parâmetro** >, no qual < **Nome do parâmetro** > é adicionado aos valores da rota. Os parâmetros **routeValues&&** para Html.BeginForm e Html.BeginRouteForm fornecem funcionalidades semelhante;
- Possui os HTML Helpers alternativos: **HTML Html.BeginForm** e **Html.BeginRouteForm**;

`Exemplo`
```
<form asp-controller="Demo" asp-action="Registro" method="post">
    <!-- elementos Input e Submit-->
</form>
```
Gera a seguinte saída HTML:
```
<form method="post" action="/Demo/Registro">
    <!--elementos Input e Submit-->
     <input name="__RequestVerificationToken" type="hidden" value="<.....>"/>
</form>
```

### **Tag Helper Input**

A Tag Helper Input vincula um elemento **HTML < input >** a uma expressão de modelo na sua view razzor. A sintaxe usada é:
```
<Input asp-for="<Nome da expressão>"/>
``` 
A **Tag Helper Input** define o atributo de tipo HTML com base nos tipos da .NET framework.

|Tipo .NET|Input Type|
|---|---|
|Bool   |type="checkbox"|
|String   |type="text"   |
|DateTime   |type="datetime"   |
|Byte   |type="number"   |
|Int   |type="number"   |
|Single, Double   |type="number"   |


| Atributo  | Input Type  |
|---|---|
| [EmailAddress]  |type="email"   |
| [Url]  |type="url"   |
| [HiddenInput]  |type="hidden"   |
| [Phone]  | type="tel"  |
| [DataType(DataType.Password)]  |type="password"   |
| [DataType(DataType.Date)]  |type="date"   |
| [DataType(DataType.Time)]  |type="time"   |

---

## Áreas

As **Áreas** podem ser definidas como unidades funcionais menores em um projeto ASP.NET Core MVC com seu próprio conjunto de **Controllers, Views e Models**.

Elas são usadas para organizar funcionalidades relacionadas em um grupo separado, e ajudam a gerenciar a aplicação de maneira organizada, uma vez que separa cada aspecto funcional em uma **Área** diferente.

### Áreas - Quando usar

Quando sua aplicação for composta de **múltiplos componentes** funcionais de alto nível que podem ser separados logicamente ou se você deseja **particionar** seu projeto MVC para que cada área funcional possa ser tratada de forma independente.

### Áreas - Características

Uma aplicação ASP.NET Core MVC pode possuir **qualquer número de Áreas**. Cada área possui seus próprios Controllers, Views e Models.

Obs: Suporta múltiplos Controllers com o mesmo nome, desde que estejam em Áreas **diferentes**.

### Áreas - Exemplo

```
Nome_Projeto
   Areas
      Produtos
         Controllers
            HomeController
            ProdutosController
         Views
            Home
               Index
            Produtos
               Index
      Categorias
         Controllers
            CategoriasController
         Views
            Categoria
               Index
```

---

## Roteamento de Endpoint

O roteamento é o processo pelo qual o processo pelo qual o framework ASP .NET Core inspeciona os requests HTTP de entrada e faz o mapeamento destes requests para **executar os métodos Action correspondente do controlador**.

### Responsabilidades do Roteamento

- 1- Mapear os requests de entrada para Action do Controlador
- 2- Gerar a URL de saída que corresponde às ações do Controller

### Endpoint

Um **Endpoint** é um objeto que contém tudo que você precisa para executar um **Request de entrada**:
- 1- Os metadados do Request
- 2- O **delegate** que a ASP .NET Core usa para processar o Request

Os endpoints são definidos pelo método **UseEndpoints** (Usando a configuração feita no arquivo **Startup**).

#### Configurando um Endpoint: Roteamento Convencional (MVC)

```cs
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
   ...
   app.UseEndpoints(endpoints =>
   {
      endpoints.MapControllerRoute(
         name:"default",
         pattern:"{controller=Home}/{action=Index}/{id?}");
   });
}
```
O código acima pode ser simplificado:
```
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
   ...
   app.UseEndpoints(endpoints =>
   {
      endpoints.MapDefaultControllerRoute();
   });
}
```

Além do roteamento convencional, podemos usar os seguintes métodos para criar roteamentos personalizados:
- **MapControllers**
- **MapGet()**
- **UseRouting()**

### Utilizando o **MapControllerRoute()**, podemos até criar múltiplas rotas:

```cs
...
endpoints.MapControllerRoute(
   name:"teste",
   pattern:"testeme",
   defaults: new {controller = "teste", Action="index"});

endpoints.MapControllerRoute(
   name:"admin",
   pattern:"admin/{action=Index}/{id?}",
   defaults: new {controller = "admin"});

endpoints.MapControllerRoute(
         name:"default",
         pattern:"{controller=Home}/{action=Index}/{id?}");
```

**Atenção**:
- O campo *name*: O Nome da rota tem de ser único.
- O campo *pattern*: Precisa de um padrão URL da rota.
- O campo *defaults*: Contém valores padrão para os parâmetros de rota.
- A ordem em que as rotas são registradas é muito importante, uma vez que as rotas convencionais são avaliadas na ordem em que são configuradas. A avaliação inicia na parte superior e para quando encontra a primeira correspondência.

#### Configurando um **Endpoint** no arquivo **Program** (.NET 6.0)

```cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build
...

app.MapControllerRoute(
   name:"default",
   pattern:"{controller=Home}/{action=Index}/{id?}");
```

---

## Autenticação de Login

Existem 2 opções para usar o template padrão:
- 1- No **Visual Studio** configurar a autenticação para usar o tipo de autenticação **IndividualAccounts** ao criar o projeto.

- 2- Linha de comando com NET CLI e VS Code:
   ```
   dotnet new mvc --auth Individual -o mvc1
   ```

**ASP .NET Core Identity** - Suporte ao Login e gerenciamento de usuários e senhas. É o sistema de associação que adiciona recursos de login e autenticação.

**Microsoft.AspNetCore.Identity.EntityFrameworkCore** - É o provedor de identidade ASP .NET Core que usa o Entity Framework Core.

- **IdentityRole**: uma classe interna do Identity que fornece informações sobre perfis do usuário.

- **AddEntityFrameworStores**: permite armazenar e recuperar informações de usuário e do perfil usando o EF Core para o SQL Server.

- **AddDefaultTokenProviders**: Inclui **provedores de token** padrão para redefinir senha, alterar email, no. de telefone e geração de token para autenticação em dois fatores.

### Tag Helpers usadas na Validação
- 1- `asp-validation-summary`

É usada para exibir um resumo das mensagens de validação no formulário.

|  **asp-validation-summary** | Mensagem de validação exibida  |
|---|---|
|  All |  Propriedades e model |
|  ModelOnly | Model  |
|  None | Nenhuma  |

- 2- `asp-validation-for`

Anexa as mensagens de erro de validação no campo de entrada da propriedade de modelo especificada. Quando ocorre um erro de validação do lado do usuário, o jQuery exibe a mensagem de erro no elemento < span >.

### AntiForgeryToken 
Evita ataques CSRF (Cross Site Request Forgery).

Os passos para o registro/logar:


1- O cliente solicita uma página HTML que contém um formulário.

2- A ASP.NET Core inclui dos tokens na resposta.
   - Um token é enviado como um cookie HTTP cifrado
   - O outro é colocado em um campo oculto do formulário(*hidden*)

3- Os tokens são gerados aleatoriamente para que um hacker não consiga adivinhar os valores.

4- Quando o cliente envio o formulário, ele deve enviar os dois tokens de volta ao servidor.

5- O cliente envia o token do cookie e o token do formulário dentro dos dados do formulário.

6- Se uma solicitação não incluir os dois tokens, que devem ser iguais, o servidor não permitirá a solicitação.

O atributo [ValidateAntiForgeryToken] é usado para validar o token gerado na View.

### Verificar se o usuário está autenticado

**Via Código**

`Exemplo`
```cs
if(User.Identity.IsAuthenticated)
{
   return View();
}

return RedirectToAction("Login", "Account");
```
**Atributo [Authorize]**
Usar o Atributo [Authorize] em um Controller ou em uma Action de um Controller. Esse atributo só permite acesso a usuários autenticados.

`Exemplo 1`
```cs
[Authorize]
public class ContatoController : Controller
{
   public IActionResult Index()
   {
      return View();
   }
}
```
Neste caso, verifica-se somente se o usuário está autenticado. E a verificação é feita em **TODOS** os métodos Action do Controller.

`Exemplo 2`
```cs
[Authorize(Roles="Admin")]
public class ContatoController : Controller
{
   public IActionResult Index()
   {
      return View();
   }
}
```
Novamente a verificação é feita em **Todos** os métodos Action do Controller, mas além do usuário estar autenticado, verifica-se também se o perfil é um *Admin*.

Obs: Podemos utilizar o atributo [Authorize] para **Actions específicas**, assim somente essas Actions do Controlador que terão restrição de acesso.

**Atributo [AllowAnonymous]**: Ao utilizar este atributo no Controller ou na Action permite-se acesso a usuários não autenticados. Este atributo é útil  quando queremos deixar alguma Action disponível para usuários não autenticados em um Controller com o atributo **[Authorize]**.