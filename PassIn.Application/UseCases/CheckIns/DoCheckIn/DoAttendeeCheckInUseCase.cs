using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.CheckIns.DoCheckIn;

public class DoAttendeeCheckInUseCase
{
    private readonly PassInDbContext _dbContext = new();

    public ResponseRegisteredJson Execute(Guid attendeeId)
    {
        Validate(attendeeId);
        var entity = new CheckIn
        {
            Attendee_Id = attendeeId,
            Created_at = DateTime.UtcNow
        };

        _dbContext.CheckIns.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredJson
        {
            Id = entity.Id
        };
    }

    private void Validate(Guid attendeeId)
    {
        var existAttendee = _dbContext.Attendees.Any(attendee => attendee.Id == attendeeId);
        if (!existAttendee)
            throw new NotFoundException("the attendee with this id was not found.");

        var existCheckin = _dbContext.CheckIns.Any(checkin => checkin.Attendee_Id == attendeeId);
        if (existCheckin)
            throw new ConflictException("Attendee can't do checking twice in the same event.");
    }
}