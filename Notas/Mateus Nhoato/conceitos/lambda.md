# Expressão lambda
Uma **expressão lambda** é um *método anônimo* que podemos usar para criar *delegates* ou tipos de **árvore de expressão**.

Usando **expressões lambda**, podemos gravar *métodos locais*, que podem ser passados como argumentos ou serem retornados como o valor de chamadas de método.

## Sintaxe
Uma Expressão lambda tem um lado <font color="green">esquerdo</font> e um lado <font color="blue">direito</font>, seperados pelo *operador lambda* <font color="darkred">=></font> (significa "vá para").

Exemplo:

<font color="green">x</font> <font color="darkred">=></font> <font color="blue">x * x</font>

- <font color="green">Parâmetro de entrada</font>
- <font color="darkred">Operador lambda</font>
- <font color="blue">Tratamento da expressão, ou blocos de instruções. Gera o resultado esperado (no caso x * x).</font>

## Surgimento das Expressões Lambdas

Vamos utilizar de um exemplo para ilustrar o porquê do surgimento das expressões lambdas.

```cs
// lista de nomes
List<string> nomes = new();
nomes.Add("Maria");
nomes.Add("José");
nomes.Add("Sabrina");
nomes.Add("Ricardo");
nomes.Add("Pedro");

// função para consulta
static bool VerificaNomeNaLista(string nome)
{
    return nome.Equals("Pedro");
}


// consulta na lista passando como parâmetro uma função
string? resultado = nomes.Find(VerificaNomeNaLista("Pedro"));

// imprindo o resultado
Console.WriteLine(resultado);
```

Saída:

```
Pedro
```

No exemplo acima estamos passando um ***delegate predicate*** para a consulta. Isto é um predicato que aceita uma string (mesmo tipo de objeto que a lista) e retorna um bool. Mas perceba como essa função é "hard coded", pois dentro dela só estamos checkando para um nome específico que digitamos (Pedro, no caso).

A evolução desse método foi começar a passar delegates anônimos para fazer a consulta, mas ainda não era a melhor alternativa. As expressões lambdas foram introduzidas para *simplificar* ainda mais o código, pois ela permite passar uma expressão embutida como um delegate com uma sintaxe enxuta.

```cs
...
//fazendo consulta com delegate anônimo
string? resultado1 = nomes.Find(delegate (string nome){
    return nome.Equals("José");
});

// fazendo a consulta com uma expressão lambda
string? resultado2 = nomes.Find(nome => nome.Equals("Pedro");
);

// imprindo o resultado
Console.WriteLine(resultado1);
Console.WriteLine(resultado2);
```

Saída:

```
José
Pedro
```