using DataAccess.DBAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;


    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    //Get users method
    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>("dbo.PUser_GetAll", new { });


    /// <summary>
    /// Return a IEnumerable of the type User, can be null!!
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserModel?> GetUser(int id)
    {
        var result = await _db.LoadData<UserModel, dynamic>(
            "dbo.PUser_Get",
            new { Id = id });

        return result.FirstOrDefault(); //Return null if not found
    }

    /// <summary>
    /// Insert into table 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task InsertUser(UserModel user) =>
        _db.SaveData("dbo.PUser_Insert", new { user.FirstName, user.LastName });

    /// <summary>
    /// Update a row in table
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task UpdateUser(UserModel user) =>
        _db.SaveData("dbo.PUser_Update", user);

    /// <summary>
    /// Delete row in table
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteUser(int id) =>
        _db.SaveData("dbo.PUser_Delete", new { Id = id });
}
