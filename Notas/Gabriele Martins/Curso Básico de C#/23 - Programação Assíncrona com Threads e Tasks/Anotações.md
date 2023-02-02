# Programação Assíncrona com Threads e Tasks
<font color="blue">**Programação Assíncrona**</font> diz respeito ao fato de podermos executar vários trechos de código do programa de maneira simultânea. Poderíamos, por exemplo, criar vários métodos e demandar que eles fossem executados ao mesmo tempo e não de forma sequencial ou síncrona. Existem diversas maneiras de fazer isso usando C#, porém a mais comum e clássica é usando a classe Thread. Essa classe permite criarmos um trecho de execução que roda em paralelo com o programa principal e com outras threads que criarmos. Existe também a classe Task que também tem como propósito a execução de código assíncrono está num nível de abstração mais alto. Vamos fazer um exemplo de execução com threads:

```cs
class Program{
    static void Main(string[] args)
    {
        Stopwatch sw=new Stopwatch();
        sw.Start();
        RealizarOperacao(1,"Gabriele","Martins");
        RealizarOperacao(2,"Ellie","Williams");
        RealizarOperacao(3,"Joel","Miller");
        sw.Stop();
        Console.WriteLine("Operação gastou {0} milissegundos.",sw.ElapsedMilliseconds);
    }
    static void RealizarOperacao(int op, string nome, string sobrenome){
        Console.WriteLine("Iniciando operação {0}...",op);
        for(int i=0; i<1000000000; i++){
            var p = new Pessoa(nome, sobrenome, 35);
        }
        Console.WriteLine("Finalizando operação {0}...",op);
    }
}
internal class Pessoa{
    private string nome;
    private string sobrenome;
    private int v;
    public Pessoa(string nome, string sobrenome, int v){
        this.nome=nome;
        this.sobrenome=sobrenome;
        this.v=v;
    }
}
``` 
O código acima foi feito com o objetivo de criar uma execução pesada para o programa. Como pode-se observar, há 1 bilhão de iterações no método RealizarOperacao. É interessante executar programas pesados de forma paralela pois assim minimizam-se as chances de travamento. Sem threads, o programa acima demora 9258 milissegundos ou aproximadamente 10 segundos para ser executado. Se o método RealizarOperacao fosse chamado mais de uma vez no método principal, a execução demoraria mais ainda. Por exemplo, se fossem feitas 3 chamadas, o programa demoraria 29448 milissegundos ou aproximadamente meio minuto para ser executado. Entretanto, se as operações não forem interdependentes poderíamos executar todas elas em paralelo ou simultaneamente. Isso é possível por conta da arquitetura das CPU's atuais que possuem mais de um núcleo de processamento e mais de um thread. Para utilizar threads, no programa acima faríamos:
```cs
static void Main(string[] args)
{
    Stopwatch sw=new Stopwatch();
    sw.Start();
    ExecutarComThreads();
    sw.Stop();
    Console.WriteLine("Operação gastou {0} milissegundos.",sw.ElapsedMilliseconds);
}
static void ExecutarComThreads(){
    var t1=new Thread(()=>{
        RealizarOperacao(1,"Gabriele","Martins");
    });
    var t2=new Thread(()=>{
        RealizarOperacao(2,"Ellie","Williams");
    });
    var t3=new Thread(()=>{
        RealizarOperacao(3,"Joel","Miller");
    });
    t1.Start();
    t2.Start();
    t3.Start();
    t1.Join();
    t2.Join();
    t3.Join();
}
```
O programa acima, para realizar 3 operações, ao invés de demorar 29448 milissegundos para ser executado, demorou apenas 19703 milissegundos. Threads é o recurso primário para a execução de código assíncrono. Entretanto, há um recurso mais moderno em C# que são as Tasks. Uma thread é uma linha de execução que quando criada, cria uma nova linha de execução e pega o trecho de código e coloca para executar dentro dessa nova linha, ou seja, prepara um núcleo de processamento, pega o código e executa nesse núcleo. Se chamarmos uma nova thread vai ocorrer novamente a operação de preparação do núcleo. Usando tasks foi possível realizar um processo mais otimizado. Quando uma thread termina de executar, digamos que o slot de processamento dela fica liberado para um novo código ser executado sem ser necessário a criação de um novo objeto thread. A criação de um objeto thread é computacionalmente dispendiosa e também ocupa memória. As tasks trabalham de forma otimizada e utilizam uma coisa chamada de thread pool que é uma fila de threads ja criadas que pode ser consultada a disponibilidade e usada sua demanda. Então, o que a task faz é ficar verificando se há uma thread livre para ser usada, e se tiver, ela coloca o código para executar naquela thread sem ser necessária a criação de uma nova thread. Vamos fazer um exemplo com a utilização de tasks:
```cs
static void Main(string[] args)
{
    Stopwatch sw=new Stopwatch();
    sw.Start();
    ExecutarComTasks();
    sw.Stop();
    Console.WriteLine("Operação gastou {0} milissegundos.",sw.ElapsedMilliseconds);
}
static void ExecutarComTasks(){
    var t1=Task<int>.Run(()=>{
        RealizarOperacao(1,"Gabriele","Martins");
        return 1;
    });
    var t2=Task<int>.Run(()=>{
        RealizarOperacao(2,"Ellie","Williams");
        return 2;
    });
    var t3=Task<int>.Run(()=>{
        RealizarOperacao(3,"Joel","Miller");
        return 3;
    });
    Console.WriteLine("Tarefa {0} finalizou.",t1.Result);
    Console.WriteLine("Tarefa {0} finalizou.",t2.Result);
    Console.WriteLine("Tarefa {0} finalizou.",t3.Result);
}
```