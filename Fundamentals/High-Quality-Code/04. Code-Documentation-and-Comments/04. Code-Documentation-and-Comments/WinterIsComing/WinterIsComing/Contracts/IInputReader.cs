namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Defines a source of input (e.g. console).
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Defines the source of input.
        /// </summary>
        /// <returns></returns>
        string ReadNextLine();
    }
}
