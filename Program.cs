using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTextByRegexp
{
  using System.Text.RegularExpressions;

  class Program
  {
    static void Main(string[] args)
    {
      if (args.Count() != 3)
      {
        Console.WriteLine("ERROR: Wrong arguments set, there should be 3 paths: 1 - source file with text to find, 2 - file which contain regular expression, 3 - target file where results will be stored to");
        return;
      }

      var source = args[0];
      var regexp = args[1];
      var target = args[2];

      if (!System.IO.File.Exists(source))
      {
        Console.WriteLine("ERROR: File \"{0}\" does not exist", source);
        return;
      }

      if (!System.IO.File.Exists(regexp))
      {
        Console.WriteLine("ERROR: File \"{0}\" does not exist", regexp);
        return;
      }

      var text = System.IO.File.ReadAllText(source);
      var regexpContent = System.IO.File.ReadAllText(regexp);
      var regex = new Regex(regexpContent);
      var matches = regex.Matches(text);
      var outputResult = new List<string>();
      for (var i = 0; i < matches.Count; i++)
      {
        outputResult.Add(matches[i].Value);
      }

      var cleanedString = outputResult.Distinct().Select(x => x.Replace("SC_ANALYTICS_GLOBAL_COOKIE=", string.Empty))
                                                .Select(x => x.Replace(";", string.Empty))
                                                .Select(x => new Guid(x).ToString())
                                                .Select(x => "'" + x + "'");
      System.IO.File.WriteAllText(target, string.Join(", ", cleanedString.ToArray()));
    }
  }
}
