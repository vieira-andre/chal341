using System.ComponentModel;

namespace chal341.Models
{
    public enum CustomerSegment
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
