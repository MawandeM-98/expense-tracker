namespace ExpenseTracker.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseExpenseTrackerPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Tracker API v1");
                options.RoutePrefix = "swagger";
            });
        }
        else
        {
            app.UseHttpsRedirection();
        }

        app.UseCors("Frontend");
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}
