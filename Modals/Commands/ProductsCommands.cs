using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

public class ProductsSql
{

    private MySqlConnection connection = null;
    private MySqlCommand sqlCommand = null;


    public ProductsSql(IConfiguration configuration)
    {
        connection = new MySqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Default").Value);
    }

    public async Task<DbDataReader> Create(string PName, decimal PPrice, int PQuantity, string PDescription, string PType)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("INSERT INTO products(PName,PPrice,PQuantity,PDescription,PType)VALUES('" + PName + "','" + PPrice + "','" + PQuantity + "','" + PDescription + "','" + PType + "')", connection);

        var products = await sqlCommand.ExecuteReaderAsync();

        return products;

    }

    public async Task<DbDataReader> Update(int PId, string PName, decimal PPrice, int PQuantity, string PDescription, string PType)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("UPDATE  products SET PName='" + PName + "',PPrice=" + PPrice + ",PQuantity=" + PQuantity + ",PDescription='" + PDescription + "',PType='" + PType + "' WHERE PId=" + PId + "", connection);

        var products = await sqlCommand.ExecuteReaderAsync();

        await products.ReadAsync();

        return products;

    }

    public async Task<DbDataReader> FindAll()
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("SELECT * FROM products", connection);

        var products = await sqlCommand.ExecuteReaderAsync();

        return products;

    }

    public async Task<DbDataReader> FindById(int PId)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("SELECT * FROM products WHERE PId=" + PId + "", connection);

        var products = await sqlCommand.ExecuteReaderAsync();

        await products.ReadAsync();

        return products;

    }

    public async Task<DbDataReader> DeleteById(int PId)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("DELETE FROM products WHERE PId=" + PId + "", connection);

        var products = await sqlCommand.ExecuteReaderAsync();

        await products.ReadAsync();

        return products;

    }
}