using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Rest;

namespace Blaze.Engine.Rest
{
  public class FhirUriModel
  {
    private readonly char UriDelimieter = '/';
    private readonly char UriSearchParameterDelimieter = '?';
    public FhirUriModel(Uri Uri)
    {
      if (HttpUtil.IsRestResourceIdentity(Uri))
      {
        var AbsolutePathArray = Uri.AbsolutePath.Split(UriDelimieter);
        if (AbsolutePathArray.Count() > 1)
          this.ApiSegment = AbsolutePathArray[1];
        if (AbsolutePathArray.Count() > 2)
          this.ResourseType = AbsolutePathArray[2];
        if (AbsolutePathArray.Count() > 3)
          this.Id = AbsolutePathArray[3].Split(UriSearchParameterDelimieter)[0].Trim();
        if (AbsolutePathArray.Count() > 4)
          this.Compartment = AbsolutePathArray[4].Split(UriSearchParameterDelimieter)[0].Trim();
        this.Schema = Uri.Scheme;
        this.SchemaDilemeter = Uri.SchemeDelimiter;
        this.Authority = Uri.Authority;
        this.Uri = Uri;
      }
      else
      {
        //create a exceptopm
      }
      

    }
    public Uri Uri { get; set; }
    //'Http' or 'Https'
    public string Schema { get; set; }
    /// <summary>
    /// '://'
    /// </summary>
    public string SchemaDilemeter { get; set; }
    // 'www.somewhere.com/something/over/here'
    public string Authority { get; set; }
    // 'fhirapi'
    public string ApiSegment { get; set; }
    // 'Patient'
    public string ResourseType { get; set; }
    // 123456789
    public string Id { get; set; }
    // Patient
    public string Compartment { get; set; }


    public Uri RootFhirUri 
    { 
      get
      {
        string NewUriString = String.Format("{0}{1}{2}{3}{4}{5}", Schema, SchemaDilemeter, Authority, UriDelimieter, ApiSegment, UriDelimieter);
        return new Uri(NewUriString);
      }
    }
  }
}
