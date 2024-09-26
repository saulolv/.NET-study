using MinimalApi.Domain.Dtos;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Interfaces;

public interface IAdminService
{
    Admin? Login(LoginDto loginDto);
}