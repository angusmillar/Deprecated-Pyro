using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools.Connectathon
{
  public class QuestionnaireResults
  {
    public QuestionnaireResults()
    {
      this.QuestionItemList = new List<QuestionItem>();
    }
    public List<QuestionItem> QuestionItemList { get; set; }
    public class QuestionItem
    {
      public string LinkId { get; set; }
      public string Text { get; set; }
      public string Answer { get; set; }
      public bool IsCorrect { get; set; }
    }
  }


}
