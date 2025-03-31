using System.Collections.Generic;

namespace BetabitUserManager.API.Controllers.Resources;

public class ErrorResource
{
    public bool Success => false;
    public List<string> Messages { get; private set; }

    public ErrorResource(List<string> messages)
    {
        Messages = messages ?? new List<string>();
    }
}
