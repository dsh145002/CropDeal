using CaseStudy.Dtos;
using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Repository
{
    public interface IRegisterRepository
    {
        Task<ActionResult<User>> CreateUserAsync(CreateUserDto user);
    }
}
