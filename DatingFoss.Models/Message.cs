using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Domain;
public class Message
{
    public string? FromUsername { get; init; }
    public string? Content { get; init; }
    public string? ToUsername { get; init; }
    public DateTime? SentDate { get; set; } = DateTime.UtcNow;
}
