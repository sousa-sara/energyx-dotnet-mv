using EnergyX.DTOs;
using OdontoFast.Exceptions;
using EnergyX.Repositories.Interfaces;
using AutoMapper;
using EnergyX.Models;

namespace EnergyX.Services
{
    public class OperadoresService : IOperadoresService
    {
        private readonly IOperadoresRepository _operadorRepository;
        private readonly IMapper _mapper;

        public OperadoresService(IOperadoresRepository operadorRepository, IMapper mapper)
        {
            _operadorRepository = operadorRepository;
            _mapper = mapper;
        }

        public async Task<OperadoresDto> CreateOperadoresAsync(CreateOperadoresDto dto)
        {
            // Validações dos campos obrigatórios
            if (string.IsNullOrWhiteSpace(dto.NomeOperador))
                throw new BusinessException("O nome do operador é obrigatório.");

            if (string.IsNullOrWhiteSpace(dto.SenhaOperador))
                throw new BusinessException("A senha é obrigatória.");

            if (string.IsNullOrWhiteSpace(dto.Cargo))
                throw new BusinessException("O cargo é obrigatório.");

            if (string.IsNullOrWhiteSpace(dto.Lor))
                throw new BusinessException("O LOR é obrigatório.");

            // Validação de comprimento
            if (dto.NomeOperador.Length > 50)
                throw new BusinessException("O nome do operador não pode exceder 50 caracteres.");

            if (dto.Cargo.Length > 50)
                throw new BusinessException("O cargo não pode exceder 50 caracteres.");

            if (dto.Lor.Length > 20)
                throw new BusinessException("O LOR não pode exceder 20 caracteres.");

            // Verifica se já existe um operador com o mesmo LOR
            if (await _operadorRepository.GetByLorAsync(dto.Lor) != null)
                throw new BusinessException("Já existe um operador cadastrado com esse LOR.");

            // Verificação da complexidade da senha
            if (dto.SenhaOperador.Length < 8 || !dto.SenhaOperador.Any(char.IsDigit) || !dto.SenhaOperador.Any(char.IsLetter))
                throw new BusinessException("A senha deve ter pelo menos 8 caracteres, incluindo letras e números.");

            // Mapeia o DTO para a entidade Operador
            var operador = _mapper.Map<Operadores>(dto);

            // Adiciona o operador ao repositório
            await _operadorRepository.AddAsync(operador);

            // Retorna o DTO do operador criado
            return _mapper.Map<OperadoresDto>(operador);
        }


        public async Task<OperadoresDto> GetOperadorByLorAsync(string lor)
        {
            var operador = await _operadorRepository.GetByLorAsync(lor);
            if (operador == null)
                throw new NotFoundException("Operador não encontrado.");

            return _mapper.Map<OperadoresDto>(operador);
        }

        public async Task<IEnumerable<OperadoresDto>> GetAllOperadoresAsync(int pageNumber, int pageSize)
        {
            // Aguarda a resolução da Task para obter a lista de operadores
            var operadores = await _operadorRepository.GetAllAsync();

            // Aplica a paginação
            return operadores.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(o => _mapper.Map<OperadoresDto>(o));
        }

        public async Task<OperadoresDto> LoginAsync(OperadorLoginDto loginDto)
        {
            var operador = await _operadorRepository.GetByLorAsync(loginDto.Lor);
            if (operador == null || operador.SenhaOperador != loginDto.SenhaOperador)
                throw new BusinessException("Credenciais inválidas.");

            return new OperadoresDto
            {
                OperadorId = operador.OperadorId,
                Lor = operador.Lor,
                NomeOperador = operador.NomeOperador,
                Cargo = operador.Cargo
            };
        }

    }
}
