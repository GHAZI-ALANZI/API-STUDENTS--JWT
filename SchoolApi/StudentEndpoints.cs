using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using School_API.Models;
namespace SchoolApi;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (SchoolApiContext db) =>
        {
            return await db.Student.ToListAsync();
        })
        .WithName("GetAllStudents")
        .Produces<List<Student>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Student/{id}", async (string StudentId, SchoolApiContext db) =>
        {
            return await db.Student.FindAsync(StudentId)
                is Student model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetStudentById")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Student/{id}", async (string StudentId, Student student, SchoolApiContext db) =>
        {
            var foundModel = await db.Student.FindAsync(StudentId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(student);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateStudent")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Student/", async (Student student, SchoolApiContext db) =>
        {
            db.Student.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/Students/{student.StudentId}", student);
        })
        .WithName("CreateStudent")
        .Produces<Student>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Student/{id}", async (string StudentId, SchoolApiContext db) =>
        {
            if (await db.Student.FindAsync(StudentId) is Student student)
            {
                db.Student.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudent")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
