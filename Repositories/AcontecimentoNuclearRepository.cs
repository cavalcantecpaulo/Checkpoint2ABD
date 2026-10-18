using RegistraNuclearTech.Models;

namespace RegistraNuclearTech.Repositories
{
    public class AcontecimentoNuclearRepository : IAcontecimentoNuclearRepository
    {
        private static readonly List<AcontecimentoNuclear> _acontecimentos = [];
        private static int idAtual = 1;
        public IEnumerable<AcontecimentoNuclear> ListarTodos() => _acontecimentos;

        public AcontecimentoNuclear? BuscarAcontecimentoPorId(int id) => _acontecimentos.FirstOrDefault(a => a.Id == id);

        public AcontecimentoNuclear Criar(AcontecimentoNuclear acontecimento)
        {
            acontecimento.Id = idAtual++;
            acontecimento.DataRegistro = DateTime.Now;
            _acontecimentos.Add(acontecimento);
            return acontecimento;
        }

        public bool Apagar(int id)
        {
            AcontecimentoNuclear? acontecimento = BuscarAcontecimentoPorId(id);
            if(acontecimento == null)
            {
                return false;
            }
            return _acontecimentos.Remove(acontecimento);
        }

        public AcontecimentoNuclear? Atualizar(AcontecimentoNuclear acontecimento)
        {
            var encontrado = _acontecimentos.FindIndex(a => a.Id == acontecimento.Id);
            if(encontrado == -1)
            {
                return null;
            }

            acontecimento.DataRegistro = _acontecimentos[encontrado].DataRegistro;

            _acontecimentos[encontrado] = acontecimento;
            return acontecimento;
        }

        public IEnumerable<AcontecimentoNuclear> BuscarPorPais(string pais)
        {
            if (string.IsNullOrEmpty(pais))
                return [];

            return _acontecimentos.Where(a => a.Pais.Contains(pais, StringComparison.OrdinalIgnoreCase));
        } 
    }
}
