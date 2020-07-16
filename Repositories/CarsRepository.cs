using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Car> GetCarsByUserId(string userId)
        {
            string sql = "SELECT * FROM cars WHERE userId = @userId";
            return _db.Query<Car>(sql, new { userId });
        }

        internal Car GetById(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal IEnumerable<Car> GetAll()
        {
            string sql = "SELECT * FROM cars";
            return _db.Query<Car>(sql);
        }

        internal Car Create(Car newCar)
        {
            string sql = @"
            INSERT INTO cars
            (make, model, userId, year, price, body, imgUrl)
            VALUES
            (@Make, @Model, @UserId, @Year, @Price, @Body, @ImgUrl);
            SELECT LAST_INSERT_ID()";
            newCar.Id = _db.ExecuteScalar<int>(sql, newCar);
            return newCar;
        }

        internal bool BidOnCar(Car carToBidOn)
        {
            string sql = @"
            UPDATE cars
            SET
            price = @Price
            WHERE id = @Id";
            int affectedRows = _db.Execute(sql, carToBidOn);
            return affectedRows == 1;
        }

        internal bool Edit(Car carToUpdate, string userId)
        {
            carToUpdate.UserId = userId;
            string sql = @"
            UPDATE cars
            SET
                price = @Price,
                make = @Make,
                model = @Model,
                imgUrl = @ImgUrl,
                year = @Year,
                body = @Body
            WHERE id = @Id
            AND userId = @UserId";
            int affectedRows = _db.Execute(sql, carToUpdate);
            return affectedRows == 1;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM cars WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}