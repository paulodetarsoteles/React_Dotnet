using back.src.ProAtividade.Domain.Entities;

namespace ProAtividade.Domain.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task<Atividade> AdicionarAtividade(Atividade model); 
        Task<Atividade[]> PegarTodasAtividadesAsync(); 
        Task<Atividade> PegarAtividadePorIdAsync(int atividadeId); 
        Task<Atividade> AtualizarAtividade(Atividade model); 
        Task<bool> ConcluirAtividade(Atividade model); 
        Task<bool> DeletarAtividade(int atividadeId); 
    }
}