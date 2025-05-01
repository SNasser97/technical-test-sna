namespace all_the_beans.Entities.Queries.Common
{
    public interface IQuery<TQueryRequest, TQueryResponse>
    {
        Task<TQueryResponse> ExecuteAsync(TQueryRequest request);
    }
}
