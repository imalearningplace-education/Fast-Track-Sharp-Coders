# Herança de Classes

A herança de classes permite o reaproveitamento de código, herdando características e comportamentos de uma classe ancestral. Toda herança é aditiva, ou seja, o que a classe ancestral possui não pode ser removido, é sempre adicionado ao descendente. Vamos criar a seguinte classe ancestral:

```cs
class Veiculo
{
    public double Peso { get; set; }
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Comprimento { get; set; }
    protected double Densidade{
        get{
            return this.Peso/(this.Altura*this.Largura*this.Comprimento);
        }
    }
    public Veiculo(double peso, double altura, double largura, double comprimento){
        this.Peso=peso;
        this.Altura=altura;
        this.Largura=largura;
        this.Comprimento=comprimento;
        Console.WriteLine("Um objeto do tipo Veiculo foi criado.");
    }
    ~Veiculo(){
        Console.WriteLine("Um objeto do tipo Veiculo foi destruído.");
    }
}
```

Em seguida vamos criar as seguintes classes descendentes:

```cs
class Aviao : Veiculo
{
    public int Passageiros { get; set; }
    public double Altitude { get; set; } 
    public Aviao(double peso, double altura, double largura, double comprimento, int passageiros) : base(peso,altura,largura,comprimento)
    {
        this.Passageiros=passageiros;
        this.Altitude=0;
        Console.WriteLine("Um objeto do tipo Aviao foi criado.");
    }
    ~Aviao(){
        Console.WriteLine("Um objeto do tipo Aviao foi destruido.");
    }
    public void Voar(double distancia){
        this.Decolar(1000);
        double percorrida=0;
        while(percorrida<distancia){
            Console.WriteLine("O avião está a {0:F2} metros de distância do destino.",distancia-percorrida);
            percorrida+=220;
            Thread.Sleep(1000);
        }
        this.Pousar();
    }
    private void Decolar(int altitude){
        while(this.Altitude<altitude){
            Console.WriteLine("O avião está a {0:F2} metros de altitude.",this.Altitude);
            this.Altitude+=60;
            Thread.Sleep(1000);
        }
        Console.WriteLine("Decolagem concluída.");
        Thread.Sleep(1000);
    }
    private void Pousar(){
        while(this.Altitude>0){
            Console.WriteLine("O avião está a {0:F2} metros de altitude.",this.Altitude);
            this.Altitude-=60;
            this.Altitude=this.Altitude<0?0:this.Altitude;
            Thread.Sleep(1000);
        }
        Console.WriteLine("Pouso concluída.");
        Thread.Sleep(1000);
    }
}
```

Vimos que declarações privadas só podem ser acessadas dentro da mesma classe, enquando declarações públicas podem ser acessadas de quaisquer outras classes. Quando a declaração é protegida (protected), como a propriedade Densidade na classe ancestral Veiculo, só poderá ser acessada dentro de classes descendentes. Podemos declarar as variáveis da seguinte forma:

```cs
Veiculo a1=new Aviao(3200,4,16,12,12);
```

Porém quando tentarmos acessar o método Voar( ), não será possível pois só está declarado na classe descendente Aviao, e não na classe ancestral Veiculo, e a variável a1 foi declarada como Veiculo.&#x20;
