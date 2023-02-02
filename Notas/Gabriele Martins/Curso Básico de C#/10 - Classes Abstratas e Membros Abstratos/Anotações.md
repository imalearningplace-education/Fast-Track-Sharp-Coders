# Classes Abstratas e Membros Abstratos

Primeiramente criamos as seguintes classes (ancestral: Veiculo, descendente: Carro):

```cs
class Veiculo{
    public double Peso { get; set; }
    public Veiculo(double peso){
        this.Peso=peso;
        Console.WriteLine("Um novo objeto Veiculo foi construído.");
    }
    ~Veiculo(){
        Console.WriteLine("Um objeto Veiculo foi destruído.");
    }
}
class Carro : Veiculo{
    public Carro(double peso) : base(peso)
    {
        
    }
}
```

Em seguida, criamos duas instancias:

```cs
Veiculo v1=new Veiculo(1000);
Carro c1=new Carro(1200);
```

Não faz muito sentido em um programa mais complexo ter uma classe ancestral sendo instanciada. No caso em que a classe ancestral serve apenas como base para classes descendentes e não será instanciada, é interessante transformá-la em uma **Classe Abstrada**. Fazemos isso da seguinte maneira:

```cs
public abstract class Veiculo(){
    //código da classe
}
```

Todo membro de uma classe abstrata, que também seja abstrato, obrigatoriamente também deve ser implementado pela classe descendente. Exemplo:

```cs
public abstract class Veiculo{
    //...
    public abstract void Mover(double distancia);
}
```

Na classe Carro somos obrigados a implementar o método Mover da classe ancestral Veiculo:

```cs
public override void Mover(double distancia){
    
}
```

Uma outra função interessante das classes abstratas é que elas podem servir para indicar um parâmetro, por exemplo,  que você quer qualquer tipo de objeto descendente daquela classe. Então, não estaria instanciando a classe abstrata mas estaria dizendo que naquele parâmetro tem que entrar algum descendente da classe abstrata:

```cs
public abstract class Veiculo{
    public double Peso { get; set; }
    public Veiculo(double peso){
        this.Peso=peso;
        Console.WriteLine("Um novo objeto Veiculo foi construído.");
    }
    ~Veiculo(){
        Console.WriteLine("Um objeto Veiculo foi destruído.");
    }
    public abstract void Mover(double distancia);
}
public class Carro : Veiculo{
    public Carro(double peso) : base(peso)
    {
        Console.WriteLine("Um novo objeto Carro foi construído.");
    }
    public override void Mover(double distancia){
        Console.WriteLine("Um objeto Carro se moveu por {0} metros.",distancia);
    }
}
public class Aviao : Veiculo{
    public Aviao(double peso) : base(peso)
    {
        Console.WriteLine("Um novo objeto Aviao foi construído.");
    }
    public override void Mover(double distancia){
        Console.WriteLine("Um objeto Aviao se moveu por {0} metros.",distancia);
    }
}
```

Na class Program criamos outro método:

```cs
static void Main(string[] args)
{
    Carro c1=new Carro(1200);
    Aviao a1=new Aviao(3000);
    ViajarParaCalifornia(a1);
}
static void ViajarParaCalifornia(Veiculo v)
{
    v.Mover(10000);
}
```

Se quisermos impedir que as classes Aviao e Carro se tornem ancestrais de outras classes fazemos o seguinte:

```cs
public sealed class Carro : Veiculo{
    //...
}
public sealed class Aviao : Veiculo{
    //...
}
```

