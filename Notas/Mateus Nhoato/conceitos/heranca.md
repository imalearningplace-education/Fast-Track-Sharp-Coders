# Herança
É um tipo de associação que permite que uma classe herde dados e comportamentos de outra
Vantagens
- Reuso
- [Polimorfismo](polimorfismo.md)

Definições importantes:

- Relação "é-um"
- Generalização / especialização
- Superclasse (classe base) / subclasse (classe derivada)
- Herança / extensão
- Herança é uma associação entre classes (e não entre objetos)

Sintaxe:
- **:** (estende)
- **base** (referência p/ a superclasse)

## Upcasting
Casting da subclasse p/ a superclasse

- Uso comum: polimorfismo

## Downcasting
Casting da superclasse p/ a subclasse
- Palavra **as**
- Palavra **in**
- Uso comum: métodos que recebem parâmetros genéricos (ex: Equals)

## Sobreposição ou sobrescrita
É a implementação de um método de uma superclasse na subclasse. Para que um método comum (não abstrato) possa ser sobreposto, deve ser incluído nele o prefixo "`virtual`". Ao sobrescrever um método, devemos incluir nele o prefixo "override".

## Palavra base na sobrescrita
É possível chamar a implementação da superclasse usando a palavra base.

Exemplo: suponha que a regra para saque na conta poupança seja realizar o saque normalmente da superclasse (conta) e depois descontar mais 2 reais:
```cs
public override void Sacar(double quantia)
{
    base.Sacar(quantia);
    Balanco -= 2.0;
}
```