# LINQ

## Tabela de Conteúdo
- [Introdução](#introdução)
    - [Retornos](#retornos-da-linq)
    - [Vantages](#vantages-da-linq)
    - [Desvantagens](#desvantagens-da-linq)
- [Consulta](#consulta)
- [Sintaxe de Consultas](#sintaxe-de-consultas-linq)
    - [Query Syntax](#query-syntax)
    - [Method Syntax](#method-syntax)
    - [Tipos de Consulta](#tipos-de-consulta)
- [Operações](#operações)
    - [Filtrar Dados](#filtrar-dados)
    - [Projeção](#projeção)
    - [Conjunto](#conjunto)
    - [Ordenação](#ordenação)
    - [Agregação](#agregação)
- [Créditos](#créditos)

---

## Introdução

`Language-Integrated Query(LINQ)` é um poderoso conjunto de tecnologias baseado na integração de recursos de consulta na linguagem C#.

A LINQ fornece uma experiência de consulta consistente para consultar objetos, bancos de dados relacionais, xml, entidades e outras fontes de dados. Além disso, possui uma sintaxe de consulta estruturada usando C#.

![Linq](img/linq1.png)
==As consultas LINQ retornam resultados como objetos.==

![Linq](img/linq2.png)
 Logo, permite usar uma abordagem orientada a objetos no conjunto de resultados sem se preocupar em transformar diferentes formatos de resultados em objetos.

 
## Retornos da LINQ

As consultas LINQ usam métodos de extensão para classes que implementam as [interfaces](conceitos/interface.md) **IEnumerable** ou **IQueryable**.

**Enumerable** e **Queryable** são duas classes estáticas que contêm métodos de extensão para escrever consultas LINQ.

Isso significa que podemos chamar os métodos LINQ em qualquer objeto que implemente **IEnumerable< T >** e **IQueryable < T >** . Podemos criar classes que implementam essas interfaces, que vão 'herdar' todas as funcionalidades da LINQ.

### IEnumerable< T >

É uma interface que garante que uma determinada classe seja *iterável*.
Uma classe que implementa IEnumerable< T > pode ser pensada e usada como uma sequência de elementos.

**Os métodos da link que retornam sequências são todas sequências do tipo `IEnumerable<T>`**. Para transformar estas sequências em listas ou arrays, a LINQ fornece dois métodos de conversão:
1. **ToList()** - converte um IEnumerable< T> para um List< T >
2. **ToArray()** - converte um IEnumerable< T > para um Array< T >

## Vantages da LINQ

- Fornece uam sintaxe de consulta comum para consultar diferentes fontes de dados.
- Utiliza menos código em comparação com a abordagem tradicional de consulta.
- Fornece verificação de erros em tempo de compilação, bem como suporte de inteligência no Visual Studio, evitando erros em tempo de execução.
- Fornece muitos métodos embutiods que podemos usar para realizar diferentes operações, como filtragem, ordenação, agrupamento, etc.
- Permite a reutilização de consultas.

## Desvantagens da LINQ

- Consultas muito complexas são difícieis de escrever
- Não aproveita ao máximo os recursos da SQL, como o plano de execução em cache para o procedimento armazenado.
- Consultas mal escritas tendem a ter um desempenho pior.
- Alterações nas consultas exigem recompilar a aplicação e refazer o deploy.

---

## Consulta

Os métodos LINQ que retornam IEnumerable< T > têm um conceito de **execução lenta** (também chamada de adiada ou lazy execution).

==Todos os métodos genéricos LINQ podem **inferir implicitamente argumentos de tipo**, portanto não precisamos especificá-los  (na maioria dos casos usamos *var*).==

A maioria dos métodos LINQ aceita [delegates](conceitos/delegates.md) Func<> e Predicate<>. A opção mais comum para fornecer um delegate é escrever uma [**expressão lambda**](conceitos/lambda.md).

Ao trabalhar com a interface IQueryable< T >, a consulta é compilada (em SQL, por exemplo) e executada remotamente.

### Execução Imediata na LINQ

O padrão da LINQ é somente fazer a consulta quando é necessário, para forçar a consulta LINQ a ser executada e a retornar o resultado imediatamente, é necessário usar os operadores de conversão:

- ToList()
- ToArray()
- AsEnumerable
- AsQueryable
- ToDicitionary()
- ToLookup


## Sintaxe de consultas LINQ

Existem dois tipos, **Query Syntax** e **Method Syntax**.

### **Query Syntax** 
Também conhecida como Query Expression Syntax (Sintaxe de Consulta).

É um tipo de consulta usada em bancos de dados SQL.
```sql
FROM objeto in FonteDeDados
Where condicao
Select objeto
```
1. Inicialização: iniciamos com alguma fonte de dados para consultar usando a palavra-chave, ou cláusula, `FROM`.
2. Condição: Usamos operadores de consulta para adicionar **condições** para a consulta, começando com a palavra-chave `Where`.
3. Seleção: Agrupamos ou selecionamos os objetos que queremos, usando a palavra-chave `Select`, ou podemos usar `GroupBy`.

==*Obs*: No final podemos utilizar a palavra **var** para tratar o resultado, mas o tipo de objeto que a consulta gerará será do tipo *IEnumerable* ou *IQueryable*.==

Exemplo:
```cs
IList<string> frutas = new List<string>()
{
    "Banana", "Maça", "Uva", "Melão", "Laranja", "Pera"
};

var resultado = from f in frutas      // inicializando com a cláusula from
                where f.Contains('r') // usando operador para filtrar
                select f;            // terminando com cláusula select ou GroupBy

Console.WriteLine(string.Join(", ", resultado));
```
Saída no console:
```
Pera, Laranja
```


### **Method Syntax**

Também conhecida como Method Extension Syntax ou Fluent Syntax (Sintaxe de Método).

- Usa métodos de extensão incluídos nas classes estáticas **Enumerable** ou **Queryable**.
- ==Nem todos os métodos LINQ podem ser utilizados com sintaxe de consulta, um dos motivos da sintaxe de método levar vantagem. Além disso, a sintaxe de método é estilisticamente semelhante ao código C#.==
- A maior diferença na hora de se escrever uma consulta com a Sintaxe de Método, é que utilizamos um *Delegate Predicate* que receba o mesmo tipo de objeto que a consulta e retorne um **bool**. Geralmente esse delegate é feito com expressões **lambdas**, e serve para filtrar, agrupar, ordenar, ou fazer outras coisas com a fonte de dados que estamos trabalhando.

Exemplo:
```cs
IList<string> frutas = new List<string>()
{
    "Banana", "Maça", "Uva", "Melão", "Laranja", "Pera"
};

var resultado = frutas.Where(f => f.Contains('r'));
// o método Where seria o método de extensão
// enquanto a expressão lambda dentro deste método
// seria a condição da consulta

Console.WriteLine(string.Join(", ", resultado));
```
Saída no console:
```
Pera, Laranja
```

*==Obs*: O compilador converte a sintaxe de consulta em sintaxe de método em tempo de compilação.==

### `Tipos de consulta`
![Linq](img/linq3.png)

---

## Operações

### Filtrar Dados

Operadores de filtragem são usados para filtrar dados de uma **lista/coleção** com base nas condições do filtro. Usamos uma expressão booleana e somente os objetos que atenderem os requisitos dessa expressão são retornados.

- `Where` - usado para selecionar valores da coleção com base em *funções de predicado*
    ```
    fonteDados.Where(<expressão_lambda>);
    ```

Exemplo:
```cs
List<int> numeros = new List<int>();
numeros.Add(1);
numeros.Add(2);
numeros.Add(4);
numeros.Add(8);
numeros.Add(16);
numeros.Add(32);
numeros.Add(64);

List<int> numeros2 = new List<int>();
numeros2.Add(8);
numeros2.Add(16);
numeros2.Add(64);

// selecionando os números menores que 10
var resultado1 = numeros.Where(n => n < 10);

//  selecionando os números maiores que 1, menores que 20, e excluímos o 4
var resultado1 = numeros.Where(n => n > 1 && n != 4 && n < 20);

// selecionando todos os números da lista numeros menos os que também estão presentes na lista numeros2
var resultado3 = numeros.Where(n => !numeros2.Contains(n));

// mesmo resultado que o segundo exemplo, mas com o uso de 3 .Where seguidos
var resultado4 = numeros.Where(n => n > 1)
                        .Where(n=> n != 4)
                        .Where(n => n < 20);

Console.WriteLine(string.Join(" "), resultado1);
Console.WriteLine(string.Join(" "), resultado2);
Console.WriteLine(string.Join(" "), resultado3);
Console.WriteLine(string.Join(" "), resultado4);
```
Saída:
```
1 2 4 8
2 8 16
1 2 4 32
2 8 16
```

==Apesar de escrevermos as consultas de maneiras diferentes nos exemplos 2 e 4, não há diferença na velocidade e nem na performance dessas consultas. O compilador vai otimizar a consulta em ambos os casos.==

#### *Filtrando objetos complexos*

```cs
public class Aluno{
    public string Nome {get; set;}
    public int Idade {get; set;}
}

List<Aluno> alunos = new List<Aluno>();
alunos.Add("Maria", 18);
alunos.Add("João", 20);
alunos.Add("Pedro", 25);
alunos.Add("Marlene", 28);
alunos.Add("Fabio", 23);

// sintaxe de método
// selecionando os alunos que têm nomes começados em M e que têm menos de 20 anos de idade 
var resultado = alunos.Where(a => a.Nome.StartsWith('M') 
                            && a.Idade < 20);

foreach(var aluno in resultado)
    {
        Console.WriteLine(aluno.Nome + " - " + aluno.Idade);
    }

// sintaxe de consulta
// mesma consulta que a anterior
var resultado2 = from aluno in alunos 
                where aluno.Nome.StartsWith('M') 
                && aluno.Idade < 20
                select aluno;

foreach(var aluno in resultado2)
    {
        Console.WriteLine(aluno.Nome + " - " + aluno.Idade);
    }

```
Saída:
```
Maria - 18
Maria - 18
```

### Projeção

É o mecanismo usado para selecionar os dados de uma fonte de dados.

Usado para:

1. Selecionar todos os dados no estado original.
2. Criar um novo formato de dados realiazndo operações nos dados originais.

Temos dois métodos usados para projeção na Linq:
- `Select`
    ```
    Permite especificar quais propriedades queremos recuperar: todas as propriedades ou algumas das propriedades.

    Permite realizar alguns cálculos.
    ```
- `SelectMany`
    ```
    É usado para projetar cada elemento de uma sequência para um IEnumerable<T> e, em seguida, nivelar as sequências resultantes em uma sequência.

    Combina os registros de uma sequência de resultados e os converte em um resultado.

    Ele transforma um IEnumerable<IEnumerable<T>> em IEnumerable<T>, ou seja, uma lista de lista para uma lista.
    ```

#### **Exemplos com Select**:

```cs
public class Pessoa{
    // atributos
    public string Nome {get; set;}
    public int Idade {get;set;}
    public double Altura {get;set;}
    
    // construtores
    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public Pessoa(string nome, int idade, double altura) : base(nome, idade)
    {
        Altura = altura;
    }
}

List<Pessoa> pessoas = new List<Pessoa>();
pessoas.Add(new Pessoa("Maria", 20, 1.68));
pessoas.Add(new Pessoa("João", 17, 1.80));
pessoas.Add(new Pessoa("Diego", 26, 1.76));
pessoas.Add(new Pessoa("Carla", 31, 1.73));
pessoas.Add(new Pessoa("Roberta", 35, 1.70));


//selecionando apenas o nome das pessoas
List<string> nomePessoas = pessoas.Select(p => p.Nome);

foreach(string nome in nomePessoas)
    Console.WriteLine(nome);

//fazendo novos objetos do mesmo tipo com o outro construtor
List<Pessoa> pessoas2 = pessoas.Select(p => new Pessoa(p.Nome, p.Idade)).ToList();

foreach(Pessoa p in pessoas2)
    Console.WriteLine($"{p.Nome} - {p.Idade}");

//criando objetos anônimos com a lista de pessoas
var pessoasTipoAnonimo = pessoas.Select(p => new
                                    {
                                        Nome = p.Nome,
                                        Idade = p.Idade,
                                        Altura = p.Altura
                                    }).ToList();

foreach(var anonimo in pessoasTipoAnonimo)
    Console.WriteLine($"{anonimo.Nome} - {anonimo.Idade} - {anonimo.Altura}");

```
Saída:
```
Maria
João
Diego
Carla
Roberta
Maria - 20  
João -  17
Diego - 26
Carla - 31  
Roberta - 35
Maria - 20 - 1.68
João -  17 - 1.80
Diego - 26 - 1.76
Carla - 31 - 1.73
Roberta - 35 - 1.70
```

```cs
public class Funcionario
{
    public string Nome {get; set;}
    public int Idade {get; set;}
    public decimal Salario {get; set;}
}

List<Funcionario> funcionarios = new List<Funcionario>();
funcionarios.Add(new Funcionario()
{
    Nome = "Manoel",
    Idade = 38,
    Salario = 4125.45m
});

funcionarios.Add(new Funcionario()
{
    Nome = "Carlos",
    Idade = 20,
    Salario = 2726.31m
});

funcionarios.Add(new Funcionario()
{
    Nome = "Alice",
    Idade = 27,
    Salario = 5817.67m
});

// calculando o salário anual de cada funcionário com tipo anonimo
var funcionariosSalarioAnual = funcionarios.Select(f => new
                                            {
                                                Nome = f.Nome,
                                                SalarioAnual = f.Salario * 12
                                            }).ToList();

foreach(var func in funcionariosSalarioAnual)
    Console.WriteLine($"{func.Nome} - R$ {func.SalarioAnual}");
```
Saída
```
Manoel - R$ 49.505.40
Carlos - R$ 32.715.72
Alice - R$ 69.812.04
```

#### **Exemplos com SelectMany**:

```cs
List<List<int>> listas = new List<List<int>>()
{
    new List<int>() {1, 2, 3},
    new List<int>() {12},
    new List<int>() {5, 6, 5, 7},
    new List<int>() {10, 10, 10, 12, 13}
};

IEnumerable<int> resultado = listas.SelectMany(lista => lista);

foreach(var i in resultado)
    Console.Write(i + " ");
Console.WriteLine();

//agora pegando elementos distintos
IEnumerable<int> resultado2 = listas.SelectMany(lista => lista.Distinct());

foreach(var n in resultado2)
	Console.Write(i + " ");
```
Saída:
```
1 2 3 12 5 6 5 7 10 10 10 12 13
1 2 3 12 5 6 7 10 13
```

#### **Comparando Select com SelectMany**:

```cs
public class Aluno{
	public string Nome {get; set;}
	public int Idade {get; set;}
	public List<string> Cursos {get; set;}
}

List<Aluno> alunos = new List<Aluno>()
{
	new Aluno("Maria", "18", new List<string>{"C#", "POO"});
	new Aluno("Alberto", "31", new List<string>{"Javascript", "HTML5", "CSS"});
	new Aluno("Miguel", "23", new List<string>{"Node", "React"});
};

// usando Select
IEnumerable<List<String>> retornoSelect = alunos.Select(a => a.Cursos);

foreach(List<String> listaCursos in retornoSelect)
{
	foreach(string curso in listaCursos)
	{
		Console.Write(curso + " ");
	}
	Console.WriteLine();
}

// usando SelectMany
IEnumerable<String> retornoSelectMany = alunos.SelectMany(a => a.Cursos);

foreach(string curso in retornoSelectMany)
{
	Console.Write(curso + " ");
}

```

Saída:
```
C# POO
Javascript HTML5 CSS
Node React
C# POO Javascript HTML5 CSS Node React
```

### Conjunto

As operações de conjunto na LINQ referem-se a operações de consulta que geram um conjunto de resultados baseado *na presença ou ausência de elementos equivalentes* dentro do(s) mesmo(s) conjunto(s). Isso significa que essas operações são executas em uma única fonte de dados ou em várias fontes de dados, e , na saída, alguns dos dados estão presentes enquanto outros estão ausentes.

Temos 4 operadores usados nas consultas de LINQ para operações de conjunto:

1. `Distinct` ou `DistinctBy`  - Remove os valores duplicados de uma coleção.
```
Usado quando queremos remover os dados ou registros duplicos de uma fonte de dados. 
Este método opera em uma única fonte de dados.

O método Distinct tem uma sobrecarga que aceita um IEqualityComparer<T>, isto é, ele aceita um parâmetro de comparação para poder distinguir os objetos.
```

2. `Except` ou `ExceptBy` - Retorna a diferença de conjunto, ou seja, os elementos de uma coleção que não aparecem em uma segunda coleção.
```
Usando quando queremos retornar todos os elementos da primeira fonte de dados que não estão presentes na segunda fonte de dados. Este método opera em duas fontes de dados.

Except tem uma sobrecarga que aceita um IEqualityComparer<T>.
```

3. `Intersect`  ou `IntersectBy` - Retorna a interseção de conjunto, ou seja, os elementos em comum de todas as coleções na consulta.
```
É usado para retornar os elementos comuns de ambas as fontes de dados.

Intersect tem uma sobrecarga que aceita um IEqualityComparer<T>.
```

4. `Union`  ou `UnionBy` - Retorna a união de conjunto, ou seja, os elementos únicos que aparecem em qualquer uma das coleções.
```
É usado para retornar todos os elementos que estão presentes em qualquer uma das fontes de dados. Isso singnifica que ele combina os dados de ambas as fontes de dados e produz um único conjunto de resultados.

Union tem uma sobrecarga que aceita um IEqualityComparer<T>.
```

==A diferença entre o método comum e o metódo com by de sufixo, é que o primeiro, ao ser utilizado em uma consulta de um objeto com múltiplos atributos, retornará um IEnumerable só com aquele atributo. Enquanto que utilizando o método + by será retornado um IEnumerable do objeto em si, logo teremos acesso ao objeto como um todo. O uso do método comum e do método com by é relativo à situação. ==


Exemplos de `Distinct`:

```cs
var idades = new[]{30,33,35,36,40,30,33,36,30,40,35};

// Sintaxe de consulta:
var resultado = (from num in idades select num).Distinct();

//Sintaxe de método, 3 formas de fazer:

// retorna uma array e a execução é feita na hora
var idadesDistintas = idades.Distinct().ToArray();

// retorna uma lista e a execução é feita na hora
var idadesDistintas = idades.Distinct().ToList();

// retorna um IEnumerable, mas a execução é adiada
var idadesDistintas = idades.Distinct();

foreach(var idade in idadesDistintas)
	Console.Write(idade + " ");

string[] nomes = {"Maria", "MARIA", "maria", "PEDRO", "Pedro", "juliana", "Juliana"};

var nomesDistintos = nomes.Distinct();

// Porque não passamos nenhum parâmetro para comparação, a comparação padrão do objeto (String, no caso) foi usada e a conclusão é que são todos objetos diferentes
foreach(string nome in nomesDistintos)
	Console.Write(nome + " ");
Console.WriteLine();


//vamos agora fazer uma consulta com a sobrecaraga do Distinct, usando um IEqualityComparer que é case insensitive
var nomesDistintos = nomes.Distinct(StringComparer.OrdinalIgnoreCase);

foreach(string nome in nomesDistintos)
	Console.Write(nome + " ");
```

Saída:

```
30 33 35 36 40
Maria MARIA maria PEDRIO Pedro juliana Juliana
Maria, PEDRO, juliana
```

Agora vamos misturar os dois exemplos acima com uma classe Aluno:

```cs
public class Aluno
{
	public string Nome {get; set;}
	public int Idade {get; set;}

	public Aluno(string nome, int idade)
	{
		Nome = nome;
		Idade = idade;
	}
}

List<Aluno> alunos = new List<Aluno>();
alunos.Add(new Aluno("Maria", 18));
alunos.Add(new Aluno("Carlos", 16));
alunos.Add(new Aluno("Roberto", 18));
alunos.Add(new Aluno("Marina", 23));
alunos.Add(new Aluno("Maria", 36));
alunos.Add(new Aluno("Carlos", 23));

// consulta que retorna todos os alunos de idade distinta
var alunosIdadesDistintas = alunos.DistinctBy(a => a.Idade);

foreach(Aluno aluno in alunosIdadesDistintas)
	Console.WriteLine($"{aluno.Nome} {aluno.Idade}");

Console.WriteLine("----------");

// consulta que retorna todos os alunos de nome distinto
var alunosNomesDistintos = alunos.DistinctBy(a => a.Nome);

foreach(Aluno aluno in alunosNomesDistintos)
	Console.WriteLine($"{aluno.Nome} {aluno.Idade}");
```

Saída:

```
Maria 18
Carlos 16 
Marina 23 
Maria 36
----------
Maria 18
Carlos 16 
Roberto 18 
Marina 23 
```

Exemplos de `Except`:
```cs
int[] array1 = {1, 2, 3, 4, 5};
int[] array2 = {1, 3, 6, 8};

//Sintaxe de Consulta
var resultado = (from num in array1
				select num)
				.Except(array2).ToList();

//Sintaxe de método
var resultado2 = array1.Except(array2).ToList();

foreach(int i in resultado)
	Console.Write(i + " ");
Console.WriteLine();

string[] paises1 = {"Brasil", "USA", "Irlanda", "Japão", "Argentina", "China"};
string[] paises2 = {"Brasil", "usa", "Irlanda", "Paraguay", "Dinamarca", "India"};

var resultado3 = paises1.Except(paises2).ToList();

foreach(string pais in resultado3)
	Console.Write(pais + " ");
Console.WriteLine();

//passando um IComparer na consulta
var resultado4 = paises1.Except(paises2, StringComparer.OrdinalIgnoreCase);

foreach(string pais in resultado4)
	Console.Write(pais + " ");
Console.WriteLine();

```

Saída:
```
2 4 5
USA Japão Argentina China
Japão Argentina China
```

Agora vamos misturar os dois exemplos acima com uma classe Aluno:

```cs
public class Aluno
{
	public string Nome {get; set;}
	public int Idade {get; set;}

	public Aluno(string nome, int idade)
	{
		Nome = nome;
		Idade = idade;
	}
}

List<Aluno> alunos = new List<Aluno>();
alunos.Add(new Aluno("Maria", 18));
alunos.Add(new Aluno("Carlos", 16));
alunos.Add(new Aluno("Roberto", 18));
alunos.Add(new Aluno("Marina", 23));
alunos.Add(new Aluno("Débora", 36));
alunos.Add(new Aluno("Marcos", 23));

//fazendo uma lista de nomes dos alunos reprovados
List<string> alunosReprovados = new List<string>(){"Carlos", "Marina"};

//fazendo a consulta dos alunos aprovados
var alunosAprovados = alunos.ExceptBy(alunosReprovados, a => a.Nome);

foreach(Aluno aluno in alunosAprovados)
	Console.WriteLine($"{aluno.Nome}");

```

Saída:

```
Maria
Roberto
Débora
Marcos
```

Exemplos de `Intersect`:

```cs
List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6};
List<int> numeros2 = new List<int>() {1, 3, 5, 8, 9, 10};

//Sintaxe de consulta
var resultado = (from num in numeros 
				select num).Intersect(numeros2).Tolist();

//Sintaxe de método
var resultado = numeros.Intersect(numeros2).ToList();

foreach(int i in resultado)
	Console.Write(i + " ");
Console.WriteLine();

string[] frutas = {"banana", "morango", "melão", "uva", "laranja", "maça"};
string[] frutas2 = {"ABACAXI", "MORANGO", "PERA", "MAÇA", "BANANA"};

var resultado = frutas.Intersect(frutas2, StringComparer.OrdinalIgnoreCase).ToList();

foreach(string fruta in frutas)
	Console.Write(fruta + " ");
Console.WriteLine();
```

Saída:

```
1 3 5
banana morango maça
```

```cs
public class Funcionario
{
	public string Nome {get; set;}
	public string Departamento {get; set;}
	...
}

List<Funcionario> funcionariosDaManha = new List<Funcionario>();

funcionariosDaManha.Add(new Funcionario()
						{
							Nome = "Luis",
							Departamento = "Vendas"
						});

funcionariosDaManha.Add(new Funcionario()
						{
							Nome = "Cláudia",
							Departamento = "Administração"
						});

funcionariosDaManha.Add(new Funcionario()
						{
							Nome = "Fátima",
							Departamento = "Atendimento"
						});

List<Funcionario> funcionariosDaNoite = new List<Funcionario>();

funcionariosDaNoite.Add(new Funcionario()
						{
							Nome = "Maria",
							Departamento = "Vendas"
						});

funcionariosDaNoite.Add(new Funcionario()
						{
							Nome = "Ricardo",
							Departamento = "Administração"
						});

funcionariosDaNoite.Add(new Funcionario()
						{
							Nome = "Lucas",
							Departamento = "Limpeza"
						});

// esta consulta irá retornar todos os funcionários da manhã que também tem algum membro de seu departamento na lista defuncionários da noite
var funcionariosDoMesmoDepartamento = funcionariosDaManha.IntersectBy(funcionariosDaNoite
								.Select(f => f.Departamento),
								 f => f.Departamento);

foreach(var f in funcionariosDoMesmoDepartamento)
    Console.WriteLine(f.Nome + " " + f.Departamento);
```

Saída:

```
Luis Vendas
Cláudia Administração
```

Exemplos de `Union`:

```cs
int[] numeros = {1,2,3,4,5};
int[] numeros2 = {3,4,6,7,8,9,10};

//Sintaxe de Consulta
var resultado = (from num in numeros select num)
				.Union(numeros2).ToList();

//Sintaxe de Método
var resultado = numeros.Union(numeros2).ToList();

foreach(var n in resultado)
	Console.Write(n + " ");
Console.WriteLine();
```

Saída:

```
1 2 3 4 5 6 7 8 9 10
```

Obs: ==não forma incluídos os números repetidos==.

### Ordenação

Os operadores de ordenação realizam o processo de gerenciar os dados em uma determinada ordem sem alterar os dados ou a saída, apenas organizando os dados em uma ordem específica, seja crescente ou decrescente. ==Estes métodos são utilizados na Sintaxe de Método, na Sintaxe de Consulta usamos outros operadores.== 

Métodos fornecidos pela LINQ para ordernar dados:

1. `OrderBy` 
```
Usado para classificar os dados em ordem crescente (ascendente), sem alterar os dados, mas apenas sua ordem.
```

2.  `OrderByDescending`
```
Usado para classificar os dados em ordem decrescente, sem alterar os dados, mas apenas sua ordem.
```

3. `ThenBy`
```
Usado após alguma outra ordenação (OrderBy ou OrderByDescending) ou filtragem de dados (Where). ThenBy ordena com um novo parâmetro em ordem crescente. Podemos ter vários ThenBy seguidos. 

Um exemplo para fácil visualização seria ordenar uma lista de pessoas por nome e então por idade, logo a idade seria um critério de desempate.
```

4. `ThenByDescending`
```
Mesmo uso que o ThenBy, mas é utilizado para ordem decrescente.
```

5. `Reverse`
```
Retorna uma nova sequência que contém todos os elementos da sequência de origem na ordem oposta.
```

==Atenção: O Reverse que estamos tratando é um método do namespace System.Linq, mas existe outro Reverse, do namespace System.Collections.Generic que tem outra função. Então cuidado ao usar o método Reverse em coleção genéricas (como List, por exemplo).==


Exemplo de `OrderBy`:

```cs
List<string> nomes = new List<string>() {"Paulo", "Pedro", "Arnaldo", "Helena", "Cleide", "Manoel", "José"};

// Sintaxe de Consulta
var lista = (from nome in nomes
			orderby nome ascending
			select nome).ToList();

//Sintaxe de método
var lista = nomes.OrderBy(nome => nome);

foreach(var item in lista)
    Console.Write(item + " ");
```

Saída:

```
Arnaldo Cleide Helena José Manoel Paulo Pedro
```

Exemplo de `OrderByDescending`:

```cs
List<string> nomes = new List<string>() {"Paulo", "Pedro", "Arnaldo", "Helena", "Cleide", "Manoel", "José"};

// Sintaxe de Consulta
var lista = (from nome in nomes
			orderby nome descending
			select nome).ToList();

//Sintaxe de método
var lista = nomes.OrderByDescending(nome => nome);

foreach(var item in lista)
    Console.Write(item + " ");
```

Saída:

```
Pedro Paulo Manoel José Helena Cleide Arnaldo
```

Exemplo de `ThenBy`:

```cs
public class Aluno
{
	public string Nome {get; set;}
	public int Idade {get; set;}

	public Aluno(string nome, int idade)
	{
		Nome = nome;
		Idade = idade;
	}
}

List<Aluno> alunos = new List<Aluno>();
alunos.Add(new Aluno("Maria", 18));
alunos.Add(new Aluno("Carlos", 16));
alunos.Add(new Aluno("Roberto", 18));
alunos.Add(new Aluno("Marina", 23));
alunos.Add(new Aluno("Débora", 36));
alunos.Add(new Aluno("Maria", 23));
alunos.Add(new Aluno("Roberto", 21));

//Sintaxe de Consulta
var lista = (from a in alunos
			orderby a.Nome, a.Idade
			select new {a.Nome, a.Idade}).ToList();

// Sintaxe de Método
var lista = alunos.OrderBy(a => a.Nome)
			.ThenBy(a => a.Idade).ToList();

foreach(var item in lista)
	Console.WriteLine($"{item.Nome} {item.Idade}");

//consulta com Where e ThenBy
var lista2 = alunos.Where(a => a.Nome.Contains("i"))
						.OrderBy(a => a.Nome)
						.ThenBy(a => a.Idade).ToList();

Console.WriteLine("--------------");
foreach(var item in lista2)
	Console.WriteLine($"{item.Nome} {item.Idade}");
```

Saída:

```
Carlos 16
Débora 36
Maria 18
Maria 23
Marina 23
Roberto 18
Roberto 21
--------------
Maria 18
Maria 23
Marina 23
```

Exemplo de `Reverse`:
```cs
int[] numeros = new int[] {10, 30, 50, 20, 70, 15, 80, 100};

//Sintaxe de Consulta
var numerosReverse = (from num in numeros
					 select num).Reverse();

//Sintaxe de Método
var numerosReverse = numeros.Reverse();

foreach(int n in numerosReverse)
	Console.Write(n + " ");

```

Saída:
```
100 80 15 70 20 50 30 10
```

==Note que a coleção não foi ordenada de nenhuma maneira, simplesmente ficou na ordem oposta.==

### Agregação

Os operadores de agregação são usados para realizar operações matemáticas em uma coleção de valores retornado um único valor.

Existem os seguintes métodos de agregação na LINQ:

1. `Aggregate`
```
Executa uma operação de agregação/acumulação personalizada nos valores da coleção.

Este método não está disponível na Sintaxe de Consulta, somente na Sintaxe de Método.

Tem 3 sobrecargas: a primeira passamos somente um Delegate Func. Na segunda definimos um valor de semente inicial, para depois passar um Delegate Func.
```

2. `Average`
```
Calcula a média dos itens numéricos em uma coleção.
```

3. `Count`
```
Conta quantos elementos uma coleção tem.
```

4. `LongCount`
```
Conta quantos elementos uma coleção grande tem.
```

5. `Max ou MaxBy`
```
Determina o valor máximo em uma coleção.
```

6. `Min ou MinBy`
```
Determina o valor mínimo em uma coleção.
```

7. `Sum`
```
Calcula a soma dos valores em uma coleção.
```

#### Exemplos:

`Agregate`
```cs
string[] cursos = { "C#", "Java", "Python", "PHP", "Go" };

string resultado = cursos.Aggregate((s1, s2) => s1 + ", " + s2);

Console.WriteLine(resultado);


// Caso de números vai acumulando também:
// A conta seria 3 * 5 = 15, 15 * 7= 105 .. até 9450
int[] numeros = { 3, 5, 7, 9, 10 };

int resultado2 = numeros.Aggregate((n1, n2) => n1 * n2);

Console.WriteLine(resultado2); 
```

Saída:

```
C#, Java, Python, PHP, Go
9450
```

`Agregate` com semente

```cs
 List<string> nomes = new List<string> { "Maria", "João", "Robson", "Tatiane"};

// Neste caso a semente seria "Nomes: "
string resultado = nomes.Aggregate("Nomes: ", (semente, nome) =>
								   semente += nome + ", ");

 //removendo a vírgula a mais do final
int indice = resultado.LastIndexOf(",");
resultado = resultado.Remove(indice);

Console.WriteLine(resultado);
```

Saída:

```
Nomes: Maria, João, Robson, Tatiane
```


## Créditos

Estas anotações foram feitas baseado nas aulas do professor Jose Carlos Macoratti, que as disponibilizou em uma [playlist](https://www.youtube.com/watch?v=Mi2_wpcawGw&list=PLJ4k1IC8GhW0yky43O7TeNwRvaVrHdOmJ) no youtube.
