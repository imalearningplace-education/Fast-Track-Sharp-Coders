# Polimorfismo

Recurso que permite que variáveis de um mesmo tipo mais genérico possam apontar para objetos de tipos específicos diferentes, tendo assim comportamentos diferentes conforme cada tipo específico.

A associação do tipo específico com o tipo genérico é feita em tempo de execução (upcasting). Logo, o compilador não sabe para qual tipo específico a chama do método está sendo feita (ele só sabe que são duas variáveis do tipo X).

No exemplo abaixo a classe *SavingsAccount* **herda** (ou extende) da classe *Account*.

```cs
// A Account precisa de um Id, Nome e Balanço
Account acc1 = new Account(1001, "João", 500.0);
// Já a SavingsAccount também tem uma taxa de rendimento
Account acc2 = new SavingsAccount(1002, "José", 500.0, 0.01);

acc1.Saque(100);
acc2.Saque(100);
```
 
 Tanto a classe Account como a classe SavingsAccount têm o método Saque, sendo que eles podem ser diferentes (se o método foi sobrescrito na classe filha, a SavingsAccount). Logo, temos outro aspecto do polimorfismo: os métodos são chamados do mesmo jeito, mas podem ter implementações diferentes.



