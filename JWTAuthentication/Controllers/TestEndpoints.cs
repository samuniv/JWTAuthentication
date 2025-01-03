using JWTAuthentication.Authentication;
using JWTAuthentication.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace JWTAuthentication.Controllers;

public static class TestEndpoints
{
    public static void MapTestEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Test")
            .WithTags(nameof(Test))
            .RequireAuthorization(new AuthorizeAttribute { Policy = nameof(PermissionEnum.AccessTests) });

        group.MapGet("/", [HasPermission(PermissionEnum.ViewTests)] async (ApplicationDbContext db) =>
        {
            return await db.Tests.ToListAsync();
        })
        .WithName("GetAllTests")
        .WithOpenApi();

        group.MapGet("/{id}", [HasPermission(PermissionEnum.ViewTestById)] async Task<Results<Ok<Test>, NotFound>> (Guid id, ApplicationDbContext db) =>
        {
            return await db.Tests.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Test model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTestById")
        .WithOpenApi();

        group.MapPut("/{id}", [HasPermission(PermissionEnum.UpdateTest)] async Task<Results<Ok, NotFound>> (Guid id, Test test, ApplicationDbContext db) =>
        {
            var affected = await db.Tests
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, test.Id)
                    .SetProperty(m => m.Name, test.Name)
                    .SetProperty(m => m.Description, test.Description)
                    .SetProperty(m => m.CreatedAt, test.CreatedAt)
                    .SetProperty(m => m.UpdatedAt, test.UpdatedAt)
                    .SetProperty(m => m.LastModifiedAt, test.LastModifiedAt)
                    .SetProperty(m => m.LastModifiedBy, test.LastModifiedBy)
                    .SetProperty(m => m.IsDeleted, test.IsDeleted)
                    .SetProperty(m => m.DeletedAt, test.DeletedAt)
                    .SetProperty(m => m.DeletedBy, test.DeletedBy)
                    .SetProperty(m => m.IsActive, test.IsActive)
                    .SetProperty(m => m.ActiveFrom, test.ActiveFrom)
                    .SetProperty(m => m.ActiveTo, test.ActiveTo)
                    .SetProperty(m => m.CreatedBy, test.CreatedBy)
                    .SetProperty(m => m.UpdatedBy, test.UpdatedBy)
                    .SetProperty(m => m.ActiveBy, test.ActiveBy)
                    .SetProperty(m => m.DeactivatedBy, test.DeactivatedBy)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTest")
        .WithOpenApi();

        group.MapPost("/", [HasPermission(PermissionEnum.CreateTest)] async (Test test, ApplicationDbContext db) =>
        {
            db.Tests.Add(test);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Test/{test.Id}", test);
        })
        .WithName("CreateTest")
        .WithOpenApi();

        group.MapDelete("/{id}", [HasPermission(PermissionEnum.DeleteTest)] async Task<Results<Ok, NotFound>> (Guid id, ApplicationDbContext db) =>
        {
            var affected = await db.Tests
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTest")
        .WithOpenApi();
    }
}
