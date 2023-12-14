using System;
using System.Collections.Generic;
using Getri_DFA_CountryState.Models;
using Microsoft.EntityFrameworkCore;

namespace Getri_DFA_CountryState.EntityFramework;

public partial class GetricountryStateDbContext : DbContext
{
    public GetricountryStateDbContext()
    {
    }

    public GetricountryStateDbContext(DbContextOptions<GetricountryStateDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<State> State { get; set; }
}
