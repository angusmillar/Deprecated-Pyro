using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

using ConsumerIHIBatch = Pyro.ADHA.mcaR3.ConsumerSearchIHIBatchSync;

using Pyro.ADHA.VendorLibrary.Common;

namespace Pyro.ADHA.VendorLibrary.HI
{
  /// <summary>
  /// Helper class to process faults.
  /// </summary>
  internal class FaultHelper
  {
    /// <summary>
    /// Process a general FaultException from Medicare, and rethrow a FaultException<![CDATA[<ServiceMessageType>]]> fault.
    /// </summary>
    /// <typeparam name="T">ServiceMessageType type belonging to any of the SMD namespaces.</typeparam>
    /// <param name="ex">Exception to process</param>
    internal static void ProcessAndThrowFault<T>(Exception ex)
    {
      if (!(ex is FaultException))
        throw ex;

      FaultException fex = (FaultException)ex;
      MessageFault fault = fex.CreateMessageFault();

      if (fault != null && fault.HasDetail)
      {
        XmlElement errorElement = fault.GetDetail<XmlElement>();

        if (errorElement.LocalName == "serviceMessages")
        {
          T serviceMessages = errorElement.Deserialize<T>();
          throw new FaultException<T>(
              serviceMessages,
              fex.Reason,
              fex.Code,
              fex.Action);
        }
      }

      throw ex;
    }
  }
}
