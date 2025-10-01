using System.Text.Json;
using AutoMapper;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Application.UseCases;

namespace TdlImoveis.Application.UseCases.PostalCode;

public class PostalCodeService : IPostalCodeService
{
    private readonly HttpClient _client;
    private readonly IMapper _mapper;

    public PostalCodeService(HttpClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<ServiceResult<PostalCodeDto>> AddressByPostalCode(PostalCodeRequest postalCode)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(postalCode.PostalCode))
                return ServiceResult<PostalCodeDto>.Fail("CEP digitado inválido");

            var url = $"https://viacep.com.br/ws/{postalCode.PostalCode}/json/";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return ServiceResult<PostalCodeDto>.Fail("Erro ao buscar CEP");

            var content = await response.Content.ReadAsStringAsync();
            var cepData = JsonSerializer.Deserialize<PostalCodeDto>(content);

            if (cepData == null)
                return ServiceResult<PostalCodeDto>.Fail("CEP inválido");
            

            return ServiceResult<PostalCodeDto>.Success(cepData);
        }
        catch (Exception ex)
        {
            return ServiceResult<PostalCodeDto>.Fail($"Erro ao buscar CEP: {ex.Message}");
        }
    }
}