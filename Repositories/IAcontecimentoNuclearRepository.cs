using RegistraNuclearTech.Models;

namespace RegistraNuclearTech.Repositories
{
    public interface IAcontecimentoNuclearRepository
    {
        IEnumerable<AcontecimentoNuclear> ListarTodos();
        AcontecimentoNuclear? BuscarAcontecimentoPorId(int id);
        IEnumerable<AcontecimentoNuclear> BuscarPorPais(string pais);
        AcontecimentoNuclear Criar(AcontecimentoNuclear acontecimento);
        AcontecimentoNuclear? Atualizar(AcontecimentoNuclear acontecimento);
        bool Apagar(int id);
    }
}
