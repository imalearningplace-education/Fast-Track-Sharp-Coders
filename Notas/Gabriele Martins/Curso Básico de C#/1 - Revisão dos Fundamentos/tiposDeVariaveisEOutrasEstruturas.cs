using System;
class tiposDeVariaveisEOutrasEstruturas{
    public static void Main(string[] args){
        int n1=3;
        bool ePar=n1%2==0;
        if(!ePar){//exclamação significa negação de ePar
            Console.WriteLine("É impar.");
        }
        else{
            Console.WriteLine("É par.");
        }
        switch(n1){//funciona como if
            case 1:
                Console.WriteLine("O valor é 1.");
                break;
            case 2:
                Console.WriteLine("O valor é 2.");
                break;
            case 3:
                Console.WriteLine("O valor é 3.");
                break;
            case 4:
                Console.WriteLine("O valor é 4.");
                break;
            default:
                Console.WriteLine("O valor não está entre 1 e 4.");
                break;
        }
        for(int i=0; i<10; i++){
            if(i==5){
                continue;//faz pular a iteração quando i==5 e continuar com as outras iterações
            }
            Console.WriteLine("Iteração {0}.",i);
        }
    }
}