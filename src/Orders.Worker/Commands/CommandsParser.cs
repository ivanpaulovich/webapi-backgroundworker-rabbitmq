namespace Orders.Worker.Commands
{
    public class CommandParser
    {
        private ICommand[] commands;

        public CommandParser()
        {
            commands = new ICommand[]
            {
                new PlaceOrderCommand()
            };
        }

        public ICommand ParseCommand(string[] args)
        {
            foreach (var command in commands)
                if (command.Match(args))
                    return command;

            return new NotHandledCommand();
        }
    }
}