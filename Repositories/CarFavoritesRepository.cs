using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
    public class CarFavoritesRepository
    {
        private readonly IDbConnection _db;

        public CarFavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal DTOCarFavorite GetById(int id)
        {
            string sql = "SELECT * FROM carfavorites WHERE id = @id";
            return _db.QueryFirstOrDefault<DTOCarFavorite>(sql, new { id });
        }
        internal IEnumerable<ViewModelCarFavorite> GetByUser(string user)
        {
            string sql = @"
            SELECT
            c.*,
            cf.id as favoriteId
            FROM carfavorites cf
            INNER JOIN cars c ON c.id = cf.carId
            WHERE user = @user;";

            return _db.Query<ViewModelCarFavorite>(sql, new { user });
        }

        internal bool hasRelationship(DTOCarFavorite fav)
        {
            string sql = "SELECT * FROM carfavorites WHERE carId = @CarId AND user = @User";
            var found = _db.QueryFirstOrDefault<DTOCarFavorite>(sql, fav);
            return found != null;
        }

        internal DTOCarFavorite Create(DTOCarFavorite fav)
        {
            string sql = @"
            INSERT INTO carfavorites
            (user, carid)
            VALUES
            (@User, @CarId);
            SELECT LAST_INSERT_ID();
            ";
            fav.Id = _db.ExecuteScalar<int>(sql, fav);
            return fav;
        }
        internal bool Delete(int id, string user)
        {
            string sql = "DELETE FROM carfavorites WHERE id = @id AND user = @user LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, user });
            return affectedRows == 1;
        }
    }
}