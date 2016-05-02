using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_PaymentNotice
  {
    public int Res_PaymentNoticeID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string organizationidentifier_Code {get; set;}
    public string organizationidentifier_System {get; set;}
    public string organizationreference_FhirId {get; set;}
    public string organizationreference_Type {get; set;}
    public virtual Blaze_RootUrlStore organizationreference_Url { get; set; }
    public int? organizationreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string paymentstatus_Code {get; set;}
    public string paymentstatus_System {get; set;}
    public string provideridentifier_Code {get; set;}
    public string provideridentifier_System {get; set;}
    public string providerreference_FhirId {get; set;}
    public string providerreference_Type {get; set;}
    public virtual Blaze_RootUrlStore providerreference_Url { get; set; }
    public int? providerreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string requestidentifier_Code {get; set;}
    public string requestidentifier_System {get; set;}
    public string requestreference_FhirId {get; set;}
    public string requestreference_Type {get; set;}
    public virtual Blaze_RootUrlStore requestreference_Url { get; set; }
    public int? requestreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string responseidentifier_Code {get; set;}
    public string responseidentifier_System {get; set;}
    public string responsereference_FhirId {get; set;}
    public string responsereference_Type {get; set;}
    public virtual Blaze_RootUrlStore responsereference_Url { get; set; }
    public int? responsereference_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? statusdate_DateTimeOffset {get; set;}
    public ICollection<Res_PaymentNotice_Index_identifier> identifier_List { get; set; }
   
    public Res_PaymentNotice()
    {
      this.identifier_List = new HashSet<Res_PaymentNotice_Index_identifier>();
    }
  }
}

