# Interface

 Interface é um tipo que define um conjunto de operações que uma classe deve implementar. A interface estabelece um **contrato** que a classe deve cumprir.

Pra quê usar interfaces?
    - Para criar sistemas com **baixo acoplamento** e **flexíveis**.

## Inversão de controle

Padrão de desenvolvimento que consiste em retirar da classe a responsabilidade de instanciar suas dependências.

### Injeção de dependência

É uma forma de realizar a inversão de controle: um componente externo instância a dependência, que é então injetada no objeto "pai". Pode ser implementada de várias formas:
- Construtor
- Objeto de instaciação (builder/ factory)
- Container / framework

### Injeção de dependência com o Contêiner DI padrão do C#:

Podemos usar **três escopos com o contêiner DI padrão**. Esses escopos afetam como o serviço é resolvido e descartado pelo provedor de serviços.

- 1- **Transient**: *builder.services.AddTransiente<,>*
    - Uma nova instância do serviço é criada cada vez que um serviço é solicitado do provedor de serviços. Se o serviço for descartável, o escopo do serviço monitorará todas as instâncias do serviço e destruirá todas as instâncias do serviço criadas nesse escopo quando o escopo do serviço for descartado.

- 2-**Scoped**: *builder.services.AddScoped<,>*
    - Uma nova instância do serviço é criada em cada **request**. A cada requisição temos uma nova instância do serviço. Se o serviço for descartável, ele será descartado quando o escopo do serviço for descartado.

- 3-**Singleton**: *builder.services.AddSingleton<,>*
    - Apenas uma instância do serviço é criada se ainda não estiver registrada como uma instância. Um objeto do serviço é criado e fornecido para todas as requisições. Todas as requisições obtém o mesmo objeto.