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
//This  is the PyroServer version mark that is manulay incremented.
//The Major is to stay wiht the Major FHIR Spec version STU3 = 3, STU4 = 4
//The rest is for our use and a Build inrement means DB chnage
// I do want  to align this with the EF Migration history in future.
[assembly: AssemblyFileVersion("3.0.2.2")]
