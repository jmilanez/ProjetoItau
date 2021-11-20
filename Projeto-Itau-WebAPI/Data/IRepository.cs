using System.Threading.Tasks;
using Projeto_Itau_WebAPI.Model;

namespace Projeto_Itau_WebAPI.Data
{
    public interface IRepository
    {
         //GERAL
        void Adicionar<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Deletar<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Contas a Pagar e Receber
        Task<Conta[]> BuscarTodasContasAsync(int tipo);        
        Task<Conta> BuscarContasAsyncById(int contaId);

        //Total Contas Pagar e Receber
        Task<int> TotalContasPagarAsync(int contaPagar);
        Task<int> TotalContasReceberAsync(int contaPagar);
    }
}