using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hl7.Fhir.Model;

namespace Pyro.Common.Extentions
{
  public static class FhirNarrativeExtentions
  {
    /// <summary>
    /// Update all referances found in the Resource narrative
    /// </summary>
    /// <param name="Narrative"></param>
    /// <param name="ReferanceMap"> Key: Old Referance, Value: New Referance</param>
    /// <returns>True if an referance was updated, False if none updated</returns>
    public static bool UpdateAllReferances(this Narrative Narrative, IDictionary<string, string> ReferanceMap)
    {
      bool HasUpdated = false;
      XNamespace ns = "http://www.w3.org/1999/xhtml";
      var xDoc = XElement.Parse(Narrative.Div);

      //Find and update all <a href=""/> referances
      List<XElement> LinkList = xDoc.Descendants().Where(x => x.Name.LocalName == "a").ToList();
      foreach (var Link in LinkList)
      {
        var href = Link.Attributes().FirstOrDefault(x => x.Name.LocalName == "href");
        if (href != null)
        {
          if (ReferanceMap.ContainsKey(href.Value))
          {
            href.Value = ReferanceMap[href.Value];
            HasUpdated = true;
          }
        }
      }

      //Find and update all <img src=""/> referances
      List<XElement> LinkListImg = xDoc.Descendants().Where(x => x.Name.LocalName == "img").ToList();
      foreach (var Link in LinkListImg)
      {
        var src = Link.Attributes().FirstOrDefault(x => x.Name.LocalName == "src");
        if (src != null)
        {
          if (ReferanceMap.ContainsKey(src.Value))
          {
            src.Value = ReferanceMap[src.Value];
            HasUpdated = true;
          }
        }
      }
      
      Narrative.Div = xDoc.ToString();
      return HasUpdated;
    }

  }
}


// FHIR Specified XHTML CSS Styles classes
//bold Bold { font-weight: bold }
//italics Italics Text	{ font-style: italic }
//underline Underlined Text	{ text-decoration: underline }
//strikethrough Strikethrough Text	{ text-decoration: line-through }
//left Left Aligned	{ text-align : left }
//right Right Aligned	{ text-align : right }
//center Center Aligned	{ text-align : center }
//justify Justified { text-align : justify }
//border-left Border on the left	{ border-left: 1px solid grey }
//border-right Border on the right	{ border-right: 1px solid grey }
//border-top Border on the top	{ border-top: 1px solid grey }
//border-bottom Border on the bottom	{ border-bottom: 1px solid grey }
//arabic List is ordered using Arabic numerals: 1, 2, 3	{ list-style-type: decimal }
//little-roman List is ordered using little Roman numerals: i, ii, iii	{ list-style-type: lower-roman }
//big-roman List is ordered using big Roman numerals: I, II, III	{ list-style-type: upper-roman }
//little-alpha List is ordered using little alpha characters: a, b, c	{ list-style-type: lower-alpha }
//big-alpha List is ordered using big alpha characters: A, B, C	{ list-style-type: upper-alpha }
//disc List bullets are simple solid discs	{ list-style-type: disc }
//circle List bullets are hollow discs { list-style-type : circle }
//square List bullets are solid squares { list-style-type: square }
//unlist List with no bullets	{ list-style-type: none }