using Pustok.DAL.DataContext.Entities.Common;
using System.ComponentModel;

namespace Pustok.DAL.DataContext.Entities;

public class Service : BaseEntity
{
    public required string MainText { get; set; }
    public required string SubText { get; set; }
    public required string IconUrl{ get; set; }
}
