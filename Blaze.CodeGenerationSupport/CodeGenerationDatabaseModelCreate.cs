using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Hl7.Fhir.Model;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;

namespace Blaze.CodeGenerationSupport
{
  public class CodeGenerationDatabaseModelCreate
  {
    #region Private Properties
    private List<string> _ResourceList;
    private List<FhirApiSearchParameterInfo> _SearchParametersList;
    private List<CodeGenerationDbTableModel> _CodeGenerationDbTableModelList;

    private static readonly string ResourcePrefixText = "Res";
    private static readonly string IndexPrefixText = "Index";
    private static readonly string HistoryPrefixText = "History";

    //Set the DB table
    private readonly string CreateTableFormatMask = "public DbSet<{0}> {1} {{ get; set; }}";
    //Set the Configuration class for the table
    private readonly string TableConfigurationsFormatMask = "Mb.Configurations.Add(new {0}_Configuration());";

    #endregion

    #region Public Properties
    
    public List<CodeGenerationDbTableModel>  CodeGenerationDbTableModelList
    {
      get { return _CodeGenerationDbTableModelList; }      
    }    

    #endregion

    #region Constructor

    public CodeGenerationDatabaseModelCreate()
    {
      _ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      _SearchParametersList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();
      _CodeGenerationDbTableModelList = new List<CodeGenerationDbTableModel>();
      GenerateResourceCofdeGenerationItems();
    }

    #endregion

    #region Private Methods

    private void GenerateResourceCofdeGenerationItems()
    {

      //Url Store Table
      string UrlStoreTableClassName = "Aux_RootUrlStore";
      var CodeGenerationDbTableUrlStore = new CodeGenerationDbTableModel();
      CodeGenerationDbTableUrlStore.TableName = UrlStoreTableClassName;
      CodeGenerationDbTableUrlStore.TableCreateSyntax = GererateTableCreateSyntax(UrlStoreTableClassName, UrlStoreTableClassName);
      CodeGenerationDbTableUrlStore.TableConfiguratonSyntax = GererateTableConfigurationSyntax(UrlStoreTableClassName);

      CodeGenerationDbTableUrlStore.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
      CodeGenerationDbTableUrlStore.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(UrlStoreTableClassName);
      CodeGenerationDbTableUrlStore.TableConfigurationClassModel.FluentPropertyConfigurationList.Add(String.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", UrlStoreTableClassName));
      CodeGenerationDbTableUrlStore.TableConfigurationClassModel.FluentPropertyConfigurationList.Add("HasKey(x => x.RootUrl).Property(x => x.RootUrl).IsRequired().HasMaxLength(2083).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(\"IX_RootUrl\") { IsUnique = true }));");
      CodeGenerationDbTableUrlStore.TableConfigurationClassModel.FluentPropertyConfigurationList.Add("HasKey(x => x.IsServersPrimaryUrlRoot).Property(x => x.IsServersPrimaryUrlRoot).IsRequired();");

      CodeGenerationDbTableUrlStore.TableClassModel = new CodeGenerationDbTableClassModel();
      CodeGenerationDbTableUrlStore.TableClassModel.ClassName = UrlStoreTableClassName;
      CodeGenerationDbTableUrlStore.TableClassModel.PropertyList.Add(String.Format("public int {0}ID {{get; set;}}", UrlStoreTableClassName));
      CodeGenerationDbTableUrlStore.TableClassModel.PropertyList.Add("public string RootUrl {get; set;}");
      CodeGenerationDbTableUrlStore.TableClassModel.PropertyList.Add("public bool IsServersPrimaryUrlRoot {get; set;}");

      _CodeGenerationDbTableModelList.Add(CodeGenerationDbTableUrlStore);

      foreach (var ResourceName in _ResourceList)
      {

        List<FhirApiSearchParameterInfo> SearchParametersForResource = (from x in _SearchParametersList
                                                                        where x.Resource == ResourceName
                                                                        select x).ToList();

        List<FhirApiSearchParameterInfo> CollectionParameters = (from x in SearchParametersForResource
                                                                 where x.IsCollection == true
                                                                 select x).ToList();

        List<FhirApiSearchParameterInfo> NonCollectionParameters = (from x in SearchParametersForResource
                                                                    where x.IsCollection == false
                                                                    select x).ToList();

        CollectionParameters = FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(CollectionParameters);
        NonCollectionParameters = FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(NonCollectionParameters);

        //The Resource main Table
        string ClassNameResource = ConstructClassNameForResourceClass(ResourceName);
        var CodeGenerationDbTableModelResourceMain = new CodeGenerationDbTableModel();
        CodeGenerationDbTableModelResourceMain.TableName = ClassNameResource;
        CodeGenerationDbTableModelResourceMain.TableCreateSyntax = GererateTableCreateSyntax(ClassNameResource, ClassNameResource);
        CodeGenerationDbTableModelResourceMain.TableConfiguratonSyntax = GererateTableConfigurationSyntax(ClassNameResource);
        
        CodeGenerationDbTableModelResourceMain.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
        CodeGenerationDbTableModelResourceMain.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(ClassNameResource);
        GenerateConfigurationFluentStatmentsForMainResource(CodeGenerationDbTableModelResourceMain.TableConfigurationClassModel.FluentPropertyConfigurationList, ClassNameResource, NonCollectionParameters);
        
        CodeGenerationDbTableModelResourceMain.TableClassModel = new CodeGenerationDbTableClassModel();
        CodeGenerationDbTableModelResourceMain.TableClassModel.ClassName = ClassNameResource;
        GenerateTableClassModelPropertiesForResource(CodeGenerationDbTableModelResourceMain.TableClassModel.PropertyList, NonCollectionParameters, CollectionParameters, ResourceName, false);
        GenerateTableClassModelPropertyConstructorInstantiationForMainResource(CodeGenerationDbTableModelResourceMain.TableClassModel.PropertyConstructorInstantiationList, NonCollectionParameters, CollectionParameters, ResourceName);
        
        _CodeGenerationDbTableModelList.Add(CodeGenerationDbTableModelResourceMain);

        //The Resource History Table
        string ClassNameResourceHistory = ConstructClassNameForResourceHistory(ResourceName);
        var CodeGenerationDbTableModelResourceHistroy = new CodeGenerationDbTableModel();
        CodeGenerationDbTableModelResourceHistroy.TableName = ClassNameResourceHistory;
        CodeGenerationDbTableModelResourceHistroy.TableCreateSyntax = GererateTableCreateSyntax(ClassNameResourceHistory, ClassNameResourceHistory);
        CodeGenerationDbTableModelResourceHistroy.TableConfiguratonSyntax = GererateTableConfigurationSyntax(ClassNameResourceHistory);
        
        CodeGenerationDbTableModelResourceHistroy.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
        CodeGenerationDbTableModelResourceHistroy.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(ClassNameResourceHistory);
        GenerateConfigurationFluentStatmentsForHistroyResource(CodeGenerationDbTableModelResourceHistroy.TableConfigurationClassModel.FluentPropertyConfigurationList, CollectionParameters, ClassNameResource);       

        CodeGenerationDbTableModelResourceHistroy.TableClassModel = new CodeGenerationDbTableClassModel();
        CodeGenerationDbTableModelResourceHistroy.TableClassModel.ClassName = ClassNameResourceHistory;
        GenerateTableClassModelPropertiesForResource(CodeGenerationDbTableModelResourceHistroy.TableClassModel.PropertyList, NonCollectionParameters, CollectionParameters, ResourceName, true);
        
        _CodeGenerationDbTableModelList.Add(CodeGenerationDbTableModelResourceHistroy);


        //The Resource Search Index tables
        foreach (FhirApiSearchParameterInfo CollectionItem in CollectionParameters)
        {
          string ClassNameSearchIndex = ConstructClassNameForResourceSearchClass(ResourceName, CollectionItem);
          var CodeGenerationDbTableModelResourceSearchIndex = new CodeGenerationDbTableModel();
          CodeGenerationDbTableModelResourceSearchIndex.TableName = ClassNameSearchIndex;
          CodeGenerationDbTableModelResourceSearchIndex.TableCreateSyntax = GererateTableCreateSyntax(ClassNameSearchIndex, ClassNameSearchIndex);
          CodeGenerationDbTableModelResourceSearchIndex.TableConfiguratonSyntax = GererateTableConfigurationSyntax(ClassNameSearchIndex);
        
          CodeGenerationDbTableModelResourceSearchIndex.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
          CodeGenerationDbTableModelResourceSearchIndex.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(ClassNameSearchIndex);
          GenerateConfigurationFluentStatmentsForResourceSearchIndex(CodeGenerationDbTableModelResourceSearchIndex.TableConfigurationClassModel.FluentPropertyConfigurationList, CollectionItem, ClassNameResource, ClassNameSearchIndex);

          CodeGenerationDbTableModelResourceSearchIndex.TableClassModel = new CodeGenerationDbTableClassModel();
          CodeGenerationDbTableModelResourceSearchIndex.TableClassModel.ClassName = ClassNameSearchIndex;
          GenerateTableClassModelPropertiesForResourceSearchIndex(CodeGenerationDbTableModelResourceSearchIndex.TableClassModel.PropertyList, ClassNameResource, ClassNameSearchIndex, CollectionItem);
         

          _CodeGenerationDbTableModelList.Add(CodeGenerationDbTableModelResourceSearchIndex);
        }
      }
    }

    /// <summary>
    /// Generates the Fluent configuration statements for the Main Resource 
    /// </summary>
    /// <param name="FluentPathList"></param>
    /// <param name="NonCollectionParameters"></param>
    private void GenerateConfigurationFluentStatmentsForMainResource(List<string> FluentPathList, string TableClassName, List<FhirApiSearchParameterInfo> NonCollectionParameters)
    {
      FluentPathList.Add(String.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", TableClassName));
      FluentPathList.Add("Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(\"IX_FhirId\") { IsUnique = true }));");
      FluentPathList.Add("Property(x => x.Received).IsRequired();");
      FluentPathList.Add("Property(x => x.Version).IsRequired();");
      FluentPathList.Add("Property(x => x.XmlBlob).IsRequired();");
      foreach (var NonCollectionItem in NonCollectionParameters)
      {
        string FormatedPrefix = NonCollectionItem.SearchName.Replace('-', '_') + '_';
        GenerateClassPropertyFluentStatmentForSearchParameterDataType(FormatedPrefix, NonCollectionItem.SearchParamType, false, FluentPathList);
      }
    }

    /// <summary>
    /// Generates the Fluent configuration statements for the Main Resource 
    /// </summary>
    /// <param name="FluentPathList"></param>
    /// <param name="CollectionParameters"></param>
    /// <param name="ClassNameResource"></param>
    private void GenerateConfigurationFluentStatmentsForHistroyResource(List<string> FluentPathList, List<FhirApiSearchParameterInfo> CollectionParameters, string ClassNameResource)
    {
      FluentPathList.Add(String.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", ClassNameResource));
      FluentPathList.Add("Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(\"IX_FhirId\") { IsUnique = false })); ;");      
      FluentPathList.Add("Property(x => x.Received).IsRequired();");
      FluentPathList.Add("Property(x => x.Version).IsRequired();");
      FluentPathList.Add("Property(x => x.XmlBlob).IsRequired();");
      FluentPathList.Add(String.Format("HasRequired(x => x.{0});", ClassNameResource));
    }

    private void GenerateConfigurationFluentStatmentsForResourceSearchIndex(List<string> FluentPathList, FhirApiSearchParameterInfo CollectionItem, string ClassNameResource, string ClassNameSearchIndex)
    {
      FluentPathList.Add(String.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", ClassNameSearchIndex));      
      if (CollectionItem.SearchParamType == Hl7.Fhir.Model.SearchParamType.Composite)
      {
        foreach (var Composite in CollectionItem.CompositeSearchParameterList)
        {
          GenerateClassPropertyFluentStatmentForSearchParameterDataType(Composite.SearchName.Replace("-", "_"), Composite.SearchParamType, true, FluentPathList);
        }
      }
      else
      {
        GenerateClassPropertyFluentStatmentForSearchParameterDataType(string.Empty, CollectionItem.SearchParamType, true, FluentPathList);
      }
      FluentPathList.Add(String.Format("HasRequired(x => x.{0});", ClassNameResource));
    }

    private string GererateTableCreateSyntax(string ClassType, string ClassTableName)
    {      
      return String.Format(CreateTableFormatMask, ClassType, ClassTableName);
    }

    private string GererateTableConfigurationSyntax(string ClassTableName)
    {
      return String.Format(TableConfigurationsFormatMask, ClassTableName);
    }

    /// <summary>
    /// Construct the class name string for the Resource classes
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceClass(string ResourceName)
    {
      return String.Format("{0}_{1}", ResourcePrefixText, ResourceName);
    }

    /// <summary>
    /// Construct the class name string for the Resource Search Classes
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceSearchClass(string ResourceName, FhirApiSearchParameterInfo SearchParameterInfo)
    {
      if (SearchParameterInfo.SearchParamType == SearchParamType.Composite)
        return String.Format("{0}_{1}_{2}_{3}", ResourcePrefixText, ResourceName, IndexPrefixText, SearchParameterInfo.SearchName.Replace('-', '_').Replace("_[x]", ""));
      else
        return String.Format("{0}_{1}_{2}_{3}", ResourcePrefixText, ResourceName, IndexPrefixText, SearchParameterInfo.SearchName.Replace('-', '_'));
    }

    /// <summary>
    /// Construct the property name string for the Collection lists of the Resource classes
    /// </summary>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructCollectionListName(FhirApiSearchParameterInfo oFhirApiSearchParameterInfo)
    {
      if (oFhirApiSearchParameterInfo.SearchParamType == SearchParamType.Composite)
        return oFhirApiSearchParameterInfo.SearchName.Replace('-', '_').Replace("_[x]", "") + "_List";
      else
        return oFhirApiSearchParameterInfo.SearchName.Replace('-', '_') + "_List";
    }

    /// <summary>
    /// Construct the class name string for the Resource History
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceHistory(string ResourceName)
    {
      return String.Format("{0}_{1}_{2}", ResourcePrefixText, ResourceName, HistoryPrefixText);
    }

    /// <summary>
    /// Construct the class name string for the Resource History
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForConfigurationClass(string ClassResourceName)
    {
      return String.Format("{0}_Configuration", ClassResourceName);
    }

    private void GenerateClassPropertyFluentStatmentForSearchParameterDataType(string Prefix, Hl7.Fhir.Model.SearchParamType DataType, bool IsIndex, List<string> FluentPathList)
    {
      switch (DataType)
      {
        case Hl7.Fhir.Model.SearchParamType.Composite:
          {
            //Nothing to do for this type as composite type is a composite of the other types
            //We should never get here
            throw new ApplicationException("Attempt to create database fields for composite type search parameter. This should not happen.");
          }
        //break;
        case Hl7.Fhir.Model.SearchParamType.Date:
          {
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffset).IsRequired();", Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffset).IsOptional();", Prefix));
            }
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Number:
          {
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Number).IsRequired();", Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Number).IsOptional();", Prefix));
            }
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Quantity:
          {
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Quantity).IsRequired();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}System).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}Code).IsOptional();", Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Quantity).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}System).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}Code).IsOptional();", Prefix));
            }
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Reference:
          {
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}FhirId).IsRequired();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}Type).IsRequired();", Prefix));              
              FluentPathList.Add(String.Format("HasRequired(x => x.{0}Aux_RootUrlStoreID);", Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}FhirId).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}Type).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("HasOptional(x => x.{0}Aux_RootUrlStoreID);", Prefix));
            }
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.String:
          {
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}String).IsRequired();", Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}String).IsOptional();", Prefix));
            }
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Token:
          {
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Code).IsRequired();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}System).IsOptional();", Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Code).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}System).IsOptional();", Prefix));
            }
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Uri:
          {
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Uri).IsRequired();", Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Uri).IsOptional();", Prefix));
            }
          }
          break;
        default:
          throw new InvalidEnumArgumentException(DataType.ToString(), (int)DataType, typeof(Hl7.Fhir.Model.SearchParamType));
      }
    }

    private void GenerateTableClassModelPropertiesForResource(List<string> Propertylist, List<FhirApiSearchParameterInfo> NonCollectionParameters, List<FhirApiSearchParameterInfo> CollectionParameters, string ResourceName, bool IsHistoryTable)
    {
      string MainResourceClassName = ConstructClassNameForResourceClass(ResourceName);

      Propertylist.Add(String.Format("public int {0}ID {{get; set;}}", MainResourceClassName));
      Propertylist.Add("public string FhirId {get; set;}");
      Propertylist.Add("public int Version {get; set;}");  
      Propertylist.Add("public DateTimeOffset Received {get; set;}");
      Propertylist.Add("public string XmlBlob {get; set;}");
      if (IsHistoryTable)
      {
        
        Propertylist.Add(String.Format("public virtual {0} {0} {{ get; set; }}", MainResourceClassName));        
      }
      else
      {
        foreach (var NonCollectionItem in NonCollectionParameters)
        {
          string FormatedPrefix = NonCollectionItem.SearchName.Replace('-', '_') + '_';
          GenerateClassPropertiesForSearchParameterDataType(Propertylist, FormatedPrefix, NonCollectionItem.SearchParamType, false);
        }
        foreach (FhirApiSearchParameterInfo CollectionItem in CollectionParameters)
        {
          string ClassNameResourceSearch = ConstructClassNameForResourceSearchClass(ResourceName, CollectionItem);
          string CollectionListName = ConstructCollectionListName(CollectionItem);
          Propertylist.Add(String.Format("public ICollection<{0}> {1} {{ get; set; }}", ClassNameResourceSearch, CollectionListName));
        }        
      }
    }

    private void GenerateTableClassModelPropertiesForResourceSearchIndex(List<string> Propertylist, string MainResourceClassName, string ClassNameSearchIndex, FhirApiSearchParameterInfo CollectionItem)
    {
      Propertylist.Add(String.Format("public int {0}ID {{get; set;}}", ClassNameSearchIndex));

      if (CollectionItem.SearchParamType == Hl7.Fhir.Model.SearchParamType.Composite)
      {
        foreach (var Composite in CollectionItem.CompositeSearchParameterList)
        {
          string Prefix = Composite.SearchName.Replace("-", "_");
          GenerateClassPropertiesForSearchParameterDataType(Propertylist, Prefix, Composite.SearchParamType, true);
        }
      }
      else
      {
        GenerateClassPropertiesForSearchParameterDataType(Propertylist, string.Empty, CollectionItem.SearchParamType, true);
      }
      Propertylist.Add(String.Format("public virtual {0} {0} {{ get; set; }}", MainResourceClassName));
    }

    private void GenerateTableClassModelPropertyConstructorInstantiationForMainResource(List<string> Propertylist, List<FhirApiSearchParameterInfo> NonCollectionParameters, List<FhirApiSearchParameterInfo> CollectionParameters, string ResourceName)
    { 
      foreach( var CollectionItem in CollectionParameters)
      {
        string CollectionListName = ConstructCollectionListName(CollectionItem);
        string ClassNameResourceSearch = ConstructClassNameForResourceSearchClass(ResourceName, CollectionItem);            
        Propertylist.Add(String.Format("this.{0} = new HashSet<{1}>();", CollectionListName, ClassNameResourceSearch));            
      }
    }

    private void GenerateClassPropertiesForSearchParameterDataType(List<string> Propertylist, string Prefix, Hl7.Fhir.Model.SearchParamType DataType, bool IsIndex)
    {

      switch (DataType)
           {
             case Hl7.Fhir.Model.SearchParamType.Composite:
               {
                  //Nothing to do for this type as composite type is a composite of the other types
                  //We should never get here
                  throw new ApplicationException("Attempt to create database fields for composite type search parameter. This should not happen.");                
               }
               //break;
             case Hl7.Fhir.Model.SearchParamType.Date:
               {
                 if (IsIndex)
                 {
                   Propertylist.Add(String.Format("public DateTimeOffset {0}DateTimeOffset {{get; set;}}", Prefix));
                 }
                 else
                 {
                   Propertylist.Add(String.Format("public DateTimeOffset? {0}DateTimeOffset {{get; set;}}", Prefix));
                 }             
               }
               break;
             case Hl7.Fhir.Model.SearchParamType.Number:
               {
                 if (IsIndex)
                 {
                   Propertylist.Add(String.Format("public decimal {0}Number {{get; set;}}", Prefix));
                 }
                 else
                 {
                   Propertylist.Add(String.Format("public decimal? {0}Number {{get; set;}}", Prefix));
                 } 
               }
               break;
             case Hl7.Fhir.Model.SearchParamType.Quantity:
               {
                 if (IsIndex)
                 {
                   Propertylist.Add(String.Format("public decimal {0}Quantity {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}System {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}Code {{get; set;}}", Prefix));    
                 }
                 else
                 {
                   Propertylist.Add(String.Format("public decimal? {0}Quantity {{get; set;}}", Prefix));    
                   Propertylist.Add(String.Format("public string {0}System {{get; set;}}", Prefix));    
                   Propertylist.Add(String.Format("public string {0}Code {{get; set;}}", Prefix));    
                 }
               }
               break;
             case Hl7.Fhir.Model.SearchParamType.Reference:
               {
                 Propertylist.Add(String.Format("public string {0}FhirId {{get; set;}}", Prefix));    
                 Propertylist.Add(String.Format("public string {0}Type {{get; set;}}", Prefix));
                 //Propertylist.Add(String.Format("public int {0}Aux_RootUrlStoreID {{get; set;}}", Prefix));
                 Propertylist.Add(String.Format("public virtual Aux_RootUrlStore {0}Aux_RootUrlStoreID {{ get; set; }}", Prefix));        
               }
               break;
             case Hl7.Fhir.Model.SearchParamType.String:
               {
                 Propertylist.Add(String.Format("public string {0}String {{get; set;}}", Prefix));
               }
               break;
             case Hl7.Fhir.Model.SearchParamType.Token:
               {
                 Propertylist.Add(String.Format("public string {0}Code {{get; set;}}", Prefix));
                 Propertylist.Add(String.Format("public string {0}System {{get; set;}}", Prefix));
               }
               break;
             case Hl7.Fhir.Model.SearchParamType.Uri:
               {
                 Propertylist.Add(String.Format("public string {0}Uri {{get; set;}}", Prefix)); 
               }
               break;
             default:
               throw new InvalidEnumArgumentException(DataType.ToString(), (int)DataType, typeof(Hl7.Fhir.Model.SearchParamType));
           }
    }

    #endregion
  }
}
