namespace Pyro.Common.Compartment
{
  public class DtoServiceCompartmentResource
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Param { get; set; }
    public virtual DtoServiceCompartment ServiceCompartment { get; set; }
    public int _ServiceCompartmentId { get; set; }
  }
}
