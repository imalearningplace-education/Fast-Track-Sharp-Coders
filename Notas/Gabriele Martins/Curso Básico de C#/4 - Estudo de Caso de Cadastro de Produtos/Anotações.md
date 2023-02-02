# Estudo de Caso de Cadastro de Produtos
No algoritmo criado nas últimas aulas, como fazer para permitir que o usuário cadastre novos produtos?
```cs
string comandoEscolhido="";

while(comandoEscolhido!="S"){
    //Exibição do menu:
    Console.Clear();
    Console.WriteLine("Escolha a opção: ");
    Console.WriteLine("1 - Cadastrar produto");
    Console.WriteLine("2 - Listar produtos");
    Console.WriteLine("S - Sair");

    //Leitura da opção desejada pelo usuário:
    Console.Write("Opção desejada: ");
    comandoEscolhido=Console.ReadKey().KeyChar.ToString().ToUpper();

    //Processamento do comando digitado pelo usuário:
    switch(comandoEscolhido){
        case "1":
            Console.Write("\nNome do Produto: ");
            string nome=Console.ReadLine();
            Console.Write("Preço do Produto: ");
            string preco=Console.ReadLine();
            Produto novoProduto=new Produto(nome,Convert.ToDouble(preco));
            produtos.Add(novoProduto);
            Console.WriteLine("Produto adicionado com sucesso!");
            Console.ReadKey();
            break;
        case "2":
            if(produtos.Count>0){
                Console.WriteLine("\nListagem de Produtos");
                foreach(Produto p in produtos){
                    Console.WriteLine(p.ObterTexto());
                }
                Console.Write("Pressione qualquer tecla para prosseguir...");
                Console.ReadKey();
            }
            else{
                Console.WriteLine("\nNão há produtos cadastrados.");
                Console.ReadKey();
            }
            break;
        case "S":
            Console.WriteLine("\nObrigado por usar o programa.");
            Console.ReadKey();
            break;
        default:
            Console.WriteLine("\nOpção invalida! Tente novamente.");
            Console.ReadKey();
            break;
    }
}
```