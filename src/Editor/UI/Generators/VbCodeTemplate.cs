﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Losenkov.RegexEditor.UI.Generators
{
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class VbCodeTemplate : CodeTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\nOption Explicit On\nOption Strict On\n\nImports System\nImports System.Text.RegularE" +
                    "xpressions\nImports VB = Microsoft.VisualBasic\n\nNamespace Test\n  Module Program\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

  for (Int32 i = 0; i < this.Methods.Length; i++)
  {
    var method = this.Methods[i];
    var methodName = (this.Methods.Length == 1) ? "Main" : String.Format("Test{0}", i);


            
            #line default
            #line hidden
            this.Write("\n    Sub ");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(methodName));
            
            #line default
            #line hidden
            this.Write("(ByVal args As String())\n      Dim pattern As String = ");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.QuoteSnippetString(this.PatternText, "        ")));
            
            #line default
            #line hidden
            this.Write("\n      Dim options As RegexOptions = ");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(String.Join(" | ", this.Options)));
            
            #line default
            #line hidden
            this.Write("\n      Dim regex As New Regex(pattern, options, TimeSpan.FromMilliseconds(1000))\n" +
                    "");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

    if (method.RegexMethod == Model.RegexMethod.Match)
    {

            
            #line default
            #line hidden
            this.Write("\n\n      Dim groupNames As String() = regex.GetGroupNames()\n      Dim groupNumbers" +
                    " As Int32() = regex.GetGroupNumbers()\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

    }
    if (method.RegexMethod == Model.RegexMethod.Replace)
    {

            
            #line default
            #line hidden
            this.Write("\n\n      Dim replacement As String = ");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.QuoteSnippetString(this.ReplacementText, "        ")));
            
            #line default
            #line hidden
            this.Write("\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("\n\n      Dim input As String = ");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.QuoteSnippetString(this.InputText, "        ")));
            
            #line default
            #line hidden
            this.Write("\n\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

    if (method.MultilineInput)
    {

            
            #line default
            #line hidden
            this.Write("\n      Using reader As New System.IO.StringReader(input)\n        Dim i As Int32 =" +
                    " 1\n        While True\n          Dim line As String = reader.ReadLine()\n         " +
                    " If line Is Nothing Then Exit While\n\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

      if (method.RegexMethod == Model.RegexMethod.Match)
      {

            
            #line default
            #line hidden
            this.Write(@"
          Dim match As Match = regex.Match(line)
          If match.Success Then
            Console.WriteLine(""Line[{0}] matches pattern"", i)

            Dim j As Int32 = 0
            Do
              Console.WriteLine(""  Match[{0}] is {1}: {2}"", j, match.GetType().Name, match.Value)

              For k As Int32 = 0 To groupNumbers.Length - 1
                Dim number As Int32 = groupNumbers(k)
                Dim name As String = groupNames(k)
                Dim group As Group = match.Groups(number)
                Dim value As String = If(group.Success, group.Value, ""--- FAILURE ---"")
                Console.WriteLine(""    Group[{0} or '{1}'] is {2}: {3}"", number, name, group.GetType().Name, value)

                For l As Int32 = 0 To group.Captures.Count - 1
                  Dim capture As Capture = group.Captures(l)
                  Console.WriteLine(""      Capture[{0}] is {1}: {2}"", l, capture.GetType().Name, capture.Value)
                Next
              Next

              j += 1
              match = match.NextMatch()
            Loop While match.Success
          Else
            Console.WriteLine(""Line[{0}] does not match pattern"", i)
          End If
");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

      }
      else if (method.RegexMethod == Model.RegexMethod.Replace)
      {

            
            #line default
            #line hidden
            this.Write("\n          Dim result As String = regex.Replace(line, replacement)\n          Cons" +
                    "ole.WriteLine(\"Line[{0}]: \", i, result)\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

      }
      else if (method.RegexMethod == Model.RegexMethod.Split)
      {

            
            #line default
            #line hidden
            this.Write(@"
          Dim result As String() = regex.Split(line)
          Console.WriteLine(""Line[{0}] has been split into {1} chunk(s)"", i, result.Length)
          For j As Int32 = 0 To result.Length - 1
            Console.WriteLine(""  Chunk[{0}]: {1}"", j, result(j))
          Next
");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

      }

            
            #line default
            #line hidden
            this.Write("\n\n          i += 1\n        End While\n      End Using\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

    }
    else
    {
      if (method.RegexMethod == Model.RegexMethod.Match)
      {

            
            #line default
            #line hidden
            this.Write(@"
      Dim match As Match = regex.Match(input)
      If match.Success Then
        Console.WriteLine(""Input matches pattern"")

        Dim i As Int32 = 0
        Do
          Console.WriteLine(""Match[{0}] is {1}: {2}"", i, match.GetType().Name, match.Value)

          For j As Int32 = 0 to groupNumbers.Length - 1
            Dim number As Int32 = groupNumbers(j)
            Dim name As String = groupNames(j)
            Dim group As Group = match.Groups(number)
            Dim value As String = If(group.Success, group.Value, ""--- FAILURE ---"")
            Console.WriteLine(""  Group[{0} or '{1}'] is {2}: {3}"", number, name, group.GetType().Name, value)

            For k As Int32 = 0 To group.Captures.Count - 1
              Dim capture As Capture = group.Captures(k)
              Console.WriteLine(""    Capture[{0}] is {1}: {2}"", k, capture.GetType().Name, capture.Value)
            Next
          Next

          i += 1
          match = match.NextMatch()
        Loop While match.Success
      Else
        Console.WriteLine(""Input does not match pattern"")
      End If
");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

      }
      else if (method.RegexMethod == Model.RegexMethod.Replace)
      {

            
            #line default
            #line hidden
            this.Write("\n      Dim result As String = regex.Replace(input, replacement)\n      Console.Wri" +
                    "teLine(result)\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

      }
      else if (method.RegexMethod == Model.RegexMethod.Split)
      {

            
            #line default
            #line hidden
            this.Write("\n      Dim result As String() = regex.Split(input)\n      Console.WriteLine(\"Input" +
                    " has been split into {0} chunks\", result.Length)\n      For i As Int32 = 0 To res" +
                    "ult.Length - 1\n        Console.WriteLine(\"  Chunk[{0}]: {1}\", i, result(i))\n    " +
                    "  Next\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

      }
    }

            
            #line default
            #line hidden
            this.Write("\n    End Sub\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

  }

  if (this.Methods.Length != 1)
  {

            
            #line default
            #line hidden
            this.Write("\n    Sub Main(ByVal args As String())\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

    for (Int32 i = 0; i < this.Methods.Length; i++)
    {
      var methodName = String.Format("Test{0}", i);

            
            #line default
            #line hidden
            this.Write("\n      ");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(methodName));
            
            #line default
            #line hidden
            this.Write("(args)\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("\n    End Sub\n");
            
            #line 1 "D:\Documents\Visual Studio 2022\Projects\RegexEditor-vsix2022\src\Editor\UI\Generators\VbCodeTemplate.tt"

  }

            
            #line default
            #line hidden
            this.Write("\n  End Module\nEnd Namespace");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
