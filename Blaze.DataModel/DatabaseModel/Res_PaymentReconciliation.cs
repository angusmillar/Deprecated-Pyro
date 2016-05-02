using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_PaymentReconciliation
  {
    public int Res_PaymentReconciliationID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string disposition_String {get; set;}
    public string organizationidentifier_Code {get; set;}
    public string organizationidentifier_System {get; set;}
    public string organizationreference_FhirId {get; set;}
    public string organizationreference_Type {get; set;}
    public virtual Blaze_RootUrlStore organizationreference_Url { get; set; }
    public int? organizationreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string outcome_Code {get; set;}
    public string outcome_System {get; set;}
    public string requestidentifier_Code {get; set;}
    public string requestidentifier_System {get; set;}
    public string requestorganizationidentifier_Code {get; set;}
    public string requestorganizationidentifier_System {get; set;}
    public string requestorganizationreference_FhirId {get; set;}
    public string requestorganizationreference_Type {get; set;}
    public virtual Blaze_RootUrlStore requestorganizationreference_Url { get; set; }
    public int? requestorganizationreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string requestprovideridentifier_Code {get; set;}
    public string requestprovideridentifier_System {get; set;}
    public string requestproviderreference_FhirId {get; set;}
    public string requestproviderreference_Type {get; set;}
    public virtual Blaze_RootUrlStore requestproviderreference_Url { get; set; }
    public int? requestproviderreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string requestreference_FhirId {get; set;}
    public string requestreference_Type {get; set;}
    public virtual Blaze_RootUrlStore requestreference_Url { get; set; }
    public int? requestreference_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_PaymentReconciliation_Index_identifier> identifier_List { get; set; }
   
    public Res_PaymentReconciliation()
    {
      this.identifier_List = new HashSet<Res_PaymentReconciliation_Index_identifier>();
    }
  }
}

