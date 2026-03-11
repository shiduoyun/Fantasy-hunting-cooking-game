using UnityEngine;
using TMPro;

public class AdvancedTextPreprocessor : ITextPreprocessor
{
    public string PreprocessorText(string text)
    {
        return "ABC";
    }
}public class AdvancedText : TextMeshProUGUI
{
    protected override void Awake()
    {
        base.Awake();
        textPreprocessor = new AdvancedTextPreprocessor();
    }
}
