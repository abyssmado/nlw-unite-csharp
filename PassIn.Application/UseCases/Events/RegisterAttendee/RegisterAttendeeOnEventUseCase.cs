using System.Net.Mail;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.RegisterAttendee;

public class RegisterAttendeeOnEventUseCase
{
    private readonly PassInDbContext _dbContext = new();

    public ResponseRegisteredJson Execute(Guid eventId, RequestRegisterEventJson request)
    {
        Validate(eventId, request);


        var entity = new Infrastructure.Entities.Attendee
        {
            Email = request.Email,
            Name = request.Name,
            Event_Id = eventId,
            Created_at = DateTime.UtcNow
        };

        _dbContext.Attendees.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredJson
        {
            Id = entity.Id
        };
    }

    private void Validate(Guid eventId, RequestRegisterEventJson request)
    {
        var eventEntity = _dbContext.Events.Find(eventId);
        if (eventEntity is null)
            throw new NotFoundException("An event with this id doesn't exist.");

        if (string.IsNullOrWhiteSpace(request.Name)) throw new ErrorOnValidationException("The name is invalid.");


        if (EmailIsValid(request.Email) == false) throw new ErrorOnValidationException("The e-mail is invalid.");

        var attendeeAlreadyRegistered = _dbContext.Attendees.Any(attendee =>
            attendee.Email.Equals(request.Email) && attendee.Event_Id == eventId);

        if (attendeeAlreadyRegistered) throw new ConflictException("You can't register twice on the same event.");

        var numberOfAttendees = _dbContext.Attendees.Count(attendee => attendee.Event_Id == eventId);
        if (numberOfAttendees == eventEntity.Maximum_Attendees)
            throw new ErrorOnValidationException("There's no room for this event.");
    }

    private bool EmailIsValid(string email)
    {
        try
        {
            new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}