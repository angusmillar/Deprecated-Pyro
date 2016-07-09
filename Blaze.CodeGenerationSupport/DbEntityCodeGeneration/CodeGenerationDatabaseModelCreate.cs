using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Hl7.Fhir.Model;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;

namespace Blaze.CodeGenerationSupport.DbEntityCodeGeneration
{
  public class CodeGenerationDatabaseModelCreate
  {
    #region Private Properties
    private List<string> _ResourceList;
    private List<FhirApiSearchParameterInfo> _SearchParametersList;
    private List<CodeGenerationDbTableModel> _CodeGenerationDbTableModelList;
    
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
      GenerateResourceCodeGenerationItems();
    }

    #endregion

    #region Private Methods

    private void GenerateResourceCodeGenerationItems()
    {

      //Url Store Table      
      _CodeGenerationDbTableModelList.Add(Create_Blaze_RootUrlStore_Table());

      foreach (var ResourceName in _ResourceList)
      {
        if (ResourceName == "Specimen")
        {

        }
        List<FhirApiSearchParameterInfo> SearchParametersForResource = (from x in _SearchParametersList
                                                                        where x.Resource == ResourceName
                                                                        select x).ToList();

        List<FhirApiSearchParameterInfo> CollectionParameters = (from x in SearchParametersForResource
                                                                 where x.IsCollection == true
                                                                 select x).ToList();

        List<FhirApiSearchParameterInfo> NonCollectionParameters = (from x in SearchParametersForResource
                                                                    where x.IsCollection == false
                                                                    select x).ToList();

        //CollectionParameters = FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(CollectionParameters, true);
        //NonCollectionParameters = FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(NonCollectionParameters, true);

        //The Resource main Table
        _CodeGenerationDbTableModelList.Add(CreateModelResourceMainTable(ResourceName, CollectionParameters, NonCollectionParameters));

        //The Resource History Table
        _CodeGenerationDbTableModelList.Add(CreateModelResourceHistoryTable(ResourceName, CollectionParameters, NonCollectionParameters));        

        //The Resource Search Index tables
        foreach (FhirApiSearchParameterInfo CollectionItem in CollectionParameters)
        {
          _CodeGenerationDbTableModelList.Add(Create_ModelResourceSearchIndexTable(ResourceName, CollectionItem));
        }
      }
    }

    private CodeGenerationDbTableModel Create_ModelResourceSearchIndexTable(string ResourceName, FhirApiSearchParameterInfo CollectionItem)
    {
      string ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      //Below used for Debug
      if (CollectionItem.SearchName == "collected")
      {
        ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      }
      //string ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);

      string ClassNameSearchIndex = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(ResourceName, CollectionItem);
      var TableModel = new CodeGenerationDbTableModel();
      TableModel.TableName = ClassNameSearchIndex;
      TableModel.TableCreateSyntax = GererateTableCreateSyntax(ClassNameSearchIndex, ClassNameSearchIndex);
      TableModel.TableConfiguratonSyntax = GererateTableConfigurationSyntax(ClassNameSearchIndex);

      TableModel.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
      TableModel.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(ClassNameSearchIndex);
      GenerateConfigurationFluentStatmentsForResourceSearchIndex(TableModel.TableConfigurationClassModel.FluentPropertyConfigurationList, CollectionItem, ClassNameResource, ClassNameSearchIndex);

      TableModel.TableClassModel = new CodeGenerationDbTableClassModel(false);
      TableModel.TableClassModel.ClassName = ClassNameSearchIndex;      
      GenerateClassInheritancesByFhirSearchParameterType(TableModel.TableClassModel.ClassInheritanceList, CollectionItem);
      GenerateTableClassModelPropertiesForResourceSearchIndex(TableModel.TableClassModel.PropertyList, ClassNameResource, ClassNameSearchIndex, CollectionItem);
      return TableModel;
    }

    private CodeGenerationDbTableModel CreateModelResourceHistoryTable(string ResourceName, List<FhirApiSearchParameterInfo> CollectionParameters, List<FhirApiSearchParameterInfo> NonCollectionParameters)
    {
      string ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      string ClassNameResourceHistory = DatabaseModelInfo.ConstructClassNameForResourceHistory(ResourceName);
      var TableModel = new CodeGenerationDbTableModel();
      TableModel.TableName = ClassNameResourceHistory;
      TableModel.TableCreateSyntax = GererateTableCreateSyntax(ClassNameResourceHistory, ClassNameResourceHistory);
      TableModel.TableConfiguratonSyntax = GererateTableConfigurationSyntax(ClassNameResourceHistory);

      TableModel.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
      TableModel.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(ClassNameResourceHistory);
      GenerateConfigurationFluentStatmentsForHistroyResource(TableModel.TableConfigurationClassModel.FluentPropertyConfigurationList, CollectionParameters, ResourceName);

      TableModel.TableClassModel = new CodeGenerationDbTableClassModel();
      TableModel.TableClassModel.ClassName = ClassNameResourceHistory;
      TableModel.TableClassModel.ClassInheritanceList.Clear();
      TableModel.TableClassModel.ClassInheritanceList.Add(DatabaseModelInfo.DatabaseModelResourceIndexBaseClassName);
      GenerateTableClassModelPropertiesForResource(TableModel.TableClassModel.PropertyList, NonCollectionParameters, CollectionParameters, ResourceName, true);
      return TableModel;
    }

    private CodeGenerationDbTableModel CreateModelResourceMainTable(string ResourceName, List<FhirApiSearchParameterInfo> CollectionParameters, List<FhirApiSearchParameterInfo> NonCollectionParameters)
    {
      string ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      var TableModel = new CodeGenerationDbTableModel();
      TableModel.TableName = ClassNameResource;
      TableModel.TableCreateSyntax = GererateTableCreateSyntax(ClassNameResource, ClassNameResource);
      TableModel.TableConfiguratonSyntax = GererateTableConfigurationSyntax(ClassNameResource);

      TableModel.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
      TableModel.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(ClassNameResource);      
      GenerateConfigurationFluentStatmentsForMainResource(TableModel.TableConfigurationClassModel.FluentPropertyConfigurationList, ClassNameResource, NonCollectionParameters);

      TableModel.TableClassModel = new CodeGenerationDbTableClassModel();
      TableModel.TableClassModel.ClassName = ClassNameResource;
      TableModel.TableClassModel.ClassInheritanceList.Clear();
      TableModel.TableClassModel.ClassInheritanceList.Add(DatabaseModelInfo.DatabaseModelResourceIndexBaseClassName);
      GenerateTableClassModelPropertiesForResource(TableModel.TableClassModel.PropertyList, NonCollectionParameters, CollectionParameters, ResourceName, false);
      GenerateTableClassModelPropertyConstructorInstantiationForMainResource(TableModel.TableClassModel.PropertyConstructorInstantiationList, NonCollectionParameters, CollectionParameters, ResourceName);

      //History
      string ClassNameResourceHistory = DatabaseModelInfo.ConstructClassNameForResourceHistory(ResourceName);      
      TableModel.TableClassModel.PropertyConstructorInstantiationList.Add(String.Format("this.{0}_List = new HashSet<{1}>();", ClassNameResourceHistory, ClassNameResourceHistory));
      
      return TableModel;
    }

    
    /// <summary>
    /// Create the table that holds all URL's for the resource references
    /// </summary>
    /// <returns></returns>
    private CodeGenerationDbTableModel Create_Blaze_RootUrlStore_Table()
    {
      string UrlStoreTableClassName = String.Format("{0}_RootUrlStore", DatabaseModelInfo.ApplicationName);
      var TableModel = new CodeGenerationDbTableModel();
      TableModel.TableName = UrlStoreTableClassName;
      TableModel.TableCreateSyntax = GererateTableCreateSyntax(UrlStoreTableClassName, UrlStoreTableClassName);
      TableModel.TableConfiguratonSyntax = GererateTableConfigurationSyntax(UrlStoreTableClassName);

      TableModel.TableConfigurationClassModel = new CodeGenerationDbTableConfigurationClassModel();
      TableModel.TableConfigurationClassModel.ClassName = ConstructClassNameForConfigurationClass(UrlStoreTableClassName);
      TableModel.TableConfigurationClassModel.FluentPropertyConfigurationList.Add(String.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", UrlStoreTableClassName));
      TableModel.TableConfigurationClassModel.FluentPropertyConfigurationList.Add("Property(x => x.RootUrl).IsRequired().HasMaxLength(2083).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(\"IX_RootUrl\") { IsUnique = true }));");      
      TableModel.TableConfigurationClassModel.FluentPropertyConfigurationList.Add("Property(x => x.IsServersPrimaryUrlRoot).IsRequired();");

      TableModel.TableClassModel = new CodeGenerationDbTableClassModel();
      TableModel.TableClassModel.ClassName = UrlStoreTableClassName;
      TableModel.TableClassModel.PropertyList.Add(String.Format("public int {0}ID {{get; set;}}", UrlStoreTableClassName));
      TableModel.TableClassModel.PropertyList.Add("public string RootUrl {get; set;}");
      TableModel.TableClassModel.PropertyList.Add("public bool IsServersPrimaryUrlRoot {get; set;}");
      return TableModel;
    }


    private void GenerateClassInheritancesByFhirSearchParameterType(List<string> list, FhirApiSearchParameterInfo FhirApiSearchParameterInfo)
    {
      switch (FhirApiSearchParameterInfo.SearchParamType)
      {
        case SearchParamType.Date:
          {
            if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(FhirDateTime))
              list.Add("DateIndex");
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Date))
              list.Add("DateIndex");
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Timing))
              list.Add("DatePeriodIndex");
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Period))
              list.Add("DatePeriodIndex");            
            else
              throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", FhirApiSearchParameterInfo.SearchParamType.ToString(), FhirApiSearchParameterInfo.TargetFhirType.ToString()));
            break;
          }                          
        case SearchParamType.Number:
          list.Add("NumberIndex");
          break;
        case SearchParamType.Quantity:
          {
            if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Quantity))
              list.Add("QuantityIndex");
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(SimpleQuantity))
              list.Add("QuantityIndex");
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Range))
              list.Add("QuantityRangeIndex");
            else
              throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", FhirApiSearchParameterInfo.SearchParamType.ToString(), FhirApiSearchParameterInfo.TargetFhirType.ToString()));
            break;
          }          
        case SearchParamType.Reference:
          list.Add("ReferenceIndex");
          break;
        case SearchParamType.String:
          list.Add("StringIndex");
          break;
        case SearchParamType.Token:
          list.Add("TokenIndex");
          break;
        case SearchParamType.Uri:
          list.Add("UriIndex");
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(FhirApiSearchParameterInfo.SearchParamType.ToString(), (int)FhirApiSearchParameterInfo.SearchParamType, typeof(SearchParamType));
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
      FluentPathList.Add("Property(x => x.IsDeleted).IsRequired();");
      FluentPathList.Add("Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(\"IX_FhirId\") { IsUnique = true }));");
      FluentPathList.Add("Property(x => x.lastUpdated).IsRequired();");
      FluentPathList.Add("Property(x => x.versionId).IsRequired();");
      FluentPathList.Add("Property(x => x.XmlBlob).IsRequired();");
      foreach (var NonCollectionItem in NonCollectionParameters)
      {
        string FormatedPrefix = DatabaseModelInfo.ContructSearchParameterName(NonCollectionItem.SearchName) + '_';
        GenerateClassPropertyFluentStatmentForSearchParameterDataType(FormatedPrefix, NonCollectionItem, false, FluentPathList);
      }
    }

    /// <summary>
    /// Generates the Fluent configuration statements for the Main Resource 
    /// </summary>
    /// <param name="FluentPathList"></param>
    /// <param name="CollectionParameters"></param>
    /// <param name="ClassNameResource"></param>
    private void GenerateConfigurationFluentStatmentsForHistroyResource(List<string> FluentPathList, List<FhirApiSearchParameterInfo> CollectionParameters, string ResourceName)
    {
      string ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      string ClassNameResourceHistory = DatabaseModelInfo.ConstructClassNameForResourceHistory(ResourceName);

      FluentPathList.Add(String.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", ClassNameResourceHistory));
      FluentPathList.Add("Property(x => x.IsDeleted).IsRequired();"); 
      FluentPathList.Add("Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(\"IX_FhirId\") { IsUnique = false })); ;");
      FluentPathList.Add("Property(x => x.lastUpdated).IsRequired();");
      FluentPathList.Add("Property(x => x.versionId).IsRequired();");
      FluentPathList.Add("Property(x => x.XmlBlob).IsRequired();");
      FluentPathList.Add(String.Format("HasRequired(x => x.{0}).WithMany(x => x.{1}_List).WillCascadeOnDelete(false);", ClassNameResource, ClassNameResourceHistory));
    }

    private void GenerateConfigurationFluentStatmentsForResourceSearchIndex(List<string> FluentPathList, FhirApiSearchParameterInfo CollectionItem, string ClassNameResource, string ClassNameSearchIndex)
    {
      FluentPathList.Add(String.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", ClassNameSearchIndex));      
      if (CollectionItem.SearchParamType == Hl7.Fhir.Model.SearchParamType.Composite)
      {
        foreach (var Composite in CollectionItem.CompositeSearchParameterList)
        {
          GenerateClassPropertyFluentStatmentForSearchParameterDataType(DatabaseModelInfo.ContructSearchParameterName(Composite.SearchName), Composite, true, FluentPathList);
        }
      }
      else
      {
        GenerateClassPropertyFluentStatmentForSearchParameterDataType(string.Empty, CollectionItem, true, FluentPathList);
      }
      string CollectionListName = DatabaseModelInfo.ConstructCollectionListName(CollectionItem);
      FluentPathList.Add(String.Format("HasRequired(x => x.{0}).WithMany(x => x.{1}).WillCascadeOnDelete(true);", ClassNameResource, CollectionListName));
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
    /// Construct the class name string for the Resource History
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForConfigurationClass(string ClassResourceName)
    {
      return String.Format("{0}_Configuration", ClassResourceName);
    }

    private void GenerateClassPropertyFluentStatmentForSearchParameterDataType(string Prefix, FhirApiSearchParameterInfo FhirApiSearchParameterInfo, bool IsIndex, List<string> FluentPathList)
    {
      string IsOptional = "IsOptional()";
      string IsRequired = "IsRequired()";
      string RequiredOrOptional = IsOptional;
      if (IsIndex)
        RequiredOrOptional = IsRequired;

      switch (FhirApiSearchParameterInfo.SearchParamType)
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
            if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(FhirDateTime) ||
              FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Instant))
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffset).{1};", Prefix, RequiredOrOptional));
            }
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Date))
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffset).{1};", Prefix, RequiredOrOptional));
            }
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Timing))
            {              
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffsetLow).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffsetHigh).{1};", Prefix, IsOptional));
            }
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Period))
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffsetLow).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}DateTimeOffsetHigh).{1};", Prefix, IsOptional));
            }
            else
              throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", FhirApiSearchParameterInfo.SearchParamType.ToString(), FhirApiSearchParameterInfo.TargetFhirType.ToString()));
            break;            
          }          
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
            if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Quantity) ||
                FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Money))
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Comparator).{1};", Prefix, RequiredOrOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}Quantity).{1};", Prefix, RequiredOrOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}System).{1};", Prefix, RequiredOrOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}Code).{1};", Prefix, RequiredOrOptional));
            }
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(SimpleQuantity))
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}Comparator).{1};", Prefix, RequiredOrOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}Quantity).{1};", Prefix, RequiredOrOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}System).{1};", Prefix, RequiredOrOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}Code).{1};", Prefix, RequiredOrOptional));
            }
            else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Range))
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}ComparatorLow).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}QuantityLow).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}SystemLow).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}CodeLow).{1};", Prefix, IsOptional));

              FluentPathList.Add(String.Format("Property(x => x.{0}ComparatorHigh).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}QuantityHigh).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}SystemHigh).{1};", Prefix, IsOptional));
              FluentPathList.Add(String.Format("Property(x => x.{0}CodeHigh).{1};", Prefix, IsOptional));
            }
            else
              throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", FhirApiSearchParameterInfo.SearchParamType.ToString(), FhirApiSearchParameterInfo.TargetFhirType.ToString()));
            break;
          }          
        case Hl7.Fhir.Model.SearchParamType.Reference:
          {
            string RootUrlStoreTableClassName = String.Format("{0}_RootUrlStore", DatabaseModelInfo.ApplicationName);
            if (IsIndex)
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}VersionId).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}FhirId).IsRequired();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}Type).IsRequired();", Prefix));              
              FluentPathList.Add(String.Format("HasRequired(x => x.{0}Url);", Prefix));
              FluentPathList.Add(String.Format("HasRequired<{0}>(x => x.{1}Url).WithMany().HasForeignKey(x => x.{1}Url_{0}ID);", RootUrlStoreTableClassName, Prefix));
            }
            else
            {
              FluentPathList.Add(String.Format("Property(x => x.{0}VersionId).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}FhirId).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("Property(x => x.{0}Type).IsOptional();", Prefix));
              FluentPathList.Add(String.Format("HasOptional(x => x.{0}Url);", Prefix));
              FluentPathList.Add(String.Format("HasOptional<{0}>(x => x.{1}Url).WithMany().HasForeignKey(x => x.{1}Url_{0}ID);", RootUrlStoreTableClassName, Prefix));              
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
          throw new InvalidEnumArgumentException(FhirApiSearchParameterInfo.SearchParamType.ToString(), (int)FhirApiSearchParameterInfo.SearchParamType, typeof(Hl7.Fhir.Model.SearchParamType));
      }
    }

    private void GenerateTableClassModelPropertiesForResource(List<string> Propertylist, List<FhirApiSearchParameterInfo> NonCollectionParameters, List<FhirApiSearchParameterInfo> CollectionParameters, string ResourceName, bool IsHistoryTable)
    {
      string MainResourceClassName = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      string ClassNameResourceHistory = DatabaseModelInfo.ConstructClassNameForResourceHistory(ResourceName);
      
      if (IsHistoryTable)
      {
        Propertylist.Add(String.Format("public int {0}ID {{get; set;}}", ClassNameResourceHistory));
        Propertylist.Add(String.Format("public virtual {0} {0} {{ get; set; }}", MainResourceClassName));        
      }
      else
      {        
        Propertylist.Add(String.Format("public int {0}ID {{get; set;}}", MainResourceClassName));
        
        foreach (var NonCollectionItem in NonCollectionParameters)
        {
          string FormatedPrefix = DatabaseModelInfo.ContructSearchParameterName(NonCollectionItem.SearchName) + '_';
          GenerateClassPropertiesForSearchParameterDataType(Propertylist, FormatedPrefix, NonCollectionItem, false);
        }

        //Resource History        
        Propertylist.Add(String.Format("public ICollection<{0}> {1}_List {{ get; set; }}", ClassNameResourceHistory, ClassNameResourceHistory));

        
        foreach (FhirApiSearchParameterInfo CollectionItem in CollectionParameters)
        {
          string ClassNameResourceSearch = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(ResourceName, CollectionItem);
          string CollectionListName = DatabaseModelInfo.ConstructCollectionListName(CollectionItem);
          Propertylist.Add(String.Format("public ICollection<{0}> {1} {{ get; set; }}", ClassNameResourceSearch, CollectionListName));
        }        

      }
    }

    private void GenerateTableClassModelPropertiesForResourceSearchIndex(List<string> Propertylist, string MainResourceClassName, string ClassNameSearchIndex, FhirApiSearchParameterInfo CollectionItem)
    {
      //This content can be move out of here to the calling method as we now use the baseIndex's to get the properties 
      //and composites are split out by the time we get here.
      Propertylist.Add(String.Format("public int {0}ID {{get; set;}}", ClassNameSearchIndex));

      if (CollectionItem.SearchParamType == Hl7.Fhir.Model.SearchParamType.Composite)
      {
        throw new Exception("This should not happen as the Composites are split out into each of there parts.");
        //foreach (var Composite in CollectionItem.CompositeSearchParameterList)
        //{
        //  string Prefix = DatabaseModelInfo.ContructSearchParameterName(Composite.SearchName);
        //  GenerateClassPropertiesForSearchParameterDataType(Propertylist, Prefix, Composite.SearchParamType, true);
        //}
      }
      else
      {
        //Remember this method is not required as each index in inherited of a base index class that gives
        //it its properties.
        //GenerateClassPropertiesForSearchParameterDataType(Propertylist, string.Empty, CollectionItem.SearchParamType, true);
      }
      Propertylist.Add(String.Format("public virtual {0} {0} {{ get; set; }}", MainResourceClassName));
    }

    private void GenerateTableClassModelPropertyConstructorInstantiationForMainResource(List<string> Propertylist, List<FhirApiSearchParameterInfo> NonCollectionParameters, List<FhirApiSearchParameterInfo> CollectionParameters, string ResourceName)
    { 
      foreach( var CollectionItem in CollectionParameters)
      {
        string CollectionListName = DatabaseModelInfo.ConstructCollectionListName(CollectionItem);
        string ClassNameResourceSearch = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(ResourceName, CollectionItem);            
        Propertylist.Add(String.Format("this.{0} = new HashSet<{1}>();", CollectionListName, ClassNameResourceSearch));            
      }
    }

    private void GenerateClassPropertiesForSearchParameterDataType(List<string> Propertylist, string Prefix, FhirApiSearchParameterInfo FhirApiSearchParameterInfo, bool IsIndex)
    {
      string IsOptionalOrRequired = string.Empty;
      if (!IsIndex)
      {
        IsOptionalOrRequired = "?";
      }

      switch (FhirApiSearchParameterInfo.SearchParamType)
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
                 if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(FhirDateTime) ||
                   FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Instant))
                 {
                   Propertylist.Add(String.Format("public DateTimeOffset{0} {1}DateTimeOffset {{get; set;}}",IsOptionalOrRequired, Prefix));                   
                 }
                 else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Date))
                 {
                   Propertylist.Add(String.Format("public DateTimeOffset{0} {1}DateTimeOffset {{get; set;}}",IsOptionalOrRequired, Prefix));
                 }
                 else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Timing))
                 {
                   Propertylist.Add(String.Format("public DateTimeOffset? {0}DateTimeOffsetLow {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public DateTimeOffset? {0}DateTimeOffsetHigh {{get; set;}}", Prefix));                   
                 }
                 else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Period))
                 {
                   Propertylist.Add(String.Format("public DateTimeOffset? {0}DateTimeOffsetLow {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public DateTimeOffset? {0}DateTimeOffsetHigh {{get; set;}}", Prefix));
                 }
                 else
                   throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", FhirApiSearchParameterInfo.SearchParamType.ToString(), FhirApiSearchParameterInfo.TargetFhirType.ToString()));
                 break;                         
               }
             case Hl7.Fhir.Model.SearchParamType.Number:
               {                 
                 Propertylist.Add(String.Format("public decimal{0} {1}Number {{get; set;}}",IsOptionalOrRequired, Prefix));                  
               }
               break;
             case Hl7.Fhir.Model.SearchParamType.Quantity:
               {
                 if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Quantity) ||
                   FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Money))
                 {
                   Propertylist.Add(String.Format("public int? {0}Comparator {{get; set;}}", Prefix));                   
                   Propertylist.Add(String.Format("public decimal{0} {1}Quantity {{get; set;}}",IsOptionalOrRequired, Prefix));
                   Propertylist.Add(String.Format("public string {0}System {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}Code {{get; set;}}", Prefix));
                 }
                 else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(SimpleQuantity))
                 {
                   Propertylist.Add(String.Format("public int? {0}Comparator {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public decimal{0} {1}Quantity {{get; set;}}",IsOptionalOrRequired, Prefix));
                   Propertylist.Add(String.Format("public string {0}System {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}Code {{get; set;}}", Prefix));
                 }
                 else if (FhirApiSearchParameterInfo.TargetFhirLogicalType == typeof(Range))
                 {
                   Propertylist.Add(String.Format("public int? {0}ComparatorLow {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public decimal? {0}QuantityLow {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}SystemLow {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}CodeLow {{get; set;}}", Prefix));

                   Propertylist.Add(String.Format("public int? {0}ComparatorHigh {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public decimal? {0}QuantityHigh {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}SystemHigh {{get; set;}}", Prefix));
                   Propertylist.Add(String.Format("public string {0}CodeHigh {{get; set;}}", Prefix));    
                 }
                 else
                   throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", FhirApiSearchParameterInfo.SearchParamType.ToString(), FhirApiSearchParameterInfo.TargetFhirType.ToString()));
                 break;
               }               
             case Hl7.Fhir.Model.SearchParamType.Reference:
               {
                 Propertylist.Add(String.Format("public string {0}VersionId {{get; set;}}", Prefix));    
                 Propertylist.Add(String.Format("public string {0}FhirId {{get; set;}}", Prefix));    
                 Propertylist.Add(String.Format("public string {0}Type {{get; set;}}", Prefix));
                 Propertylist.Add(String.Format("public virtual {1}_RootUrlStore {0}Url {{ get; set; }}", Prefix, DatabaseModelInfo.ApplicationName));
                 Propertylist.Add(String.Format("public int? {0}Url_{1}_RootUrlStoreID {{ get; set; }}", Prefix, DatabaseModelInfo.ApplicationName));                 
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
               throw new InvalidEnumArgumentException(FhirApiSearchParameterInfo.SearchParamType.ToString(), (int)FhirApiSearchParameterInfo.SearchParamType, typeof(Hl7.Fhir.Model.SearchParamType));
           }
    }

    #endregion
  }
}
