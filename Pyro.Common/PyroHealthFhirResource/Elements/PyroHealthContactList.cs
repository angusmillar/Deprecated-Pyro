using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.Elements
{
  public static class PyroHealthContactDetailAngusMillar
  {    
    public static ContactDetail GetContactDetail()
    {
      var Contact = new ContactDetail();
      Contact.Name = "Angus Millar";
      Contact.Telecom = new List<ContactPoint>();
      var PhoneContactPoint = new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Mobile, "0481 059 995");
      PhoneContactPoint.Rank = 1;
      PhoneContactPoint.Period = new Period();
      PhoneContactPoint.Period.StartElement = new FhirDateTime(new DateTimeOffset(2017, 12, 22, 8, 00, 00, new TimeSpan(8, 00, 00)));
      Contact.Telecom.Add(PhoneContactPoint);

      var EmailContactPoint = new ContactPoint(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Home, "angusbmillar@gmail.com");
      EmailContactPoint.Rank = 1;
      EmailContactPoint.Period = new Period();
      EmailContactPoint.Period.StartElement = new FhirDateTime(new DateTimeOffset(2017, 12, 22, 8, 00, 00, new TimeSpan(8, 00, 00)));
      Contact.Telecom.Add(EmailContactPoint);
      return Contact;
    }
  }
}
