using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EltonTradutor.Models
{
    public class DataAccess
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _db { get; }

        public DataAccess()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _db = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }


        public IMongoCollection<Palavra>Palavra
        {
            get
            {
                return _db.GetCollection<Palavra>("Palavra");
            }
        }

        public IEnumerable <Palavra> BuscarPalavra(string queryParametro)
            {


                var palavra = _db.GetCollection<Palavra>("Palavra");
                var query = from e in palavra.AsQueryable<Palavra>()
                            where e.Termo == queryParametro.ToLower()
                            select e;

                return query;
            }
     }
}

