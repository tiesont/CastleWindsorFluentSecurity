using System;
using System.ComponentModel;

namespace CastleWindsorFluentSecurity
{
    public enum Role
    {
        [Description("Anonymous")]
        Anonymous = 1,

        [Description("Super User")]
        SuperUser = 100
    }
}