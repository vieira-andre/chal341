using System.ComponentModel;

namespace chal341.Models
{
    public enum ClientSegment
    {
        Undefined,
        [Description("Retail")]
        RETL,
        [Description("Personnalité")]
        PSNL,
        [Description("Private")]
        PRIV
    }
}
