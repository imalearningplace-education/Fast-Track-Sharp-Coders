using System;
using System.IO;
namespace TratamentoExcecoes{
    class Program{
        static void Main(string[] args)
        {
            // DividirNumeroPor(0);
            // AcessarVetor(9);
            // ConverterObjetoParaString(null);
            // ConverterObjetoParaInteiro("abc");
            // ObterPosicaoDePalavraEmTexto(null);
            // ObterArquivoParaEscrita("C:Teste.txt");
            // try{
            //     Triangulo t1 = new Triangulo(30, 12, 12);
            // }
            // catch (InvalidTriangleSideException e){
            //     Console.WriteLine(e.Message + "\nLado inválido: {0}",e.WrongSide);
            // }

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
        //NullReferenceException
        static void ConverterObjetoParaString(Object obj){
            try{
                Console.WriteLine(obj.ToString());
            }
            catch (NullReferenceException e){
                Console.WriteLine(e.Message);
            }
        }
        //InvalidCastException or FormatException
        static void ConverterObjetoParaInteiro(Object obj){
            try{
                //Console.WriteLine(Convert.ToInt32(obj));
                Console.WriteLine((int)(obj));
            }
            catch (Exception e){
                if(e is InvalidCastException || e is FormatException)
                    Console.WriteLine("O objeto passado como parâmetro não pôde ser convertido para inteiro.");
            }
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
        //IOException e Derivadas
        // static StreamWriter ObterArquivoParaEscrita(string caminho){
        //     if(caminho is null){
        //         Console.WriteLine("Você não informou o caminho para o arquivo.");
        //         return null;
        //     }
        //     try{
        //         var fs = new FileStream(caminho, FileMode.CreateNew);
        //         return new StreamWriter(fs);
        //     }
        //     catch (FileNotFoundException){
        //         Console.WriteLine("O arquivo não pôde ser encontrado.");
        //     }
        //     catch (DirectoryNotFoundException){
        //         Console.WriteLine("O diretório não pôde ser encontrado.");
        //     }
        //     catch (DriveNotFoundException){
        //         Console.WriteLine("O disco não pôde ser encontrado.");
        //     }
        //     catch (PathTooLongException){
        //         Console.WriteLine("O caminho do arquivo excede o tamanho máximo suportado.");
        //     }
        //     catch (UnauthorizedAccessException){
        //         Console.WriteLine("Você não tem permissão para acessar o arquivo.");
        //     }
        //     catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32){
        //         Console.WriteLine("Há uma violação de compartilhamento de arquivo.");
        //     }
        //     catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80){
        //         Console.WriteLine("O arquivo já existe.");
        //     }
        //     catch (IOException e){
        //         Console.WriteLine("Uma exceção ocorreu:\nCódigo do erro: {0}\nMensagem: {1}",e.HResult & 0x0000FFFF, e.Message);
        //     }
        //     return null;
        // }
    }
    class InvalidTriangleSideException : Exception{
        const string mensagemErro = "Um dos lados do triângulo excede o tamanho máximo permitido.";
        public char WrongSide { get; set; }
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
}