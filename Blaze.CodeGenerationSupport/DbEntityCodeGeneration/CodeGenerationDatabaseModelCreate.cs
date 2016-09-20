using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blaze.Common.Database;
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

    public List<CodeGenerationDbTableModel> Generate()
    {
      _ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      _SearchParametersList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();
      _CodeGenerationDbTableModelList = new List<CodeGenerationDbTableModel>();

      //Url Store Table      
      _CodeGenerationDbTableModelList.Add(Create_ServiceRootUrlStore_Table());

      foreach (var ResourceName in _ResourceList)
      {
        if (ResourceName == "DiagnosticReport")
        {

        }

        List<FhirApiSearchParameterInfo> SearchParametersForResource = SearchParameterFilter.GetParametersForResource(ResourceName, _SearchParametersList);
        List<FhirApiSearchParameterInfo> CollectionParameters = SearchParameterFilter.GetIsColectionParameters(true, SearchParametersForResource);
        List<FhirApiSearchParameterInfo> NonCollectionParameters = SearchParameterFilter.GetIsColectionParameters(false, SearchParametersForResource);


        CollectionParameters = FhirApiSearchParameterInfoFactory.RemoveDuplicates(CollectionParameters);
        NonCollectionParameters = FhirApiSearchParameterInfoFactory.RemoveDuplicates(NonCollectionParameters);

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
      return _CodeGenerationDbTableModelList;
    }

    #endregion

    #region Private Methods

    private CodeGenerationDbTableModel Create_ModelResourceSearchIndexTable(string ResourceName, FhirApiSearchParameterInfo CollectionItem)
    {
      string ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      //Below used for Debug
      if (CollectionItem.SearchName == "collected")
      {
        ClassNameResource = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
      }

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
      TableModel.TableClassModel.ClassInheritanceList.Add(StaticDatabaseInfo.DatabaseModelResourceIndexBaseClassName);
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
      TableModel.TableClassModel.ClassInheritanceList.Add(StaticDatabaseInfo.DatabaseModelResourceIndexBaseClassName);
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
    private CodeGenerationDbTableModel Create_ServiceRootUrlStore_Table()
    {
      //string UrlStoreTableClassName = String.Format("{0}_RootUrlStore", DatabaseModelInfo.ApplicationName);
      string UrlStoreTableClassName = StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ClassNameServiceRootURL_Store;
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
      list.Add(DatabaseModelInfo.GetServerSearchIndexTypeString(FhirApiSearchParameterInfo));
    }

    /// <summary>
    /// Generates the Fluent configuration statements for the Main Resource 
    /// </summary>
    /// <param name="FluentPathList"></param>
    /// <param name="NonCollectionParameters"></param>
    private void GenerateConfigurationFluentStatmentsForMainResource(List<string> FluentPathList, string TableClassName, List<FhirApiSearchParameterInfo> NonCollectionParameters)
    {
      FluentPathList.Add(string.Format("HasKey(x => x.{0}ID).Property(x => x.{0}ID).IsRequired();", TableClassName));
      FluentPathList.Add(string.Format("Property(x => x.{0}).IsRequired();", StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.BaseResourceIndexConstatnts.IsDeleted));
      FluentPathList.Add(string.Format("Property(x => x.{0}).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(\"IX_{0}\") {{ IsUnique = true }}));", StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.BaseResourceIndexConstatnts.FhirId));
      FluentPathList.Add(string.Format("Property(x => x.{0}).IsRequired();", StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.BaseResourceIndexConstatnts.lastUpdated));
      FluentPathList.Add(string.Format("Property(x => x.{0}).IsRequired();", StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.BaseResourceIndexConstatnts.versionId));
      FluentPathList.Add(string.Format("Property(x => x.XmlBlob).IsRequired();", StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.BaseResourceIndexConstatnts.XmlBlob));
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

    private void GenerateClassPropertyFluentStatmentForSearchParameterDataType(string Prefix, FhirApiSearchParameterInfo FhirApiSearchParameterInfo, bool IsCollection, List<string> FluentPathList)
    {
      string IsOptional = "Optional";
      string IsRequired = "Required";
      string RequiredOrOptional = IsOptional;
      if (IsCollection)
      {
        RequiredOrOptional = IsRequired;
      }

      //Common.Enum.DatabaseEnum.DbIndexType DbIndexType = DatabaseModelInfo.GetServerSearchIndexType(FhirApiSearchParameterInfo);
      Common.Enum.DatabaseEnum.DbIndexType DbIndexType = FhirApiSearchParameterInfo.DbIndexType;
      foreach (string PropertyName in StaticDatabaseInfo.BlazeIndexTypeToDbPropertyNameStringList_Dictonary[DbIndexType])
      {
        if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.DateTimePeriodIndex)
        {
          FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
        }
        else if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.DateIndex)
        {
          FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
        }
        else if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex)
        {
          FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
        }
        else if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.NumberIndex)
        {
          if (PropertyName == StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator)
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
          }
          else
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, RequiredOrOptional));
          }
        }
        else if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex)
        {
          if (PropertyName == StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity && IsCollection)
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsRequired));
          }
          else
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
          }
        }
        else if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.QuantityRangeIndex)
        {
          FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
        }
        else if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.TokenIndex)
        {
          if (PropertyName == StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code && IsCollection)
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsRequired));
          }
          else
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
          }
        }
        else if (DbIndexType == Common.Enum.DatabaseEnum.DbIndexType.ReferenceIndex)
        {
          if (PropertyName == StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ServiceRootURL_StoreID)
          {
            FluentPathList.Add(String.Format("Has{0}<{1}>(x => x.{2}{3}).WithMany().HasForeignKey(x => x.{2}{4});",
              RequiredOrOptional,
              StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ClassNameServiceRootURL_Store,
              Prefix,
              StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Url,
              PropertyName));
          }
          else if (PropertyName == StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Url)
          {
            FluentPathList.Add(String.Format("Has{0}(x => x.{1}{2});", RequiredOrOptional, Prefix, PropertyName));
          }
          else if (PropertyName == StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.VersionId)
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, IsOptional));
          }
          else
          {
            FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, RequiredOrOptional));
          }
        }
        else
        {
          //For all others the Optionality just switched in IsCollecion
          FluentPathList.Add(String.Format("Property(x => x.{0}{1}).Is{2}();", Prefix, PropertyName, RequiredOrOptional));
        }
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
      foreach (var CollectionItem in CollectionParameters)
      {
        string CollectionListName = DatabaseModelInfo.ConstructCollectionListName(CollectionItem);
        string ClassNameResourceSearch = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(ResourceName, CollectionItem);
        Propertylist.Add(String.Format("this.{0} = new HashSet<{1}>();", CollectionListName, ClassNameResourceSearch));
      }
    }

    private void GenerateClassPropertiesForSearchParameterDataType(List<string> Propertylist, string Prefix, FhirApiSearchParameterInfo FhirApiSearchParameterInfo, bool IsIndex)
    {
      string IsOptional = "?";
      string IsOptionalOrRequired = string.Empty;
      if (!IsIndex)
      {
        IsOptionalOrRequired = IsOptional;
      }
      //Common.Enum.DatabaseEnum.DbIndexType DbIndexType = DatabaseModelInfo.GetServerSearchIndexType(FhirApiSearchParameterInfo);
      Common.Enum.DatabaseEnum.DbIndexType DbIndexType = FhirApiSearchParameterInfo.DbIndexType;
      switch (DbIndexType)
      {
        case Common.Enum.DatabaseEnum.DbIndexType.DateIndex:
          {
            Propertylist.Add(String.Format("public int{0} {1}{2} {{get; set;}}", IsOptionalOrRequired, Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex:
          {
            Propertylist.Add(String.Format("public DateTimeOffset{0} {1}{2} {{get; set;}}", IsOptionalOrRequired, Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          {
            Propertylist.Add(String.Format("public DateTimeOffset? {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow));
            Propertylist.Add(String.Format("public DateTimeOffset? {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.NumberIndex:
          {
            Propertylist.Add(String.Format("public Hl7.Fhir.Model.Quantity.QuantityComparator{0} {1}{2} {{get; set;}}", IsOptional, Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator));
            Propertylist.Add(String.Format("public decimal{0} {1}{2} {{get; set;}}", IsOptionalOrRequired, Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex:
          {
            Propertylist.Add(String.Format("public Hl7.Fhir.Model.Quantity.QuantityComparator{0} {1}{2} {{get; set;}}", IsOptional, Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator));
            Propertylist.Add(String.Format("public decimal{0} {1}{2} {{get; set;}}", IsOptionalOrRequired, Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.QuantityRangeIndex:
          {
            Propertylist.Add(String.Format("public Hl7.Fhir.Model.Quantity.QuantityComparator? {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.ComparatorLow));
            Propertylist.Add(String.Format("public decimal? {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.QuantityLow));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.SystemLow));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.CodeLow));

            Propertylist.Add(String.Format("public Hl7.Fhir.Model.Quantity.QuantityComparator? {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.ComparatorHigh));
            Propertylist.Add(String.Format("public decimal? {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.QuantityHigh));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.SystemHigh));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.CodeHigh));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.ReferenceIndex:
          {
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.VersionId));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Type));
            Propertylist.Add(String.Format("public virtual {1} {0}Url {{ get; set; }}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ClassNameServiceRootURL_Store));
            Propertylist.Add(String.Format("public int? {0}{1} {{ get; set; }}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ServiceRootURL_StoreID));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.StringIndex:
          {
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.TokenIndex:
          {
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code));
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System));
          }
          break;
        case Common.Enum.DatabaseEnum.DbIndexType.UriIndex:
          {
            Propertylist.Add(String.Format("public string {0}{1} {{get; set;}}", Prefix, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri));
          }
          break;
        default:
          throw new InvalidEnumArgumentException(DbIndexType.ToString(), (int)DbIndexType, typeof(Blaze.Common.Enum.DatabaseEnum.DbIndexType));
      }

    }

    #endregion
  }
}
