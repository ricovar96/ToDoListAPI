using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Services
{
    public class ToDoListService
    {
        private readonly ToDoListContext _context;
        private readonly IMapper _mapper;

        public ToDoListService(ToDoListContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoListDTO>> GetAllToDoLists()
        {
            var toDoLists = await _context.ToDoList.ToListAsync();
            return _mapper.Map<IEnumerable<ToDoListDTO>>(toDoLists);
        }

        public async Task<ToDoListDTO> GetToDoListById(int id)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return null;
            }

            return _mapper.Map<ToDoListDTO>(toDoList);
        }

        public async Task<ToDoListDTO> CreateToDoList(ToDoListDTO toDoListDTO)
        {
            var toDoList = _mapper.Map<ToDoList>(toDoListDTO);

            _context.ToDoList.Add(toDoList);
            await _context.SaveChangesAsync();

            return _mapper.Map<ToDoListDTO>(toDoList);
        }

        public async Task<bool> UpdateToDoList(int id, ToDoListDTO toDoListDTO)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);

            if (toDoList == null)
            {
                return false;
            }

            _mapper.Map(toDoListDTO, toDoList);


            _context.ToDoList.Update(toDoList); 

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteToDoList(int id)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return false;
            }

            _context.ToDoList.Remove(toDoList);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
