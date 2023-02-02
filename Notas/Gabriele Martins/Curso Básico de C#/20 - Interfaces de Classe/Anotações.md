# Interface de Classe
Uma <font color="blue">**Interface**</font> é uma representação puramente abstrata que está relaciodada à um grupo de funcionalidades que sejam comuns à um conjunto de classes diferentes. Essas classes podem implementar a interface. A interface pode ser entendida como uma classe completamente abstrada que pode servir como ancestral para outras classes. Porém, tem algumas peculiaridades que fazem dessa uma estrutura interessante. A implementação que a classe faz de uma interface é como uma assinatura de um contrado, ou seja, tudo que é declarado na interface deve obrigatoriamente ser implementado pela classe. A interface não pode conter implementações pois é puramente abstrada, contem apenas declarações. Uma interface em C# é criada como se fosse uma classe, porém a palavra reservada que utilizamos é interface. Os membros da interface só possuem suas respectivas assinaturas, não possuindo implementação. A letra I no início do nome de uma interface é uma convenção para representar interfaces. Vamos ver um exemplo:
```cs
interface IAnimal{
    void Comer();
    void Dormir();
    void EmitirSom();
}
```
Na interface acima temos a declaração de 3 métodos sem implementação. Se uma classe implementar a interface IAnimal, obrigatoriamente deve implementar os métodos declarados. Não há modificadores de acesso (public, private, protected, internal) nos membros da interface. A visibilidade dos membros que serão implementados é definida pela classe que implementa a interface. Vamos fazer uma classe que implementa a interface acima:
```cs
class Cachoro : IAnimal{
    public void Comer(){
        Console.WriteLine("O cachorro está comendo ração");
    }
    public void Dormir(){
        Console.WriteLine("O cachorro está dormindo no chão");
    }
    public void EmitirSom(){
        Console.WriteLine("Au au au");
    }
    public void Farejar(){
        Console.WriteLine("O cachorro está farejando.");
    }
}
``` 
Porém, Farejar não é um método de IAnimal. Se no programa fizermos:
```cs
IAnimal oswaldo = new Cachoro();
oswaldo.Farejar();
```
O seguinte erro será obtido: <font color="red">'EstudandoInterfaces.IAnimal' não contém uma definição para 'Farejar' e nenhum método de extensão 'Farejar' aceita que um primeiro argumento de tipo 'EstudandoInterfaces.IAnimal' seja encontrado.</font>

Pelo fato de sabermos que oswaldo contém um objeto do tipo Cachorro podemos acessar os membros específicos da classe Cachorro se fizermos uma <font color="blue">conversão de tipos</font> da seguinte forma:
```cs
(oswaldo as Cachoro).Farejar();
```
Porém se declararmos uma outra variável do tipo Cachorro que recebe um objeto do tipo Cachorro é então possível acessar ao método Farejar.
```cs
Cachoro bilu = new Cachoro();
bilu.EmitirSom();
bilu.Farejar();
```
Neste exemplo, oswaldo foi declarado como IAnimal, portanto só é capaz de acessar diretamente as funcionalidades declaradas pela interface IAnimal. Contudo, conseguimos converter o objeto que está em oswaldo para o tipo Cachorro e utilizar os membros específicos da classe Cachorro. Nesse caso fizemos uma converção sem chegagem prévia, ou seja, estamos confiando que sabemos que há o método Farejar e que a conversão será bem sucedida. Entretanto, em outras situações é necessário fazer uma <font color="blue">checagem de tipo</font> antes de fazer a conversão do objeto:
```cs
if(oswaldo is Cachoro)
{
    (oswaldo as Cachoro).Farejar();
}
```
A linguagem C# não suporta herança múltipla de classes como outras linguagens (C++,Python). Entretanto suporta implementação de <font color="blue">múltiplas interfaces</font>. Para isso basta separarmos as interfaces ancestrais (implementadas) por vírgula:
```cs
interface IQuadrupede{
    void Andar();
    void Correr();
}
class Cachoro : IAnimal, IQuadrupede{
    //...
    public void Andar(){
        Console.WriteLine("O cachorro está andando com as quatro patas.");
    }
    public void Correr(){
        Console.WriteLine("O cachorro está correndo com as quatro patas.");
    }
}
```
Podemos agora fazer no programa:
```cs
IAnimal bolinha = new Cachoro();
if(bolinha is IQuadrupede){
    (bolinha as IQuadrupede).Andar();
}
if(bolinha is Cachoro){
    (bolinha as Cachoro).Farejar();
}
```
Vamos agora criar uma nova classe Macaco que implementa IAnimal, porém não implementa IQuadrupede. Além disso vamos criar uma nova interface IBipede:
```cs
interface IBipede{
    void Caminhar();
}
class Macaco : IAnimal, IBipede{
    public void Comer(){
        Console.WriteLine("O macaco está comendo banana.");
    }
    public void Dormir(){
        Console.WriteLine("O macaco está dormindo na árvore.");
    }
    public void EmitirSom(){
        Console.WriteLine("Uh uh ah ah ah!");
    }
    public void Caminhar(){
        Console.WriteLine("O macaco está caminhando com os dois pés.");
    }
}
```
Agora, no programa, podemos fazer:
```cs
Random random = new Random();
List<IAnimal> animais = new List<IAnimal>();
for(int i=0; i<100; i++){
    int sorteio = random.Next();
    if(sorteio%2==0){
        animais.Add(new Cachoro());
    }
    else{
        animais.Add(new Macaco());
    }
}
foreach(var animal in animais){
    Console.WriteLine("---------------------------------");
    if(animal is IQuadrupede)
        Console.WriteLine("Este animal é um quadrúpede.");
    if(animal is IBipede)
        Console.WriteLine("Este animal é um bípede.");
    if(animal is Cachoro){
        Console.WriteLine("Este animal é um cachorro.");
        (animal as Cachoro).Farejar();
    }
    if(animal is Macaco){
        Console.WriteLine("Este animal é um macaco.");
        (animal as Macaco).Caminhar();
    }
}
```
Supondo que as duas interfaces, IAnimal e IQuadrupede tenham a declaração de um método com o mesmo nome: Andar(). A classe Cachorro implementa tanto IAnimal quanto IQuadrupede, porém só declara o método Andar uma vez. Isso é capaz de satisfazer as necessidades de implementação para as duas interfaces. Porém, se quisermos diferenciar as implementações do método Andar de acordo com cada inteface (<font color="blue">implementação explícita de interface</font>) precisamos fazer o seguinte:
```cs
//...
void IAnimal.Andar(){
    //...
}
void IQuadrupede.Andar(){
    //...
}
//...
```