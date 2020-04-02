using System.ComponentModel;

namespace TroyWeb.TwilioAPI.Enums
{
    public enum FaxQuality
    {
        [Description("Standard")]
        Standard,
        [Description("Fine")]
        Fine,
        [Description("Super Fine")]
        SuperFine
    }
}