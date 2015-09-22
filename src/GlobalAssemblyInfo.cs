using System.Reflection;

[assembly: AssemblyDescription("Skeleton description")]
[assembly: AssemblyProduct("Skeleton product")]
[assembly: AssemblyCopyright("Copyright © Michael Wolfenden 2015")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
