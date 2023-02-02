Um **delegate** é um ponteiro para um método. Um Delegate pode ser passado como um parâmetro para um método. Podemos mudar a implementação do método dinamicamente em tempo de execução, a única coisa que precisamos para fazer isso seria manter o tipo de parâmetro e o tipo de retorno.

Um delegate é uma classe, e quando criamos uma instância do delegate passamos o nome da função como um parâmetro. O delegate então irá referenciar a função.

## Assinatura de um Delegate

Todo delegate possui uma assinatura. A assinatura de um delegate é composta de:
1. O nome do Delegate
2. Os argumentos que o delegate vai aceitar como parâmetro
3. O tipo de retorno do delegate

Exemplo:
```cs
delegate int ExemploDeDelegate(string nome, bool b);
```

No exemplo acima temos um Delegate com uma assinatura que nos diz que:
- Seu nome é ExemploDeDelegate
- Ele retorna um tipo int
- Precisa de dois parâmetros, um do tipo string e outro do tipo bool

Agora, considere a função a seguir:
```cs
private int ExemploDeFuncao(string str, bool condicao)
{
	...
}
```
Como esta função acima possui uma assinatura igual a do delegate, ela pode ser passada para o delegate da seguinte forma:

```cs
ExemploDeDelegate exemplo = new ExemploDeDelegate(ExemploDeFuncao);
```

## Uso de um Delegate

Existem três etapas na definição e uso de delegates:
1. Declaração
2. Instanciação
3. Invocação

Um exemplo das 3 etapas:

```cs
namespace Delegate;

public class Program
{
    // Declaração
    public delegate void DelegateSimples();

    // função com a mesma assinatura que o delegate
    public static void MinhaFuncao()
    {
        Console.WriteLine("Fui chamada por um delegate");
    }
   
    static void Main(string[] args)
    {
        // Instanciação
        DelegateSimples delegateSimples = new DelegateSimples(MinhaFuncao);

        // Invocação
        delegateSimples();

        // ou podemos usar o método Invoke para a invocação
        delegateSimples.Invoke();
    }
}
```

Saída:
```
Fui chamada por um delegate
Fui chamada por um delegate
```

==Note que ao invocar o delegate temos a execução do método **minhaFuncao**()==

Um delegate pode conter vários métodos e podemos invocá-los juntos:

```cs
namespace Delegate;

public class Program
{
    // Declaração
    public delegate void DelegateSimples();

    // função com a mesma assinatura que o delegate
    public static void MinhaFuncao()
    {
        Console.WriteLine("Fui chamada por um delegate");
    }
   
    public static void MinhaFuncao2()
    {
        Console.WriteLine("Função 2 foi chamada");
    }
   
    static void Main(string[] args)
    {
        // Instanciação
        DelegateSimples delegateSimples = new DelegateSimples(MinhaFuncao);

		// Adicionando outro método ao delegate
		delegateSimples += MinhaFuncao2;

        // Invocação
        delegateSimples.Invoke();
    }
}
```

Saída:
```
Fui chamada por um delegate
Função 2 foi chamada
```


## Delegate Func

O Delegate Func encapsula um método que pode possuir até 16 parâmetros e que retorna um tipo especificado pelo parâmetro **TResult**. Sua assinatura possui 17 sobrecargas:

- Func(TResult), Func<T, TResult>, Func<T1, T2, TResult>,..., Func<T1,....T16,TResult>.

Este delegate sempre segue a mesma regra: O último tipo declarado é o tipo de retorno devolvido pela função que implementa este delegate. Então, se precisar de um delegate que retorne um valor e tenha de 1 até 16 parâmetros pode usar o delegate **Func**.

### Sintaxe:

```cs
public delegate TResult Func<out TResult>

public delegate TResult Func<in T, out TResult> (T arg)

public delegate TResult Func<in T1, in T2, out TResult>(T1 arg, T2 arg)

// e mais 13 sobrecargas..
```

#### Parâmetros

- **arg** - O parâmetro do método que encapsula este delegate.

#### Parâmetros de tipo

1.  **in T** - Onde T é o tipo do parÂmetro do método que encapsula este  delegate. (Este parâmetro de tipo é contravariante. Ou seja, você pode usar o tipo especificado ou qualquer tipo que seja menos derivado)

2. **out TResult** - O tipo de valor de retorno do método que encapsula a este delegate.

#### Valor de Retorno

- Tipo: **TResult** - O valor de retorno do método que encapsula a este delegate.

##### Exemplo usando 1 parâmetro:

```cs
namespace DelegateFunc;

public class Program
{
    static void Main(string[] args)
    {
        Func<string> saudacoes = BomDia;

        Console.WriteLine(saudacoes());
    }
    
    private static string BomDia()
    {
        return "Bom dia!";
    }
}
```

Saída:

```
Bom dia!
```

##### Exemplo usando 2 parâmetros:

```cs
namespace DelegateFunc;

public class Program
{
    static void Main(string[] args)
    {
		// os primeiros dois double são os parâmetros
		// enquanto o terceiro é o TResult
        Func<double, double, double> Calcular = Adicionar;

        double resultadoSoma = Calcular(10, 20);
        Console.WriteLine(resultadoSoma);
    }

    private static double Adicionar(double x, double y) => x + y;
}
```

Saída:

```
30
```

## Usando Funções Anônimas em Delegates Func

Na linguagem C# também podemos definir delegantes usando Funções Anônimas. Uma função anônima é uma declaração *in-line*, ou expressão que pode ser usada sempre que um tipo de delegate é esperado. Podemos usá-las para inicializar um delegate nomeado ou passar uma função anônima no lugar de um tipo de delegate nomeado como parâmetro de um método.

Este recurso é válido para qualquer delegate (Action, Func, Predicate, etc...)

### Tipos de funções Anônimas

1. Métodos Anônimos (Anonymous Method)

2. [Expressões Lambdas](lambda.md) (Lambdas Expressions)



#### Usando Métodos Anônimos

Vejamos um exemplo de utilização de delegate **Func** usando métodos anônimos:

```cs
namespace DelegateFunc;

public class Program
{
    static void Main(string[] args)
    {
        Func<int, bool> IsPositivo = delegate (int numero)
        {
            return numero > 0;
        };

        Console.WriteLine($"O Número 7 é positivo? {IsPositivo(7)}");
    }
}
```

Saída:

```
O Número 7 é positivo? True
```

No código acima definimos um delegado **Func** na seguinte declaração :

```cs
 Func<int , bool> IsPositivo = delegate(int numero)  
 {  
      return numero > 0;  
 };
```

Nesta declaração estamos definindo um delegate com um método sem nome (gerado automaticamente pelo compilador), que é vinculado a instância do delegate (**IsPositivo**).

==Nota: Lembre-se que os parâmetros definidos em um método anônimo possuem escopo de boloco, ou seja, são válidos somente dentro da declaração do mêtodo anônimo.==

#### Usando [Expressões Lambdas](lambda.md)

Uma expressão lambda é uma função anônima, ou seja, um método sem uma declaração, sem modificador de acesso, sem declaração de valor de retorno e sem nome. Elas podem conter instruções e expressões, e podemos usá-las para criar delegates ou tipo de árvores de expressão. O operador lambda é identificado como " =>" e significa 'vá para'.

Sintaxe:
```
Parâmetros => código;
```

Exemplo de delegante func com expressões lambdas:

```cs
namespace DelegateFunc;

public class Program
{
    static void Main(string[] args)
    {
        Func<int, bool> IsPositivo = numero => numero > 0;

        Console.WriteLine($"O Número 7 é positivo? {IsPositivo(7)}");
    }
}
```

Saída:

```
O Número 7 é positivo? True
```

### Comparação

|Método Anônimo |Expressão Lambda |
|---|---|
| Func<int, bool> IsPositivo = delegate(int numero) { return numero > 0 }; |Func<int, bool> IsPositivo = numero => numero > 0;   |

##### Exemplo mais complexo:

```cs
namespace DelegateFunc;

public class Program
{
    static void Main(string[] args)
    {
	    // utilizando expressão condicional ternária
        Func<Aluno, string> verificaNome = aluno => 
        aluno.Nome.StartsWith('R') ? aluno.Nome : "Nome do aluno não começa com R";

        Console.WriteLine(verificaNome(new Aluno() { Nome = "Rodrigo", Idade = 18}));
        Console.WriteLine(verificaNome(new Aluno() { Nome = "Mateus", Idade = 24}));
        Console.WriteLine(verificaNome(new Aluno() { Nome = "Roberta", Idade = 33}));
    }

}
public class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}
```

[Expressão Condicional Ternária](condicional_ternaria.md)

==Assim o delegate **Func** pode ser usado sempre que **devemos ter um valor de retorno.**==

Saída:
```
Rodrigo
Nome do aluno não começa com R
Roberta
```

## Delegate Action

O Delegate Action encapsula um método que pode possuir até 16 parâmetros e que **não** retorna nenhum valor. Sua assinatura possui 17 sobrecargas:

- Action, Action< T >, Action<T1, T2>,..., Action<T1,....T16>.

Este delegate é usado em conjunto com [*Arrays* e *Listas*](estruturas_de_dados.md) , pois ele evita que você tenha que criar um método exclusivo para iterar a respectiva coleção. As classes *Array* e *List* possuem vários métodos que recebem como parâmetros delegates do tipo **Action**, como veremos a seguir. Então, se precisa de um delegate que não devolve nenhum valor, pode usar o **Action**.

### Sintaxe:
```cs
public delegate void Action<in T>(T obj) // além de mais 16 sobrecargas..
```

#### Parâmetros

- **obj** - O parâmetro de método que encapsula este delegado.

#### Parâmetros de tipo

- **in T** - Onde T é o tipo do parâmetro do método que encapsula este delegado. Este parâmetro de tipo é **contravariante**, ou seja, você pode usar o tipo especificado ou qualquer tipo que seja menos derivado.

##### Exemplos:

```cs
namespace DelegateAction;

public class Program
{
    static void Dividir(double n1, double n2)
    {
        double resultado = n1 / n2;
        Console.WriteLine("Divisão: " + resultado);
    }

    static void Main(string[] args)
    {
        Action<double, double> dividir = Dividir;

        dividir(200, 10);
    }
}
```

Saída:
```
Divisão: 20
```

É muito comum utilizarmos o delegate **Action** quando precisamos realizar uma ação sobre itens de uma lista:

```cs
namespace DelegateAction;

public class Program
{
    static void Main(string[] args)
    {
        List<string> frutas = new List<string>()
        {
            "Pêssego", "Banana", "Maça", "Kiwi", "Abacaxi"
        };

		// No caso o método Action que estamos utilizando é o Console.WriteLine
		frutas.ForEach(Console.WriteLine);

		// Agora usamos uma lambda para um resultado mais interessante
        frutas.ForEach(x => Console.WriteLine("Torta de " + x));		
    }
}
```

Saída:
```
Pêssego
Banana
Maça
Kiwi
Abacaxi
Torta de Pêssego
Torta de Banana
Torta de Maça
Torta de Kiwi
Torta de Abacaxi
```

==Nota: O código acima funciona porque a lista e o méotodo Console.WriteLine são do tipo String, além de que o próprio método não retorna nada e respeita a assinatura do Delegate Action.==

## Delegate Predicate

O **Delegate Predicate** representa o método que define um conjunto de critérios e determina se o objeto especificado atende os critérios.

O delegate **Predicate< T >** que usa parâmetro(s), executa o código usando o(s) parâmetro(s) e ==**sempre retorna um valor booleano.==

Este delegado é usado por vários métodos das classes de **Array** e de **List< T >** para pesquisar os elementos na coleção. 

Alguns métodos que aceitam Delegate Predicate:
- `FindAll` - Retorna uma lista de objetos que satisfazem a condição

- `RemoveAll` - Remove os objetos que satisfazem a condição

- `Exists` - Retorna true caso exista na List um objeto que satisfaz a condição, caso contrário retorna false

- `FindLast` - Retorna o último objeto que satisfaz a condição 

Normalmente, o **delegate Predicate< T >** é representado por uma [expressão de lambda](lambda.md). Como as variáveis com escopo local estão disponíveis para a expressão de lambda, é fácil testar uma condição que não é conhecida precisamente em tempo de compilação.

### Sintaxe:
```cs
public delegate bool Predicate<in T> (T obj) // e outras 16 sobrecargas
```

#### Parâmetros

- **obj** - Tipo: T - O objeto a ser comparado com os critérios definidos dentro do método representado por esse deletegate.

#### Parâmetros de Tipo

- **in T** - O tipo do objeto a ser comparado. Este parâmetro de tipo é **contravariante**, ou seja, pode-se usra o tipo especificado ou qualquer tipo que seja menos derivado.

#### Valor de Retorno

Tipo: **System.Boolean**
- **true** se o obj atende aos critérios definidos dentro do método representado por esse delegado, caso o contrário, **false**.

### Usando o Delegate Predicate< T >

Como mencionado anteriormente, é muito comum utilizar o delegate predicate em coleções.

##### Exemplos:

```cs
namespace DelegatePredicate;

public class Program
{
    static void Main(string[] args)
    {
        // Coleção
        int[] array = {188, 2, 39, 24, 55, -1204};

        // Definindo o delegate predicate
        Predicate<int> predicate = EncontrarNumeros;

        // Usando o método FindAll que aceita um delegate predicate
        var numeros = Array.FindAll(array, predicate);

        foreach(var n in numeros)
            Console.Write(n + " ");
    }

    // Só aceita números maior que 0 e menores que 50
    private static bool EncontrarNumeros(int n)
    {
        return n <= 50 && n > 0;
    }
}
```

Saída:
```
2 39 24
```

Agora o mesmo exemplo, mas com uma expressão lambda para representar o Delegate Predicate:

```cs
namespace DelegatePredicate;

public class Program
{
    static void Main(string[] args)
    {
        // Coleção
        int[] array = {188, 2, 39, 24, 55, -1204};

        // Usando FindAll com uma Expressão Lambda
        var numeros = Array.FindAll(array, x => x <= 50 && x > 0);

        foreach(var n in numeros)
            Console.Write(n + " ");
    }
}
```

Saída:
```
2 39 24
```

==Note como o código ficou mais direto com a Expressão Lambda.==
