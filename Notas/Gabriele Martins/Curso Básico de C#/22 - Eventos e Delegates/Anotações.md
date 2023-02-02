# Eventos e Delegates
Eventos e Delegates auxiliam a escrita de programas que possuem reações baseadas em ações. Em termos de programas, esse mecanismo permite executar algo quando algum evento ocorrer nesse programa. O tipo <font color="blue">**Delegate**</font> permite criar uma variável ou parâmetro de método que recebe um método como valor. Geralmente declaramos tipos de dados primitivos como inteiros, strings, entre outros. Mas quando criamos um tipo delegate podemos criar uma variável que recebe um método. Tecnicamente, o delegate é um ponteiro para uma função. Quando criamos um delegate definimos a assinatura dele e seu tipo de retorno. Um exemplo de declaração de delegate segue abaixo:
```cs
public delegate double OperacaoMatematicaBinaria(double x, double y);
```
Vamos agora declarar algumas funções compatíveis com o delegate acima:
```cs
public static double Somar(double x, double y){
    double r = x + y;
    Console.WriteLine("A soma de {0} e {1} é igual a {2}.",x,y,r);
    return r;
}
public static double Multiplicar(double x, double y){
    double r = x * y;
    Console.WriteLine("A multiplicação de {0} e {1} é igual a {2}.",x,y,r);
    return r;
}
public static double Potenciar(double x, double y){
    double r = Math.Pow(x,y);
    Console.WriteLine("A potência de {0} e {1} é igual a {2}.",x,y,r);
    return r;
}
```
Agora vamos criar uma variável do tipo desse delegate e atribuir uma das funções a essa variável. Em seguida vamos executar a função através da variável.
```cs
OperacaoMatematicaBinaria op = new OperacaoMatematicaBinaria(Multiplicar);
op(20,10);
```
É possível ainda criar um vetor de delegates e adicionar vários métodos a ele.
```cs
List<OperacaoMatematicaBinaria> operacoes = new List<OperacaoMatematicaBinaria>();
operacoes.Add(new OperacaoMatematicaBinaria(Somar));
operacoes.Add(new OperacaoMatematicaBinaria(Multiplicar));
operacoes.Add(new OperacaoMatematicaBinaria(Potenciar));
foreach(var item in operacoes){
    item(10,2);
    item(20,3);
    item(30,4);
    Console.WriteLine();
}
```
Há também a possibilidade de colocarmos dentro de uma lista do tipo delegate em questão um método anônimo. Um método anônimo é um método que não tem nome e que não foi préviamente declarado, ou seja, é um método que criamos na medida que precisamos dele. Fazemos isso da seguinte maneira:
```cs
operacoes.Add(delegate(double a, double b){
    double r = a / b;
    Console.WriteLine("A divisão de {0} e {1} é igual a {2}.",a,b,r);
    return r;
});
```
Os delegates tem uma natureza multicast, ou seja, um único delegate pode apontar para vários métodos.
```cs
OperacaoMatematicaBinaria opMulticast = Somar;
opMulticast += Multiplicar;
opMulticast += Potenciar;
opMulticast += delegate(double a, double b){
    double r = a / b;
    Console.WriteLine("A divisão de {0} e {1} é igual a {2}.",a,b,r);
    return r;
};
opMulticast(2,3);
```
Suponha agora que queremos ser notificados cada vez que os métodos compatíveis com o tipo delegate em questão forem executados. Podemos fazer isso de várias maneiras e uma delas é notificar dentro de cada método o uso do mesmo, por exemplo enviando o resultado por email, gravando em algum arquivo, entre outras possibilidades. Outra forma de fazer isso é através de <font color="blue">**Eventos**</font>. Assim como o delegate, um evento é um tipo de variável que suporta a inclusão de vários método que possuem uma assinatura compatível. O propósito de um evento é permitir que determinadas ações do programa sejam interceptadas e algo seja realizado mediante a ocorrência dessa ação. Para declarar eventos fazemos:
```cs
public delegate double OperacaoMatematicaBinaria(double x, double y);
public static event OcorrenciaDeOperacao AoOcorrerOperacao;
```
Em seguida, comentamos todos os Console.WriteLine dos métodos anteriormente criados e inserimos a seguinte linha:
```cs
AoOcorrerOperacao.Invoke(r);
```
Vamos agora criar os seguintes método compatíveis com a assinatura do AoOcorrerOperacao().
```cs
public static void MostrarResultadoNaTela(double r){
    Console.WriteLine("Resultado: {0}",r);
}
public static void EnviarResultadoPorEmail(double r){
    Console.WriteLine("Enviando e-mail com resultado {0}.",r);
}
public static void GravarResultadoEmArquivo(double r){
    Console.WriteLine("Gravando arquivo com resultado {0}.",r);
}
```