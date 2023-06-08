namespace ACPEFINAL.Services
{
    public interface ISessao
    {
        void add(Models.Login login);
        Models.Login get();
        void delete();
    }
}
