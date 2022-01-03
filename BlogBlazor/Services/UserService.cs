using BlogBlazor.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogBlazor.Services;

public class UserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUser(string username, string password)
    {
        await _dbContext.Users.AddAsync(new User(username, password));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistUser(string username, string password)
    {
        return await _dbContext.Users.AnyAsync(user => user.UserName == username && user.Password == password);
    }
}
