using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUp.Engine;
using System.IO;

namespace Pyro.DbManager.Tools
{
  public class ScriptFileDrop
  {
    private readonly string _DirectoryPath = string.Empty;
    private readonly List<SqlScript> _SqlScriptList = null;

    public ScriptFileDrop(string FileDirectory, List<SqlScript> SqlScriptList)
    {
      _DirectoryPath = FileDirectory;
      _SqlScriptList = SqlScriptList;
    }

    public string Output(string FileNamePrependedStrip)
    {
      string Result = string.Empty;

      if(!System.IO.Path.IsPathRooted(_DirectoryPath))
      {
        Result = $"The directory path must be rooted, i.e begin with a drive letter e.g 'C:\\'.";
        return Result;
      }


      DirectoryInfo Dir;
      try
      {
        Dir = new DirectoryInfo(_DirectoryPath);
      }
      catch (Exception Exec)
      {
        Result = $"Unable to parse directory path provided, path was: {_DirectoryPath}. Error message was : {Exec.Message}";
        return Result;
      }

      if (!Dir.Exists)
      {
        try
        {
          Dir.Create();
        }
        catch (Exception Exec)
        {
          Result = $"Unable to create directory at location {_DirectoryPath} to output the SQL files to. Error message was : {Exec.Message}";
          return Result;
        }
      }

      foreach (SqlScript Script in _SqlScriptList)
      {
        try
        {
          string FileName = Script.Name.Replace($"{FileNamePrependedStrip}.", "");
          FileInfo fi = new FileInfo(Path.Combine(_DirectoryPath, FileName));
          // Create a new file 
          using (FileStream fs = fi.Create())
          {
            Byte[] txt = new UTF8Encoding(true).GetBytes(Script.Contents);
            fs.Write(txt, 0, txt.Length);
            Byte[] author = new UTF8Encoding(true).GetBytes("Author Mahesh Chand");
            fs.Write(author, 0, author.Length);
          }
        }
        catch (Exception Exec)
        {
          Result = $"Unable to output SQL Script named {Script.Name} to the path locaton {Path.Combine(_DirectoryPath, Script.Name)}. Error message was : {Exec.Message}";
          return Result;
        }
      }
      return Result;
    }

  }
}
