using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public class PointService
    {
        private readonly DataContext _dataContext;

        public PointService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PointModel> GetByIdAsync(int id)
        {
            var todo = await _dataContext.Points.FindAsync(id);
            if (todo == null)
            {
                throw new ArgumentException("Todo not found");
            }

            return todo;
        }

        public async Task RemoveAsync(int id)
        {
            var todo = await GetByIdAsync(id);

            _dataContext.Points.Remove(todo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(CreatePoint createTodo)
        {
            var doesNameExist = _dataContext.Points.Select(x => x.Name).Contains(createTodo.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The name already exists");
            }

            var model = new PointModel()
            {
                Name = createTodo.Name
            };

            _dataContext.Points.Add(model);
            await _dataContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task UpdateAsync(int id, UpdatePoint updateTodo)
        {

            var todo = await GetByIdAsync(id);

            var doesNameExist = await _dataContext.Points.AnyAsync(x => x.Name == updateTodo.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The name already exists");
            }

            todo.Name = updateTodo.Name;

            await _dataContext.SaveChangesAsync();
        }
    }
}
