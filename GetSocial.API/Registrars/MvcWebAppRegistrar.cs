namespace GetSocial.API.Registrars
{
    public class MvcWebAppRegistrar : IWebAppRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
