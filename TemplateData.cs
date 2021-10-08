using  System;

namespace Automation
{
    public class TemplateData
    {
        public enum MethodType
        {
            ClickById,
            ClickByXpath,
            EnterTextById,
            EnterTextByXpath,
            NavigateToURL,
            SelectValueFromDropDown,
            ValidateEqual,
            ValidateNotEqual,
            ValidateContains,
            WaitFor,
            WaitForDemo,
            WaitUntil
        }

        public string Input { get; set; }
        public string Method { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
    }
}