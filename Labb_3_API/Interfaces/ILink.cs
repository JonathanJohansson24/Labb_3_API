﻿using Labb_3_API.Models;

namespace Labb_3_API.Interfaces
{
    public interface ILink
    {
        Task<IEnumerable<Link>> GetAll();
    }
}
