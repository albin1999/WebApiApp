using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.DBAccess;
//Gives DB access to the program to reduce redundancy 
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    //Using ms extension config to talk to json/Dependency injection 

    /// <summary>
    /// Get the Config data to the config variable. To make it talk to the depedency list, so you dont have to write more lines.
    /// </summary>
    /// <param name="config"></param>
    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }


    /// <summary>
    ///  Make Generic Method, async means syncs when run. Task = return a set of some type. Then usa a string with the procedures. And U ammount of parameters. Then you need a connection string that makes the sql query possiable 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="storedProcedure">Sql Procedure</param>
    /// <param name="parameters">The parameters that is needed</param>
    /// <param name="connectionId">Sql string</param>
    /// <returns>Set of data</returns>
    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        //This line sync with sql server and excecute the stored procedure, when it does that it will return IEnumerable<T> 
        return await connection.QueryAsync<T>(storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        //Just uppdate, does not want anything to return.
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
