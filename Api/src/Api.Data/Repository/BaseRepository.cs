using System;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Api.Data.Entities
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> _list;

        public BaseRepository()
        {
            _list = JsonConvert.DeserializeObject<IEnumerable<T>>(File.ReadAllText("..\\Api.Data\\data.json"));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _list = _list.Where(i => i.Id != id).ToList();
                SaveFile(_list);
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                var lastData = _list.OrderByDescending(i => i.Id).FirstOrDefault();
                var nextId = 1;
                if (lastData != null)
                {
                    nextId = lastData.Id + 1;
                }

                var lista = _list.ToList();
                entity.Id = nextId;
                lista.Add(entity);
                SaveFile(lista);
                return await Task.FromResult(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<T> SelectAsync(int id)
        {
            try
            {
                return Task.FromResult(_list.FirstOrDefault(i => i.Id == id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return Task.FromResult(_list);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var lista = _list.ToList();
                var user = lista.FirstOrDefault(i => i.Id == entity.Id);

                if (user == null)
                {
                    return null;
                }

                var position = lista.IndexOf(user);
                lista.Insert(position, entity);
                lista.Remove(user);
                SaveFile(lista);
                return await Task.FromResult(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SaveFile(IEnumerable<T> lista)
        {
            var json = JsonConvert.SerializeObject(lista.ToArray());
            System.IO.File.WriteAllText("..\\Api.Data\\data.json", json);
        }
    }
}