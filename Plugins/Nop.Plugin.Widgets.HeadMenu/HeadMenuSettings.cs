
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.HeadMenu
{
    public class HeadMenuSettings : ISettings
    {
        public string Text1 { get; set; }
        public string Link1 { get; set; }

        public string Text2 { get; set; }
        public string Link2 { get; set; }
    }
}