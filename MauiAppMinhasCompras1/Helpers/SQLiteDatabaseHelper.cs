using MauiAppMinhasCompras1.Models;
using SQLite;

namespace MauiAppMinhasCompras1.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)     
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> insert(Produto p)  
        {
            return _conn.InsertAsync(p);
        }

        public Task<int> update(Produto p) 
        {
            string sql = "UPDATE Produto SET Desquicao = ?, Quantidade = ?, Preco = ? WHERE Id = ?";
            return _conn.ExecuteAsync(
                sql, p.Desquicao, p.Quantidade, p.Preco, p.Id
            );
        }

        public Task<int> delete(int id) 
        {
           return _conn.DeleteAsync<Produto>(id);
        }   

        public Task<List<Produto>> getAll() 
        { 
           return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM Produto WHERE Desquicao LIKE ?";
            return _conn.QueryAsync<Produto>(sql, $"%{q}%");
        }
    } // <-- Corrigido: fechando a classe corretamente
} // <-- Corrigido: fechando o namespace corretamente
