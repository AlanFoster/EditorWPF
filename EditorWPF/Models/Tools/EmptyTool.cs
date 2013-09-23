namespace EditorWPF.Models.Tools
{
    /// <summary>
    ///     The default tool that does proves a noop implementation.
    ///     This in essence is the Null Object Pattern.
    /// </summary>
    internal class EmptyTool : Tool
    {
        private const string ToolName = "None";

        public EmptyTool()
            : base(ToolName)
        {
        }
    }
}