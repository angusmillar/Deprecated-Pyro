using Pyro.Common.Enum;


namespace Pyro.Common.FhirOperation
{
  /// <summary>
  /// Only required for $Operation search parameters
  /// </summary>
  public class OperationClass
  {
    public FhirOperationEnum.OperationScope Scope { get; set; }
    public FhirOperationEnum.OperationType Type { get; set; }
  }
}
