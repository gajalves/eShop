using Dapper;
using eShop.Discount.Core.Entities;
using eShop.Discount.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eShop.Discount.Infra.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                ("INSERT INTO Coupon (Name, Description, Amount) VALUES (@Name, @Description, @Amount)",
                    new { Name = coupon.Name, Description = coupon.Description, Amount = coupon.Amount });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string name)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE Name = @Name",
                new { Name = name });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<Coupon> GetDiscount(string name)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE Name = @Name", new { Name = name});
            if (coupon == null)
                return new Coupon { Name = "No Discount", Amount = 0, Description = "No Discount Available" };

            return coupon;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
            ("UPDATE Coupon SET Name=@Name, Description = @Description, Amount = @Amount WHERE Id = @Id",
                new { Name = coupon.Name, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            if (affected == 0)
                return false;

            return true;
        }
    }
}
