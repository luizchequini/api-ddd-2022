using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace Domain.Services;

public class ServiceMessage : IServiceMessage
{
    private readonly IMessage _IMessage;

    public ServiceMessage(IMessage IMessage)
    {
        _IMessage = IMessage;
    }

    public async Task ValidateAdd(Message message)
    {
        var validaTitulo = message.ValidadrPropriedadeString(message.Titulo, "Título");
        if (validaTitulo)
        {
            message.DataCadastro = DateTime.Now;
            message.DataAlteracao = DateTime.Now;
            message.Ativo = true;
            await _IMessage.Add(message);
        }
    }

    public async Task<List<Message>> ValidateMessageTrue()
    {
        throw new NotImplementedException();
    }

    public async Task ValidateUpdate(Message message)
    {
        throw new NotImplementedException();
    }
}
