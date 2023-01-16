using System.Collections;
using Elsa.Extensions;
using Elsa.Workflows.Core.Attributes;

namespace Elsa.Workflows.Management.Models;

public static class InputUIHints
{
    public const string SingleLine = "single-line";
    public const string MultiLine = "multi-line";
    public const string Checkbox = "checkbox";
    public const string CheckList = "check-list";
    public const string RadioList = "radio-list";
    public const string Dropdown = "dropdown";
    public const string MultiText = "multi-text";
    public const string CodeEditor = "code-editor";
    public const string VariablePicker = "variable-picker";
    public const string TypePicker = "type-picker";

    /// <summary>
    /// An editor that allows the user to write a blob of JSON.
    /// </summary>
    public const string Json = "json";
}