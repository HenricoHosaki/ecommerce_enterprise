using EnterpriseGateway.Api.Domain.Enums;

namespace EnterpriseGateway.Api.Domain.Entities;

public class OutboxMessage
{
    public Guid Id {get; private set;}
    public string EventType {get; set;}
    public string Payload {get; set;}
    public DateTime CreatedAt {get; set;}
    public OutboxMessageStatus Status {get; set;}
    public int RetryCount {get; set;}
    public DateTime ProcessedAt {get; set;}

    public OutboxMessage(Guid id, string eventType, string payload, DateTime createdAt, OutboxMessageStatus status, int retryCount, DateTime processedAt)
    {
        Id = id;
        EventType = eventType;
        Payload = payload;
        CreatedAt = createdAt;
        Status = status;
        RetryCount = retryCount;
        ProcessedAt = processedAt;
    }
}