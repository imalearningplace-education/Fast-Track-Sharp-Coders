namespace ECommerce.BaseRepository; 

public interface IRepository<ENTITY, ID> {

    // 1 pessoa -> * mensagens
    // * mensagem -> * pessoa
    // grupo -> * pessoas
    // grupo -> * mensagens
    // pessoa -> * grupos
    // mensagem -> 1 grupo

    List<ENTITY>? GetAll();
    ENTITY? GetById(ID id);
    ENTITY Save(ENTITY entity);
    bool Delete(ENTITY entity);
    bool DeleteByID(ID id);

}
