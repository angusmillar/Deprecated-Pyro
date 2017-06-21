using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Validation;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Specification.Terminology;
using System.IO;
using System.Web.Hosting;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class FhirValidationSupport
  {
    private IResourceResolver ResourceResolver;
    private string SpecificationFileName = "specification.zip";
    public FhirValidationSupport(Interfaces.Service.IResourceServices ResourceServices)
    {
      // Ensure the FHIR extensions are registered
      Hl7.Fhir.FhirPath.PocoNavigatorExtensions.PrepareFhirSymbolTableFunctions();

      var MultiResolver = new MultiResolver();
      // Use the specification zip that is local (from the NuGet package)

      //var SpecificationFilePath = Path.Combine(AppContext.BaseDirectory, @"bin\specification.zip");      
      MultiResolver.AddSource(new ZipSource(ResolveSpecificationZipFilePath()));

      // Try using the fixed content
      MultiResolver.AddSource(new AustralianFhirProfileResolver());

      // A specific FHIR Registry Server on the web           
      //MultiResolver.AddSource(new WebResolver(id => new FhirClient("http://someonesfhirserver.com/fhir")));

      //Look in this Pyro server's Resource
      MultiResolver.AddSource(new InternalServerProfileResolver(ResourceServices));

      //for Debugging look somewhere?
      //MultiResolver.AddSource(new WebResolver(id => new FhirClient("http://localhost:50579/test/stu3/fhir")));

      // Prepare the artefact resolvers (cache to reduce complexity)
      ResourceResolver = new CachedResolver(MultiResolver);
    }

    public OperationOutcome Validate(Resource ResourceToValidate, IList<string> StructureDefinitionUriList)
    {
      var ctx = new ValidationSettings()
      {
        ResourceResolver = ResourceResolver,
        GenerateSnapshot = true,
        ResolveExteralReferences = true,
        Trace = false
      };

      Validator Validator = new Validator(ctx);
      return Validator.Validate(ResourceToValidate, StructureDefinitionUriList.ToArray());
    }

    public OperationOutcome Validate(Resource ResourceToValidate, IEnumerable<StructureDefinition> StructureDefinitionList)
    {
      var ctx = new ValidationSettings()
      {
        ResourceResolver = ResourceResolver,
        GenerateSnapshot = true,
        ResolveExteralReferences = true,
        Trace = false
      };

      Validator Validator = new Validator(ctx);
      return Validator.Validate(ResourceToValidate, StructureDefinitionList);


    }

    private string ResolveSpecificationZipFilePath()
    {
      if (HostingEnvironment.IsHosted)
      {
        //If running is IIS either IIS Express in dev or IIS in production i.e (Pyro.Web)
        return Path.Combine(AppContext.BaseDirectory, @"bin\" + SpecificationFileName);
      }
      else
      {
        //If running as a console server i.e (Pyro.ConsoleServer)
        return Path.Combine(AppContext.BaseDirectory, SpecificationFileName);
      }

    }
  }
}
