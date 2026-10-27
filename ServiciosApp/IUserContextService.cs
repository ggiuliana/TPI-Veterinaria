namespace ServiciosApp
{
    public interface IUserContextService
    {
        int GetCurrentUserId();
        string GetCurrentRole();
    }
}