using Microsoft.EntityFrameworkCore; // Importa o Entity Framework Core para operações de acesso a dados
using EnergyX.Data; // Importa o contexto de dados da aplicação
using System.Collections.Generic; // Importa o namespace para usar a coleção IEnumerable
using System.Threading.Tasks; // Importa o namespace para suportar operações assíncronas

// Definição da interface genérica IRepository
public interface IRepository<T> where T : class
{
    // Método para obter todos os registros do tipo T
    Task<IEnumerable<T>> GetAllAsync();

    // Método para obter um registro específico pelo ID
    Task<T> GetByIdAsync(int id);

    // Método para adicionar um novo registro do tipo T
    Task<T> AddAsync(T entity);

    // Método para atualizar um registro existente do tipo T
    Task UpdateAsync(T entity);

    // Método para excluir um registro do tipo T pelo ID
    Task DeleteAsync(int id);
}
