# Construtor Padrão e Parametrizado
Um **Método Construtor** é o responsável por instanciar objetos de uma classe, ou seja, é ele que reserva espaço em memória física do computador para alocar o objeto de forma a armazenar os valores do objeto, que atributos e propriedades terá, referências que esse objeto tenha para outros objetos e outras coisas pertinentes à um objeto em si.

Então para criarmos um método construtor, temos que ter uma classe capaz de gerar objetos primeiro:
```cs
class Carro{
    public int Portas {get; set;}
    public double Preco {get; set;}
    public string Modelo {get; set;}
}
```
Essa classe, por padrão, usa o construtor base do C#. Todas as classes em C# herdam de uma classe ancestral chamada de Object que tem um construtor padrão que simplesmente reserva memória para o objeto. Esse construtor padrão não faz uso de parâmetros e também não é definido no escopo da classe. Para criarmos objetos da classe acima fazemos:
```cs
Carro c1 = new Carro();
c1.Modelo = "Fusca";
c1.Portas = 4;
c1.Preco = 29990;
```
Vamos agora criar um construtor personalizado que vai facilitar a criação de novos objetos da classe Carro. Esse construtor personalizado irá receber como parâmetro o modelo do carro.
```cs
public Carro(string modelo)
{
    this.Modelo = modelo;
}
```
Para fazermos que o construtor acima tenha o comportamento do construtor padrão mais o que adicionarmos como parâmetro, temos que fazer o seguinte:
```cs
public Carro(string modelo) : this()
{
    this.Modelo = modelo;
}
```