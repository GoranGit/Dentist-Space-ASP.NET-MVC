namespace DentistSpace.Web.Models.BaseModels
{
    using DentistSpace.Services.Web;

    public class IdentifierBaseModel
    {
        protected readonly IIdentifierProvider identifierProvider;

        public IdentifierBaseModel(IIdentifierProvider identifierProvider)
        {
            this.identifierProvider = identifierProvider;
        }

        public IdentifierBaseModel()
            : this(new IdentifierProvider())
        {
        }
    }
}
