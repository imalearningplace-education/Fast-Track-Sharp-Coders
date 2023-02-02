# Variáveis

As variáveis são espaços na memória do computador onde podemos salvar, manipular e exibir informações. Vamos analisar novamente o código da imagem anterior.

```cs
namespace SistemaBancario 
{
    public class InstanciaObjeto
    {
        public static void Main()
        { 
           var objetoGerente = new Gerente();
        }
    }
}
```

A palavra reservada var tem a função de informar o sistema que ali está ocorrendo a criação de uma variável. Nesse exemplo, estamos criando um novo objeto e atribuindo seu valor e estado na 
variável objetoGerente. É possível também criar a variável com o tipo dela implicitamente ao invés de usar a palavra ***var***.

As variáveis têm uma importância enorme no mundo de desenvolvimento de software pois são nelas que guardamos, manipulamos, alteramos e exibimos valores para os usuários finais ou simplesmente fazemos cálculos e manipulações e enviamos talvez para outros sistemas que queiram se comunicar.

De forma objetiva, a variável é meramente um nome dado para um armazenamento de dados que nosso programa vai manipular. Cada variável no C# possui um tipo específico que determina seu 
tamanho e o quanto de informação ela pode salvar na memória.

Os tipos básicos são:

|nome|ideia|exemplo|
|:-:|:-:|:-:|
|inteiro|guarda inteiros|*int* idade|
|double|guarda números reais|*double* altura|
|string|guarda textos|*string* nome|
|character|guarda 1 caracter| *char* sexo|
|float|guarda números reais|*float* nota|
|long|guarda inteiros|*int64* cpf|
|boolean|true ou false|*bool* casado = false|

*Obs*: enquanto o *int* normal seria o *int32*, o long seria outro jeito de falar *int64*. Da mesma maneira,
o *float* é, na verdade, *float32*, enquanto o double é *float64*. 32 e 64 se referem ao tamanho dos bytes.

*Obs2*: char só aceita aspas simples.


## Definindo uma variável

Para definirmos variáveis no C#:
```
(tipo de dados) (nome da variavel) = (valor);
```

Exemplos:
```cs
namespace SistemaBancario
{
    public class Variaveis
    {
        public satic void Main()
        {
            int cpf = 123456789;
            string nome = "João da Silva";
            decimal salario = 1000;
            bool funcionarioAtivo = true;
        }
    }
}
```

Visualizando o nome das variáveis podemos perceber que cada uma delas tem uma finalidade, um tipo e um valor inicial. Assim que essas variáveis ficam disponíveis na memória é possível acessá-las, exibi-las ou manipulá-las.

Exemplo com vários tipos:
```cs
string nome = "João da Silva";
double altura = 1.73;
int idade = 20;
char sexo = 'M';
long cpf = 123456789;
float nota = 7.8f;

Console.WriteLine($"Nome do usuário:{nome}");
Console.WriteLine($"Idade:{idade} | Altura:{altura} | Cpf:{cpf} | Sexo:{sexo}");
Console.WriteLine($"Nota:{nota}"); 
```

Saída:

```
Nome do usuário:João da Silva
Idade:20 | Altura:1,73 | Cpf:123456789 | Sexo:M
Nota:7,8
```
## Conversão de dados
No C# temos dois tipos de dados que são sempre armazenados na memória, sendo tipos de valor e referência. Quando atribuímos um valor a uma variável dos tipos int, float, double, decimal, bool e char são do tipo VALOR. Isto porque o conteúdo vai diretamente para um local na memória.

Já o tipo por REFERÊNCIA, armazena o endereço do valor onde está armazenado, por exemplo, object, string e array. Em qualquer tipo de aplicação é comum a conversão de tipos de 
dados, int para double, texto para data, object para float e vice-versa.  A estas conversões chamamos de Boxing e Unboxing.

Boxing é a conversão de um tipo de valor para o tipo de objeto ou qualquer tipo de interface implementado por este tipo de valor. O boxing está implícito.

### Boxing
```cs
static void Main()
{
    //boxing (converte um tipo para object)
    System.Console.WriteLine("----- Boxing -----");
    int percentual = 10;
    object objPercentual = percentual;
    System.Console.WriteLine($"percentual: {percentual} - {percentual.GetType()}");
    System.Console.WriteLine($"obkPercentual: {objPercentual} - {objPercentual.GetType()}");
}
```
Saída:
```
----- Boxing -----
percentual: 10 - System.Int32
obkPercentual: 10 - System.Int32
```
### Unboxing

Agora vamos criar um código para mostrar o unboxing, que é o 
oposto do boxing. Neste caso, vamos definir a variável objDesconto
do tipo object que é atribuída à variável desconto do tipo int. Note 
na sintaxe que é obrigatório colocar entre parênteses do tipo da 
variável que receberá o object. Neste caso, usamos (int)objDesconto. 
Ao final, mostraremos o conteúdo e o tipo de dado.

```cs
static void Main()
{
    System.Console.WriteLine("----- Unboxing -----");
    object objDesconto = 10;
    int desconto = (int)objDesconto;
    System.Console.WriteLine($"desconto: {desconto} - {desconto.GetType()}");
    System.Console.WriteLine($"objDesconto: {objDesconto} - {objDesconto.GetType()}");
}
```
Saída:
```
----- Unboxing -----
desconto: 10 - System.Int32
objDesconto: 10 - System.Int32
```


### Parse()
O *Parse()* é utilizado para converter tipos de dados. Utilizamos no exemplo acima pois todo input de usuário (ReadLine()) é, na verdade, uma string.


### Convert.To()
```cs
string[] cesta = {"5 maças", "3 peras", "4 ameixas", "2 uvas", "3 bananas", "2 abacaxis"};
    
    foreach(string fruta in cesta)
        {
        QtdeFrutas += Convert.ToInt32(fruta.Substring(0, fruta.IndexOf(' ')));
        }
    System.Console.WriteLine($"Quantidade de frutas: {QtdeFrutas}");
```
Saída:
```
Quantidade de frutas: 19
```
