using System;
namespace Pansoft.CQMS.Options.Base
{
    interface IOption
    {
        object Entity { get; }
        event global::Pansoft.CQMS.Options.Option.OptionChangedEventHandler OptionChangedEvent;
        event global::Pansoft.CQMS.Options.Option.OptionChangingEventHandler OptionChangingEvent;
        event global::Pansoft.CQMS.Options.Option.OptionLoadedEventHandler OptionLoadedEvent;
        global::Pansoft.CQMS.Options.Option SetOptionValue(string key, object value);
    }
}
