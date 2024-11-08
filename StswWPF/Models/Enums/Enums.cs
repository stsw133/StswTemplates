using System.ComponentModel;

namespace StswWPF;

public enum DocStatus
{
    [Description("In buffer")]
    Buffer = 0,

    [Description("Confirmed")]
    Confirmed = 1,

    [Description("Posted")]
    Posted = 2,

    [Description("Canceled")]
    Canceled = -1
}

public enum DocType
{
    Purchase,
    Sales
}
