namespace all_the_beans.Entities.Commands.Common
{
    public interface ICommand<TCommandRequest, TCommandResponse>
    {
        Task ExecuteAsync(TCommandRequest request);
    }
}
