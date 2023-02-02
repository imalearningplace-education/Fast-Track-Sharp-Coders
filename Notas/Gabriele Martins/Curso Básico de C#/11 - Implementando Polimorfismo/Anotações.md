# Implementando Polimorfismo

A diferença de um método virtual para um método abstrato, é que o método virtual, além de poder ser sobrescrito em classes descendentes também pode conter uma implementação na classe ancestral. Já os métodos abstratos não podem conter implementação na classe ancestral. Declaramos uma classe ancestral Veiculo com o método virtual Frear da seguinte forma:

```cs
public abstract class Veiculo{
    //...
    public virtual void Frear(){
        Console.WriteLine("Acionando os freios...Parou!");
    }
    //...
}
```

A classe descentende Carro ficou da seguinte maneira:

```cs
public class Carro : Veiculo{
    //...
    public override void Frear()
    {
        Console.WriteLine("Acionando os freios ABS...Parou!");
    }
    //...
}
```

Aqui, estamos sobrescrevendo (override) o método Frear que foi implementado na classe ancestral com uma impressão diferente no console. Já a classe descendente Onibus ficou da seguinte maneira:

```cs
public class Onibus : Veiculo{
    //...
    public new void Frear(){
        Console.WriteLine("Acionando os freios a ar...Parou!");
    }
    //...
}
```

Ao utilizar o **new** no lugar de **override** no método Frear da classe Onibus, a impressão no console não será diferente do que foi especificado no método Frear da classe ancestral, pois não estamos sobrescrevendo nesse caso.  Para obtermos comportamento polimorfico precisamos utilizar o override. Se a intenção é simplesmente ocultar o método do ancestral com uma nova implementação utilizamos new, porém nao é possível implementar polimorfismo nesse caso.
