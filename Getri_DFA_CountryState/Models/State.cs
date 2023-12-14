using System;
using System.Collections.Generic;

namespace Getri_DFA_CountryState.Models;

public partial class State
{
    public int StateId { get; set; }

    public string Name { get; set; } = null!;

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }
}
