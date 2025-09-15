using MauiAppMinhasCompras1.Models;
using SQLite;

namespace MauiAppMinhasCompras1.Helpers
{
    internal class SQLiteDatabaseHelper
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

        public Task<List<Produto>> update(Produto p) 
        {
            string sql = "UPDATE Produto SET Desquicao = ?, Quantidade = ?, Preco = ? WHERE Id = ?";
            return _conn.QueryAsync<Produto>(
                sql, p.Desquicao, p.Quantidade, p.Preco, p.Id
                );
        }

        public Task<int>  delete(int id) 
        {
           return _conn.table<Produto>().DeleteAsync(i => i.Id == id);
        }   

        public Task<int> getAll() 
        { 
           return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q) 
        
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%" + q + "%' ";
            return _conn.QueryAsync<Produto>(sql);
        }

    }
