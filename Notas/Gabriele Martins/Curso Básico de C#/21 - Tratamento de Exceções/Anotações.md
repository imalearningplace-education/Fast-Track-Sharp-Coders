# Tratamento de Exceções
<font color="blue">**Exceções**</font> são execuções e resultados de execuções inesperados que acontecem ao longo de um programa. Esse resultado inesperado geralmente é fruto ou de um erro de programação, de algo não previsto, ou realmente um erro de codificação que algumas vezes por falha do programador pode ocorrer. Existem centenas de tipos de exceções que podem acontecer ao longo de um programa. Vamos ver algumas delas. Vamos simular uma exceção de divisão de algum número por zero:

## DivideByZeroException
```cs
static void Main(string[] args)
{
    DividirNumeroPor(0);
    Console.WriteLine("Executou depois da exceção.");
}
//DivideByZeroException
static void DividirNumeroPor(int divisor){
    try{
        Console.WriteLine(10/divisor);
    }
    catch(DivideByZeroException){
        Console.WriteLine("Não é possível dividir por zero");
    }
}
```
Sem tratamento de exceção, o programa acima terminaria gerando Unhandled Exception e o print na tela do console com a mensagem não seria executado. O tratamento é feito com try e catch.
## IndexOutOfRangeException
```cs
static void Main(string[] args)
{
    AcessarVetor(9);
    Console.WriteLine("Executou depois da exceção.");
}
//IndexOutOfRangeException
static void AcessarVetor(int indiceElemento){
    string[] palavras = {"Estamos","aprendendo","a","tratar","exceções"};
    try{
        Console.WriteLine(palavras[indiceElemento]);
    }
    catch (IndexOutOfRangeException){
        Console.WriteLine("Não há palavra no índice informado.");
    }
}
```
Sem tratamento de exceção, o programa acima terminaria gerando Unhandled Exception e o print na tela do console com a mensagem não seria executado. O tratamento é feito com try e catch.
## NullReferenceException
```cs
static void Main(string[] args)
{
    ConverterObjetoParaString(null);
    Console.WriteLine("Executou depois da exceção.");
}
//NullReferenceException
static void ConverterObjetoParaString(Object obj){
    try{
        Console.WriteLine(obj.ToString());
    }
    catch (NullReferenceException e){
        Console.WriteLine(e.Message);
    }
}
```
Temos agora o try, que tenta fazer a conversão do objeto para string. Entretanto, o catch irá mostrar a mensagem padrão desse tipo de exceção.
## InvalidCastException
```cs
static void Main(string[] args)
{
    ConverterObjetoParaInteiro("abc");
    Console.WriteLine("Executou depois da exceção.");
}
//InvalidCastException
static void ConverterObjetoParaInteiro(Object obj){
    try{
        Console.WriteLine(Convert.ToInt32(obj));
    }
    catch (InvalidCastException e){
        Console.WriteLine("Ocorreu um erro: {0}.",e.Message);
    }
}
```
Nesse caso, recebemos Unhandled Exception pois o tipo de exceção que estavamos prevendo receber nao ocorreu. A exceção recebida foi FormatException. Se trocarmos Convert.ToInt32 a exceção especificata será tratada conforme o previsto. Se quisessemos manter Convert.ToInt32, teriamos que tratar o tipo FormatException.
## ArgumentNullException
```cs
static void Main(string[] args)
{
    ObterPosicaoDePalavraEmTexto(null);
    Console.WriteLine("Executou depois da exceção.");
}
//ArgumentNullException
static void ObterPosicaoDePalavraEmTexto(string palavra){
    string texto = "Estamos aprendendo a tratar exceções em C#.";
    try{
        Console.WriteLine(texto.IndexOf(palavra));
    }
    catch (ArgumentNullException e){
        Console.WriteLine("Ocorreu um erro: {0}\nCódigo do erro: {1}",e.Message,e.HResult);
    }
}
```
No tratamento da exceção acima estamos acessando o código do erro através da propriedade HResult.
## IOException e Derivadas
```cs
static void Main(string[] args)
{
    ObterArquivoParaEscrita("C:Teste.txt");
    Console.WriteLine("Executou depois da exceção.");
}
static StreamWriter ObterArquivoParaEscrita(string caminho){
    if(caminho is null){
        Console.WriteLine("Você não informou o caminho para o arquivo.");
        return null;
    }
    try{
        var fs = new FileStream(caminho, FileMode.CreateNew);
        return new StreamWriter(fs);
    }
    catch (FileNotFoundException){
        Console.WriteLine("O arquivo não pôde ser encontrado.");
    }
    catch (DirectoryNotFoundException){
        Console.WriteLine("O diretório não pôde ser encontrado.");
    }
    catch (DriveNotFoundException){
        Console.WriteLine("O disco não pôde ser encontrado.");
    }
    catch (PathTooLongException){
        Console.WriteLine("O caminho do arquivo excede o tamanho máximo suportado.");
    }
    catch (UnauthorizedAccessException){
        Console.WriteLine("Você não tem permissão para acessar o arquivo.");
    }
    catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32){
        Console.WriteLine("Há uma violação de compartilhamento de arquivo.");
    }
    catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80){
        Console.WriteLine("O arquivo já existe.");
    }
    catch (IOException e){
        Console.WriteLine("Uma exceção ocorreu:\nCódigo do erro: {0}\nMensagem: {1}",e.HResult & 0x0000FFFF, e.Message);
    }
    return null;
}
```
No caso acima temos uma estrutura muito robusta para tratamento de exceções em um método para obter um arquivo para escrita.
## Criação de Exceção
Vamos ver agora como criar uma exceção personalizada para ser lançada.
```cs
class Program{
    static void Main(string[] args)
    {
        Triangulo t1 = new Triangulo(30, 12, 12);
        Console.WriteLine("Executou depois da exceção.");
    }
}
class InvalidTriangleSideException : Exception{
    const string mensagemErro = "Um dos lados do triângulo excede o tamanho máximo permitido.";
    public char WrongSide { get; }
    public InvalidTriangleSideException(char wrongSide) : base(mensagemErro){
        this.HelpLink = @"http://www.stoodi.com.br/blog/matematica/triangulo/";
        this.WrongSide = wrongSide;
    }
}
class Triangulo{
    public double LadoA { get; set; }
    public double LadoB { get; set; }
    public double LadoC { get; set; }
    public Triangulo(double ladoA, double ladoB, double ladoC){
        if(ladoA > ladoB + ladoC){
            throw new InvalidTriangleSideException('A');
        }
        if(ladoB > ladoA + ladoC){
            throw new InvalidTriangleSideException('B');
        }
        if(ladoC > ladoA + ladoB){
            throw new InvalidTriangleSideException('C');
        }
        this.LadoA = ladoA;
        this.LadoB = ladoB;
        this.LadoC = ladoC;
    }
    public double ObterArea(){
        double semiPerimetro = (this.LadoA + this.LadoB + this.LadoC);
        double area = Math.Sqrt(semiPerimetro *
        (semiPerimetro - this.LadoA) *
        (semiPerimetro - this.LadoB) *
        (semiPerimetro - this.LadoC));
        return area;
    }
}
```
Acima temos a criação de uma nova exceção, uma criação de classe que lança a exceção e o instanciamento da mesma.