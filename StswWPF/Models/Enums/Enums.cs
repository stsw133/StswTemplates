using System.ComponentModel;

namespace StswWPF;

/// <summary>
/// Value used for <see cref="ExampleModel.Example1"/>.
/// </summary>
public enum Example1
{
    [Description("Display0")]
    Value0,

    [Description("Display1")]
    Value1,

    [Description("Display2")]
    Value2
}

/// <summary>
/// Value used for <see cref="ExampleModel.Example2"/>.
/// </summary>
public enum Example2
{
    Value0,
    Value1,
    Value2,
    Value3
}
