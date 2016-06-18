namespace WinFormsSandbox
{
    /// <summary>
    /// Specifies what type of line-break is used. Or specifies that
    /// a line-break be inferred.
    /// </summary>
    public enum LineBreakKind
    {
        /// <summary>
        /// Indicates that a single newline character (\n) is used to for line-breaks.
        /// </summary>
        NewLine,
        /// <summary>
        /// Indicates that a line-break is determined by a return carriage followed by
        /// a linefeed (\r\n).
        /// </summary>
        LegacyNewLine,
        /// <summary>
        /// The line-break type is automatically inferred.
        /// </summary>
        Auto
    }
}
