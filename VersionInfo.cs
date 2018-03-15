using System.Reflection;

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers
// by using the '*' as shown below:
[assembly: AssemblyVersion("3.0.0.0")]
//I am going to try and align the Pyro service version with the FHIR spec version, will see how it goes. I can see an issue 
//if I choose to support two Fhir versions in the one build, will I do that, not sure.
//So, 3.0.1 is the FHIR spec and then the Pyro Service Build on the end.
[assembly: AssemblyFileVersion("3.0.1.32")]
