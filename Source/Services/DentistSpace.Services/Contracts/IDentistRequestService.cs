namespace DentistSpace.Services.Contracts
{
    using DentistSpace.Data.Models;

    public interface IDentistRequestService
    {
        void AddRequest(DentistRequest request);
    }
}
