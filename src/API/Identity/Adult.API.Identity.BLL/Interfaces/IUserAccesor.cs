﻿using Adult.API.Identity.DAL.Entities;

namespace Adult.API.Identity.BLL.Interfaces
{
    public interface IUserAccesor
    {
        Task<User> GetUserAsync();
        string GetUserId();
    }
}
