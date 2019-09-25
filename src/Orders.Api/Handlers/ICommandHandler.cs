namespace Orders.Api.Handlers
{
    public interface ICommandHandler<in T>
    {
         void Handle(T command);
    }
}