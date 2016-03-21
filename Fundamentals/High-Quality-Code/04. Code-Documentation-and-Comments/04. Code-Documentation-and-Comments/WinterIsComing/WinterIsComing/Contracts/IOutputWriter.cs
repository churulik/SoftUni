namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Defines an output source (e.g. console).
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Defines the output source.
        /// </summary>
        /// <param name="line">string value</param>
        void Write(string line);

        /// <summary>
        /// Write the output.
        /// </summary>
        void Flush();
    }
}
