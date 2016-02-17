namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using DentistSpace.Data.Models;

    public interface IBannerService
    {
        Banner GetMainBanner();

        Banner GetBottomBanner();

        Banner GetRightBanner();

        Banner GetLeftBanner();
    }
}
