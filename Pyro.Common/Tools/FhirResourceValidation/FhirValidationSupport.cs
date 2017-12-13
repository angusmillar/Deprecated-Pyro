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
using Pyro.Common.Interfaces.Service;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class FhirValidationSupport : IFhirValidationSupport
  {
    private IResourceResolver ResourceResolver;
    private readonly ICommonFactory ICommonFactory;

    public FhirValidationSupport(ICommonFactory ICommonFactory)
    {
      this.ICommonFactory = ICommonFactory;

      // Ensure the FHIR extensions are registered
      Hl7.Fhir.FhirPath.PocoNavigatorExtensions.PrepareFhirSymbolTableFunctions();

      var MultiResolver = new MultiResolver();

      //Load all the ResourceResolvers from the DI injection, current list in order is:
      //InternalServerProfileResolver
      //AustralianFhirProfileResolver
      //ZipSourceResolver
      foreach (IResourceResolver ResourceResolver in ICommonFactory.CreateResourceResolverList())
      {
        MultiResolver.AddSource(ResourceResolver);
      }

      //Below are manual loads for debugging

      //FHIR Specification.zip Zip file 
      //MultiResolver.AddSource(new ZipSourceResolver());

      // Try using the fixed content
      //MultiResolver.AddSource(new AustralianFhirProfileResolver());

      // A specific FHIR Registry Server on the web           
      //MultiResolver.AddSource(new WebResolver(id => new FhirClient("http://someonesfhirserver.com/fhir")));

      //Look in this Pyro server's Resource
      //MultiResolver.AddSource(new InternalServerProfileResolver());

      //for Debugging look somewhere?
      //MultiResolver.AddSource(new WebResolver(id => new FhirClient("http://localhost:50579/fhir")));

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
