using CaseStudy.Dtos;
using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Repository
{
    public interface ICropRepository
    {
        Task<ActionResult<CropDetail>> AddCropAsync(AddCropDto crop,int fid);
        Task<IEnumerable<CropDetail>> GetAllCropAsync();
        Task<ActionResult<CropDetail>> GetCropByIdAsync(int id);

    }
}
