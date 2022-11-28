using System;
using MCard40.Data.Context;
using MCard40.Model.Identity;
using MCard40.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCard40.Web.Controllers;
public class CopyUserController 
{
    private readonly MCard40DbContext _dbContext;

    public CopyUserController(MCard40DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddUser(MCardUser user)
    {
        var copyUser = MapUser(user);
        _dbContext.Users.Add(copyUser);

        _dbContext.SaveChanges();
    }

    private User MapUser(MCardUser users)
    {
        return new User()
        {
            Id = users.Id,
            Nickname = users.UserName
        };
    }
}
