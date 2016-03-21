namespace WinterIsComing.Contracts
{
    /// <summary>
    /// A command manager (dispatcher) called by the engine whenever a command must be executed.
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Defines the engine.
        /// </summary>
        IEngine Engine { get; set; }

        /// <summary>
        /// Collects the commands and dispatches it.
        /// </summary>
        /// <param name="commandArgs">string array of commands</param>
        void DispatchCommand(string[] commandArgs);

        /// <summary>
        /// Seeds the commands and calls the corresponding command class.
        /// </summary>
        void SeedCommands();
    }
}
