using MediatR;

namespace AWS_Serverless_StorageApplication.Commands.ObjectCommands
{
    public class DeleteObjectCommand : IRequest<string>
    {
        public string Name { get; set; } = string.Empty;

        public DeleteObjectCommand(string name)
        {
            Name = name;
        }
    }
}
