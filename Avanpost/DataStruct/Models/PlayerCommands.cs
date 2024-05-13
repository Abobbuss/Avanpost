using System.ComponentModel;

namespace Avanpost.DataStruct.Models
{
    public enum PlayerCommands
    {
        [Description("осмотреться")]
        LookAround,
        [Description("идти")]
        Go,
        [Description("взять")]
        Take,
        Unknown
    }
}
