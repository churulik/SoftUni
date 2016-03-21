namespace WinterIsComing.Contracts
{
    /// <summary>
    /// An executable action used by the engine.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Defines the engine.
        /// </summary>
        IEngine Engine { get; }

        /// <summary>
        /// Collect and execute commands.
        /// </summary>
        /// <param name="commandArgs">string array commands</param>
        void Execute(string[] commandArgs);
    }
}
