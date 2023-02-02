# Construtor Estático e Destrutor
O **Método Construtor** é responsável por instanciar objetos de uma classe, já o **Método Destrutor** é responsável por liberar a memória alocada para um objeto. Entretanto, na linguagem C#, não é o programador que vai determinar o ponto em que o objeto vai ser liberado da memória pois isso é feito de forma automática. Existe um mecanismo chamado de Coletor de Lixo (Garbage Collector) que faz esse trabalho. Entretanto, mesmo que tenhamos esse mecanismo, conseguimos interceptar esse momento para tomar alguma atitude. Para programarmos um método destrutor personalizado fazemos:
```cs
~Carro(){
    Console.WriteLine("Um objeto do tipo Carro foi destruído.");
}
```
Para chamar o coletor de lixo fazemos:
```cs
GC.Collect();
```
Não é muito comum utilizar o destrutor, realmente só se precisamos liberar algum recurso computacional que tenhamos alocado para o objeto.

Assim como para cada objeto criado temos uma mensagem, tanto na criação quanto na destruição, podemos fazer a mesma coisa em relação ao próprio programa principal. O programa principal é uma **classe estática**, ou seja, só possui uma instância no programa inteiro. Quando iniciamos uma aplicação console o C# vai instanciar a classe estática que possui o método Main chamando-o.

Vamos ver como funciona a invocação de construtor ancestral. Criamos uma classe Veiculo e fazemos Carro herdar essa classe da seguinte forma:
```cs
class Carro : Veiculo
{
    //código da classe Carro
}
```
Assim, a classe Carro terá tudo que a classe Veiculo tem mais o que foi declarado dentro de Carro. Podemos agora criar um construtor para Carro que recebe a propriedade PesoKg (da classe Veiculo) como parâmetro da seguinte forma:
```cs
public Carro(int pesoKg) : base(pesoKg) {
    Console.WriteLine("Um novo objeto do tipo Carro com peso {0} foi criado.",this.PesoKg);
}
```
Usando base com o parâmetro pesoKg fazemos a construção de um objeto Carro utilizando o método construtor de Veiculo.