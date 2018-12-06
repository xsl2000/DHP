using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.DCV
{
    public interface IOnModelCreating
    {
        void OnModelCreating(ModelBuilder builder);
    }
}
