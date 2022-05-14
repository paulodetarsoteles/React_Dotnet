using back.src.ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.Domain.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepo _atividadeRepo;
        private readonly IGeralRepo _geralRepo;
        public AtividadeService(IAtividadeRepo atividadeRepo, IGeralRepo geralRepo)
        {
            _geralRepo = geralRepo;
            _atividadeRepo = atividadeRepo;
        }
        public Task<Atividade> AdicionarAtividade(Atividade model)
        {
            throw new NotImplementedException();
        }

        public Task<Atividade> AtualizarAtividade(Atividade model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConcluirAtividade(Atividade model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAtividade(int atividadeId)
        {
            throw new NotImplementedException();
        }

        public Task<Atividade> PegarAtividadePorIdAsync(int atividadeId)
        {
            throw new NotImplementedException();
        }

        public Task<Atividade[]> PegarTodasAtividadesAsync()
        {
            throw new NotImplementedException();
        }
    }
}