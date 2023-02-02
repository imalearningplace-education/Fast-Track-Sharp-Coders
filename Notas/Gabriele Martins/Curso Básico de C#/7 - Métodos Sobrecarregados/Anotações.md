# Métodos Sobrecarregados

Vamos primeiramente criar uma classe Veiculo com algumas propriedades e métodos (que terão versões sobrecarregadas) e adicionando um tipo chamado CorVeiculo da seguinte forma:

```cs
enum CorVeiculo{
    Branco,
    Preto,
    Vermelho,
    Prata,
    Grafite
}
class Veiculo{
    public string Modelo { get; set; }
    public int Peso { get; set; }
    public double Velocidade { get; set; }
    public int Portas { get; set; }
    public CorVeiculo Cor { get; set; }
    public Veiculo(string modelo)
    {
        this.Modelo=modelo;
    }
    public Veiculo(string modelo, CorVeiculo cor) : this(modelo)
    {
        this.Cor=cor;
    }
    public Veiculo(string modelo, CorVeiculo cor, int portas = 4) : this(modelo,cor)
    {
        this.Portas=portas;
    }
}
```

Temos acima três versões sobrecarregadas de construtores. A sobrecarga se dá pela quantidade e tipo do parâmetros que estão sendo passados. Nesse caso, temos um método que tem um parâmetro do tipo string, outro que tem dois parâmetros, um do tipo string e outro do tipo CorVeiculo, e um último método que tem três parâmetros, um do tipo string, outro do tipo CorVeiculo e outro do tipo int. No programa principal, poderíamos fazer o seguinte:

```cs
Veiculo v1 = new Veiculo("Fusca",CorVeiculo.Branco,2);
```

Vamos agora criar outro método:

```cs
public void MostrarDados(){
    Console.WriteLine("{0} :: {1} :: {2}",this.Modelo,this.Cor,this.Portas);
}
```

Quando chamamos o método MostrarDados( ) é impressa no console uma linha como acima.
