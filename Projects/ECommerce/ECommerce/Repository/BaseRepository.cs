using System.Reflection.Metadata;
using System.Text.Json;

namespace ECommerce.BaseRepository; 

public abstract class BaseRepository<ENTITY> 
    : IRepository<ENTITY, long> {

    private string _filename;

    public BaseRepository(string filename) {
        string path = @"database\";
        string extension = ".json";
        _filename = path + filename + extension;
        if(! File.Exists(_filename))
            File.Create(_filename);
    }

    public List<ENTITY>? GetAll() {
        string content = File.ReadAllText(_filename);
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Deserialize<List<ENTITY>>(content, options);
    }

    public virtual bool Delete(ENTITY entity) {
        throw new NotImplementedException();
    }

    public bool DeleteByID(long id) {
        throw new NotImplementedException();
    }


    public ENTITY GetById(long id) {
        throw new NotImplementedException();
    }

    public ENTITY Save(ENTITY entity) {
        throw new NotImplementedException();
    }
}
