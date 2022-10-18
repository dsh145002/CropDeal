using CaseStudy.Dtos;
using CaseStudy.Models;
using CaseStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Services
{
    public class CropService
    {
        ICropRepository _repo;
        public CropService(ICropRepository repository)
        {
            _repo = repository;
        }

        public async Task<ActionResult<CropDetail>> AddCropAsync(AddCropDto newCrop, int fid)
        {
            return await _repo.AddCropAsync(newCrop,fid);
        }

        public async Task<IEnumerable<CropDetail>> GetAllCropAsync()
        {
            return await _repo.GetAllCropAsync();
        }

        public async Task<ActionResult<CropDetail>> GetCropByIdAsync(int id)
        {
            return await _repo.GetCropByIdAsync(id);
        }
    }
}
