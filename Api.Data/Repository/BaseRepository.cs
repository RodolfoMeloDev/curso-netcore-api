using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _dataSet.SingleOrDefaultAsync(obj => obj.Id.Equals(id));

            if (result == null)
            {
                return false;
            }

            _dataSet.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;

                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(obj => obj.Id.Equals(id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                // verifica se o item já existe na base de dados para atualização
                var result = await _dataSet.SingleOrDefaultAsync(obj => obj.Id.Equals(item.Id));

                if (result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                // garante que a data de criação não será alterada
                item.CreateAt = result.CreateAt;

                // acho q assim daria certo, testar se funciona
                //_dataSet.Update(item);

                // forma de atualização realizada no curso
                _context.Entry(result).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(obj => obj.Id.Equals(id));
        }
    }
}
