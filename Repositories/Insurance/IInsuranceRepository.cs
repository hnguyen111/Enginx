namespace API.Repositories.Insurance;

public interface IInsuranceRepository
{
    public Task Save(Models.Insurance insurance, CancellationToken cancellationToken);
    public Task<Models.Insurance?> RetrieveInsuranceById(string? id, CancellationToken cancellationToken);

    public Task<List<Models.Insurance>> RetrieveAllInsurances(CancellationToken cancellationToken);

    public Task Update(Models.Insurance insurance, Models.Insurance updates, CancellationToken cancellationToken);
}