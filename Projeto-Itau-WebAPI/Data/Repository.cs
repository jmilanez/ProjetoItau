using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Itau_WebAPI.Model;

namespace Projeto_Itau_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Adicionar<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
        }

        public void Deletar<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }

        public async Task<Conta[]> BuscarTodasContasAsync(int tipo)
        {
            if (tipo == 0)
            {
                IQueryable<Conta> query = _dataContext.Contas;
                query = query.AsNoTracking().Where(c => c.Tipo == 0);
                return await query.ToArrayAsync();
            }
            else
            {
                IQueryable<Conta> query = _dataContext.Contas;
                query = query.AsNoTracking().Where(c => c.Tipo == 1);
                return await query.ToArrayAsync();
            }
        }

        public async Task<Conta> BuscarContasAsyncById(/*bool contasReceber, bool contasPagar,*/ int contaId)
        {
            IQueryable<Conta> query = _dataContext.Contas;
            query = query.AsNoTracking().Where(c => c.Id == contaId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> TotalContasPagarAsync(int contaPagar)
        {
            IQueryable<Conta> query = _dataContext.Contas;

            query = query.AsNoTracking().Where(c => c.Tipo == 0);
            return await query.CountAsync();
        }

        public async Task<int> TotalContasReceberAsync(int contaReceber)
        {
            IQueryable<Conta> query = _dataContext.Contas;

            query = query.AsNoTracking().Where(c => c.Tipo == 1);
            return await query.CountAsync();

        }
    }
}