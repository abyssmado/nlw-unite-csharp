using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Register;

public class GetEventByIdUseCase
{
    public ResponseEventJson Execute(Guid id)
    {
        var dbContext = new PassInDbContext();


        var entity = dbContext.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id == id);

        if (entity is null)
            throw new NotFoundException("An event with this id doesn't exist");
        return new ResponseEventJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Details = entity.Details,
            MaximumAttendees = entity.Maximum_Attendees,
            AttendeesAmount = entity.Attendees.Count()
        };
    }
}