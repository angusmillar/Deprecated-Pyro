using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    ResourceBase,
    IModelBase,
    IResourceBase,
    IResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    
  {

    public ResourceCurrentBase()
    {
      this.IndexStringList = new HashSet<ResIndexStringType>();
      this.IndexTokenList = new HashSet<ResIndexTokenType>();
      this.IndexUriList = new HashSet<ResIndexUriType>();
      this.IndexReferenceList = new HashSet<ResIndexReferenceType>();
      this.IndexQuantityList = new HashSet<ResIndexQuantityType>();
      this.IndexDateTimeList = new HashSet<ResIndexDateTimeType>();
    }
    
    public ICollection<ResIndexStringType> IndexStringList { get; set; }
    public ICollection<ResIndexTokenType> IndexTokenList { get; set; }
    public ICollection<ResIndexUriType> IndexUriList { get; set; }
    public ICollection<ResIndexReferenceType> IndexReferenceList { get; set; }
    public ICollection<ResIndexQuantityType> IndexQuantityList { get; set; }
    public ICollection<ResIndexDateTimeType> IndexDateTimeList { get; set; }
  }
}
