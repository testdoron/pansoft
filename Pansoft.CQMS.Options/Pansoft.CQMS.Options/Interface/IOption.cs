using System;
namespace Pansoft.ManagerDesktop.Options.Base
{
    interface IOption
    {
        object Entity { get; }
        event global::Pansoft.ManagerDesktop.Options.Option.OptionChangedEventHandler OptionChangedEvent;
        event global::Pansoft.ManagerDesktop.Options.Option.OptionChangingEventHandler OptionChangingEvent;
        event global::Pansoft.ManagerDesktop.Options.Option.OptionLoadedEventHandler OptionLoadedEvent;
        global::Pansoft.ManagerDesktop.Options.Option SetOptionValue(string key, object value);
    }
}
