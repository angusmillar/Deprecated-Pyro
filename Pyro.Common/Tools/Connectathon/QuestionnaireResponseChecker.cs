using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Common.Tools.Connectathon
{
  public static class QuestionnaireResponseChecker
  {
    public static QuestionnaireResults Check(QuestionnaireResponse Answers, QuestionnaireResponse Response)
    {
      var QuestionnaireResults = new QuestionnaireResults();
      return ProcessItems(Answers.Item, Response.Item, QuestionnaireResults);
    }

    private static QuestionnaireResults ProcessItems(List<QuestionnaireResponse.ItemComponent> AnswerList, List<QuestionnaireResponse.ItemComponent> ResponseList, QuestionnaireResults Results)
    {
      foreach (var AItem in AnswerList)
      {
        if (ResponseList != null)
        {
          var RItem = ResponseList.SingleOrDefault(x => x.LinkId == AItem.LinkId);
          if (AItem.Answer != null && AItem.Answer.Count > 0)
          {
            var QuestionItem = new QuestionnaireResults.QuestionItem();
            Results.QuestionItemList.Add(QuestionItem);
            QuestionItem.LinkId = AItem.LinkId;
            QuestionItem.Text = AItem.Text;

            if (RItem.Answer != null)
            {
              for (int i = 0; i < AItem.Answer.Count; i++)
              {
                if (AItem.Answer.Count >= i)
                {
                  if (RItem.Answer[i].Value.ToString() == AItem.Answer[i].Value.ToString())
                  {
                    QuestionItem.Answer = RItem.Answer[i].Value.ToString();
                    QuestionItem.IsCorrect = true;

                  }
                  else
                  {
                    QuestionItem.Answer = RItem.Answer[i].Value.ToString();
                    QuestionItem.IsCorrect = false;
                  }
                }
              }
            }
            else
            {
              QuestionItem.Answer = string.Empty;
              QuestionItem.IsCorrect = false;
            }
          }

          if (AItem.Item != null && AItem.Item.Count > 0)
          {
            if (RItem != null && RItem.Item != null)
            {
              return ProcessItems(AItem.Item, RItem.Item, Results);
            }
            else
            {
              return ProcessItems(AItem.Item, null, Results);
            }
          }
        }
        else
        {
          if (AItem.Answer != null)
          {
            var QuestionItem = new QuestionnaireResults.QuestionItem();
            Results.QuestionItemList.Add(QuestionItem);
            QuestionItem.LinkId = AItem.LinkId;
            QuestionItem.Text = AItem.Text;
            QuestionItem.Answer = string.Empty;
            QuestionItem.IsCorrect = false;
          }
        }

        if (AItem.Item != null && AItem.Item.Count > 0)
        {
          return ProcessItems(AItem.Item, null, Results);
        }

      }
      return Results;
    }
  }
}
