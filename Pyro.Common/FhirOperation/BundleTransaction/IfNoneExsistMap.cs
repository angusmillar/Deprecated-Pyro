using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.FhirOperation.BundleTransaction
{
  public class IfNoneExistsMapItem
  {    
    public string FullUrl { get; set; }
    public string FullUrlUUID { get; set; }
    public string FhirId { get; set; }
    public string ResourceReference { get; set; }
    public string IfNoneExistEntryRequestProperty { get; set; }
    public string ResourceName { get; set; } 
    public bool FoundInDatabase { get; set; }
    public Resource DatabaseResource { get; set; }
    public string ResourceVersion { get; set; }
    public DateTimeOffset? ResourceLastUpdated { get; set; }
    public Bundle.EntryComponent Entry { get; set; }

    public IfNoneExistsMapItem()
    {
      this.FoundInDatabase = false;
      this.ResourceLastUpdated = null;
    }

    public void LoadEntry(Bundle.EntryComponent Entry)
    {
      this.FullUrl = Entry.FullUrl;
      this.FullUrlUUID = GetUUIDfromFullURL(Entry.FullUrl);
      this.FhirId = Tools.FhirGuid.FhirGuid.NewFhirGuid();
      this.ResourceName = Entry.Resource.ResourceType.GetLiteral();
      this.ResourceReference = $"{this.ResourceName}/{this.FhirId}";
      this.Entry = Entry;
      if (Entry.Request != null && !string.IsNullOrWhiteSpace(Entry.Request.IfNoneExist))
      {
        this.IfNoneExistEntryRequestProperty = Entry.Request.IfNoneExist;
      }
    }
    public void UpdateFhirId(string FhirId)
    {
      this.FhirId = FhirId;
      this.ResourceReference = $"{this.ResourceName}/{FhirId}";
      if (!string.IsNullOrWhiteSpace(Entry.Resource.Id))
        Entry.Resource.Id = FhirId;
    }

    public void RemoveIfNoneExists()
    {
      if (Entry.Request != null && !string.IsNullOrWhiteSpace(Entry.Request.IfNoneExist))
      {
        Entry.Request.IfNoneExist = null;
        this.IfNoneExistEntryRequestProperty = string.Empty;
      }
    }

    private string GetUUIDfromFullURL(string FullURL)
    {
      string Result = FullURL;
      if (FullURL.Contains(":"))
      {
        var FullURLUUIDSplit = FullURL.Split(':');
        if (FullURLUUIDSplit.Length == 3)
        {
          Result = FullURLUUIDSplit[2];
        }
        else if (FullURLUUIDSplit.Length == 2)
        {
          Result = FullURLUUIDSplit[1];
        }
      }
      return Result;
    }
  }
}
