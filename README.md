Castle Windsor + FluentSecurity
==========================================

An ASP.NET MVC4 sample site, using [Castle Windsor](http://www.castleproject.org/) for DI and [FluentSecurity](http://www.fluentsecurity.net/) for authorization. 

Castle Windsor is an Inversion of Control container available for .NET and Silverlight. FluentSecurity "provides a fluent interface for configuring security in ASP.NET MVC. No attributes or nasty xml, just pure love."

Castle components are implemented in the /Core directory, where you will find the controller factory and some service installers, to name a few.

The /App_Start directory contains (in addition to the standard MVC config classes) a SecurityConfig class that declares and demonstrates a handful of FluentSecurity methods.


Please let me know if something is not obvious in this demo project, or if you'd like to see a Castle or FluentSecurity API implemented. I gladly accept pull-requests if you have something you think the community would find useful...
