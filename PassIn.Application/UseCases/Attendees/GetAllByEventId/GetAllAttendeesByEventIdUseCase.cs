using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventId;

public class GetAllAttendeesByEventIdUseCase
{
    private readonly PassInDbContext _dbContext = new();


    public ResponseAllAttendeesJson Execute(Guid eventId)
    {
        var entity = _dbContext.Events.Include(e => e.Attendees).ThenInclude(attendee => attendee.CheckIn)
            .FirstOrDefault(e => e.Id == eventId);
        if (entity is null)
            throw new NotFoundException("There is no attendee for this event.");

        return new ResponseAllAttendeesJson
        {
            Attendees = entity.Attendees.Select(attendee => new ResponseAttendeeJson
            {
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.Email,
                CreatedAt = attendee.Created_at,
                CheckedInAt = attendee.CheckIn?.Created_at
            }).ToList()
        };
    }
}