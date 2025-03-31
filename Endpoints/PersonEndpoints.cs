using Microsoft.EntityFrameworkCore;
using REST_API_för_CV_hantering.Data;
using REST_API_för_CV_hantering.DTOs.PersonDTOs;
using REST_API_för_CV_hantering.DTOs.ExperienceDTOs;
using REST_API_för_CV_hantering.DTOs.EducationDTOs;
using REST_API_för_CV_hantering.Models;
using System.ComponentModel.DataAnnotations;


namespace REST_API_för_CV_hantering.Endpoints
{
    public class PersonEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // GET All info about All persons, and their respective experience and education.
            app.MapGet("/person", async (CVContext context) =>
            {
                try
                {
                    var persons = await context.Persons
                    .Include(p => p.Educations)
                    .Include(p => p.Experiences)
                    .Select(p => new PersonListDTO
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Email = p.Email,
                        MobileNumber = p.MobileNumber,
                        Description = p.Description,
                        Educations = p.Educations.Select(e => new EducationDTO
                        {
                            School = e.School,
                            Degree = e.Degree,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate
                        }).ToList(),
                        Experiences = p.Experiences.Select(e => new ExperienceDTO
                        {
                            Company = e.Company,
                            JobTitle = e.JobTitle,
                            Description = e.Description,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate
                        }).ToList()
                    })
                    .ToListAsync();

                    if (persons == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(persons);
                }
                catch (Exception)
                {
                    return Results.Json(new { message = "Something went wrong, please try again later." }, statusCode: 500);
                }
            });

            app.MapGet("/person/{id}", async (CVContext context, int id) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest(new { message = "Invalid person ID." });
                }

                try
                {
                    var person = await context.Persons
                        .Where(p => p.PersonId == id)
                        .Select(p => new PersonDTO
                        {
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Email = p.Email,
                            MobileNumber = p.MobileNumber,
                            Description = p.Description
                        })
                        .SingleOrDefaultAsync();

                    if (person == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(person);
                }
                catch (Exception)
                {
                    

                    return Results.Json(new { message = "Something went wrong, please try again later." }, statusCode: 500);
                }
            }).WithName("GetPersonById");



            // GET specific Person with details based on ID
            app.MapGet("/person/{id}/details", async (CVContext context, int id) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest(new { message = "Invalid person ID." });
                }

                try
                {
                    var person = await context.Persons
                        .Where(p => p.PersonId == id)
                        .Select(p => new PersonWithDetailsDTO
                        {
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            EmailAddress = p.Email,
                            MobileNumber = p.MobileNumber,
                            Description = p.Description,
                            Educations = p.Educations.Select(e => new EducationDTO
                            {
                                School = e.School,
                                Degree = e.Degree,
                                StartDate = e.StartDate,
                                EndDate = e.EndDate
                            }).ToList(),
                            Experiences = p.Experiences.Select(e => new ExperienceDTO
                            {
                                Company = e.Company,
                                JobTitle = e.JobTitle,
                                Description = e.Description,
                                StartDate = e.StartDate,
                                EndDate = e.EndDate
                            }).ToList()
                        })
                        .SingleOrDefaultAsync();

                    if (person == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(person);
                }
                catch (Exception)
                {

                    return Results.Json(new { message = "Something went wrong, please try again later." }, statusCode: 500);
                }
            }).WithName("GetPersonDetailsById");

            // POST/add a new Person
            app.MapPost("/person", async (PersonCreateDTO newPerson, CVContext context) =>
            {
                if (newPerson == null)
                {
                    return Results.BadRequest(new { message = "Invalid Person data." });
                }

                try
                {
                    var validationContext = new ValidationContext(newPerson);
                    var validationResult = new List<ValidationResult>();

                    bool isValid = Validator.TryValidateObject(newPerson, validationContext, validationResult, true);

                    if (!isValid)
                        return Results.BadRequest(new { errors = validationResult.Select(v => v.ErrorMessage).ToList() });

                    var existingPerson = await context.Persons
                        .Where(p => (p.Email == newPerson.Email || p.MobileNumber == newPerson.MobileNumber))
                        .FirstOrDefaultAsync();

                    if (existingPerson != null)
                    {
                        return Results.BadRequest(new { message = "A person with this email or mobileNumber number already exists." });
                    }

                    var person = new Person
                    {
                        FirstName = newPerson.FirstName,
                        LastName = newPerson.LastName,
                        Email = newPerson.Email,
                        MobileNumber = newPerson.MobileNumber,
                        Description = newPerson.Description
                    };

                    context.Persons.Add(person);
                    await context.SaveChangesAsync();

                    var personDto = new PersonDTO
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Email = person.Email,
                        MobileNumber = person.MobileNumber,
                        Description = person.Description
                    };

                    return Results.CreatedAtRoute("GetPersonById", new { id = person.PersonId }, personDto);
                }
                catch (Exception)
                {
                    // For production level, use the ex message to log it.

                    return Results.Json(new { message = "Something went wrong, please try again later." }, statusCode: 500);
                }
            });


            // PUT/Change existing info
            app.MapPut("/person/{id}", async (PersonPutDTO personDto, CVContext context, int id) =>
            {
                try
                {
                    var existingPerson = await context.Persons.FirstOrDefaultAsync(s => s.PersonId == id);
                    if (existingPerson == null)
                        return Results.NotFound($"Person with ID {id} not found.");

                    // Validation for provided Data
                    var validationContext = new ValidationContext(personDto);
                    var validationResult = new List<ValidationResult>();
                    bool isValid = Validator.TryValidateObject(personDto, validationContext, validationResult, true);

                    if (!isValid)
                        return Results.BadRequest(validationResult.Select(v => v.ErrorMessage));

                    // Validation for duplicate records
                    var duplicateData = await context.Persons
                        .Where(p => (p.Email == personDto.EmailAddress || p.MobileNumber == personDto.MobileNumber) && p.PersonId != id)
                        .FirstOrDefaultAsync();

                    if (duplicateData != null)
                    {
                        string duplicateField = duplicateData.Email == duplicateData.MobileNumber ? "email" : "MobileNumber";
                        return Results.BadRequest(new { message = $"A person with this {duplicateField} already exists." });
                    }


                    // Replace old data with new
                    existingPerson.FirstName = personDto.Firstname;
                    existingPerson.LastName = personDto.LastName;
                    existingPerson.Email = personDto.EmailAddress;
                    existingPerson.MobileNumber = personDto.MobileNumber;
                    existingPerson.Description = personDto.Description;

                    await context.SaveChangesAsync();

                    var updatedPersonDto = new PersonDTO
                    {
                        FirstName = existingPerson.FirstName,
                        LastName = existingPerson.LastName,
                        Email = existingPerson.Email,
                        MobileNumber = existingPerson.MobileNumber,
                        Description = existingPerson.Description
                    };

                    return Results.AcceptedAtRoute("GetPersonById", new { id = existingPerson.PersonId }, updatedPersonDto);
                }
                catch (Exception)
                {
                    return Results.Json(new { message = "Something went wrong, please try again later." }, statusCode: 500);
                }
            });

            // PATCH/Change partial existing info
            app.MapPatch("/person/{id}", async (PersonPatchDTO PersonDTO, CVContext context, int id) =>
            {
                try
                {
                    var existingPerson = await context.Persons.FirstOrDefaultAsync(s => s.PersonId == id);
                    if (existingPerson == null)
                        return Results.NotFound($"Person with ID {id} not found.");

                    // Validation for provided Data
                    var validationContext = new ValidationContext(PersonDTO);
                    var validationResult = new List<ValidationResult>();
                    bool isValid = Validator.TryValidateObject(PersonDTO, validationContext, validationResult, true);

                    if (!isValid)
                        return Results.BadRequest(validationResult.Select(v => v.ErrorMessage));

                    // Validation for duplicate records
                    var duplicateData = await context.Persons
                        .Where(p => (p.Email == PersonDTO.EmailAddress || p.MobileNumber == PersonDTO.MobileNumber) && p.PersonId != id)
                        .FirstOrDefaultAsync();

                    if (duplicateData != null)
                    {
                        string duplicateField = duplicateData.Email == duplicateData.MobileNumber ? "email" : "MobileNumber";
                        return Results.BadRequest(new { message = $"A person with this {duplicateField} already exists." });
                    }


                    // Replaces only the fields that are provided in the request
                    existingPerson.FirstName = PersonDTO.FirstName ?? existingPerson.FirstName;
                    existingPerson.LastName = PersonDTO.LastName ?? existingPerson.LastName;
                    existingPerson.Email = PersonDTO.EmailAddress ?? existingPerson.Email;
                    existingPerson.MobileNumber = PersonDTO.MobileNumber ?? existingPerson.MobileNumber;
                    existingPerson.Description = PersonDTO.Description ?? existingPerson.Description;

                    await context.SaveChangesAsync();

                    var updatedPersonDto = new PersonDTO
                    {
                        FirstName = existingPerson.FirstName,
                        LastName = existingPerson.LastName,
                        Email = existingPerson.Email,
                        MobileNumber = existingPerson.MobileNumber,
                        Description = existingPerson.Description
                    };

                    return Results.AcceptedAtRoute("GetPersonById", new { id = existingPerson.PersonId }, updatedPersonDto);
                }
                catch (Exception)
                {
                    // For production level, use the ex message to log it.

                    return Results.Json(new { message = "Something went wrong, please try again later." }, statusCode: 500);
                }
            });

            // DELETE a record
            app.MapDelete("/person/{id}", async (CVContext context, int id) =>
            {
                try
                {
                    var person = await context.Persons
                    .FirstOrDefaultAsync(p => p.PersonId == id);

                    if (person == null)
                        return Results.NotFound(new { message = "Person not found" });

                    context.Persons.Remove(person);
                    await context.SaveChangesAsync();

                    return Results.NoContent();
                }
                catch (Exception)
                {
                    return Results.Json(new { message = "Something went wrong, please try again later." }, statusCode: 500);
                }
            });





        }
    }
}
