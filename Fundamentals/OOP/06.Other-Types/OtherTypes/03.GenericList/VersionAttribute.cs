using System;

namespace _03.GenericList
{
    [AttributeUsage(AttributeTargets.Struct 
        | AttributeTargets.Class
        | AttributeTargets.Interface
        | AttributeTargets.Enum
        | AttributeTargets.Method)]

    public class VersionAttribute : Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
            this.Version = this.Major + "."  + this.Minor;
        }

        public int Major { get; }
        public int Minor { get; }
        public string Version { get; }
    }
}