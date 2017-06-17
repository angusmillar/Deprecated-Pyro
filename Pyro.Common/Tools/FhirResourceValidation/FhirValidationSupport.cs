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

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class FhirValidationSupport
  {
    private IResourceResolver ResourceResolver;
    public FhirValidationSupport()
    {
      // Ensure the FHIR extensions are registered
      Hl7.Fhir.FhirPath.PocoNavigatorExtensions.PrepareFhirSymbolTableFunctions();

      var MultiResolver = new MultiResolver();
      // Use the specification zip that is local (from the NuGet package)
      MultiResolver.AddSource(new ZipSource("specification.zip"));
      // Try using the fixed content
      MultiResolver.AddSource(new AustralianFhirProfileResolver());

      // Then look to a specific FHIR Registry Server
      // Then look in this server
      var Cache = new Pyro.Common.Cache.CacheCommon();
      MultiResolver.AddSource(new WebResolver(id => new FhirClient(Cache.WebConfigServiceBaseURL())));

      // for Debugging look somewhere?
      //MultiResolver.AddSource(new WebResolver(id => new FhirClient("http://localhost:8888/test/stu3/fhir")));

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

  }
}
