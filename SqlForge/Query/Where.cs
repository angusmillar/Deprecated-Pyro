using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class Where :StatmentBase
  {
    private const string _WhereCommand = "WHERE";
    private const string _BetweenCommand = "BETWEEN";
    private Queue<String> WhereQueue = new Queue<String>();
    private Enums.Operator PendingOperator = Enums.Operator.None;

    public void AddCondition(SqlTable leftProperty, Enums.Sign sign, string value)
    {
      this.ResetCache();
      string item = string.Empty;

      if (leftProperty.TableAlias != string.Empty)
        item = String.Format("{0}.{1} {2} {3}", leftProperty.TableAlias, leftProperty.PropertyName, StringSupport.SignToString(sign), value);
      else
        item = String.Format("{0} {1} {2}", leftProperty.PropertyName, StringSupport.SignToString(sign), value);

      if (PendingOperator != Enums.Operator.None)
        item = String.Format("{0} {1}", StringSupport.OperatorToString(PendingOperator), item);
      PendingOperator = Enums.Operator.None;

      WhereQueue.Enqueue(item);

    }

    public void AddSubCondition(Where SubWhere)
    {
      this.ResetCache();
      string item = string.Empty;

      if (PendingOperator != Enums.Operator.None)
        item = String.Format("{0} ({1} )", StringSupport.OperatorToString(PendingOperator), SubWhere.GetWhereCommand(true));
      else
        item = String.Format("({0} )", SubWhere.GetWhereCommand(true));
      PendingOperator = Enums.Operator.None;

      WhereQueue.Enqueue(item);
    }

    public void AddBetweenCondition(SqlTable Property, string Lower, string Upper)
    {
      this.ResetCache();
      string item = string.Empty;

      if (Property.TableAlias != string.Empty)
        item = String.Format("({0}.{1} {2} {3} AND {4})", Property.TableAlias, Property.PropertyName, _BetweenCommand, Lower, Upper);
      else
        item = String.Format("({0} {1} {2} AND {3})", Property.PropertyName, _BetweenCommand, Lower, Upper);

      if (PendingOperator != Enums.Operator.None)
        item = String.Format("{0} {1}", StringSupport.OperatorToString(PendingOperator), item);

      PendingOperator = Enums.Operator.None;

      WhereQueue.Enqueue(item);
    }

    public void AddOperator(Enums.Operator Operator)
    {
      this.ResetCache();
      PendingOperator = Operator;
    }

    public override string GetStatment()
    {
      return this.GetWhereCommand();
    }

    public string GetWhereCommand(bool ConditionsOnly = false)
    {
      if (this.CachedStatment != string.Empty)
        return this.CachedStatment;

      PendingOperator = Enums.Operator.None;
      var Statment = new StringBuilder();
      if (!ConditionsOnly)
        Statment.Where().NewLine().Space(2);

      do
      {
        var SqlProp = WhereQueue.Dequeue();
        Statment.Space().Append(SqlProp);

      } while (WhereQueue.Count != 0);

      if (!ConditionsOnly)
        Statment.NewLine();
      this.CachedStatment = Statment.ToString();
      return this.CachedStatment;
    }
  }
}
