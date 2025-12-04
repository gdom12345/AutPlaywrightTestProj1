using System.ComponentModel;

namespace AutPlaywrightTestProj.Framework
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class LocatorProperties : Attribute
    {
        [DefaultValue(LocatorType.Id)]
        public LocatorType LocatorType { get; set; }

        public string Using { get; set; }
    }
}
