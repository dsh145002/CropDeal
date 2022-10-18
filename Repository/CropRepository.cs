using CaseStudy.Dtos;
using CaseStudy.Models;
using CaseStudy.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CaseStudy.Repository
{
    public class CropRepository : ICropRepository
    {
        DatabaseContext _context;
        public CropRepository(DatabaseContext context)
        {
            _context = context;
        }

        private enum CropId
        {
            Fruit = 1,
            Vegetable = 2,
            Grain = 3
        }

        public async Task<ActionResult<CropDetail>> AddCropAsync(AddCropDto crop, int fid)
        {
            try
            {
                CropDetail cropDetail = new CropDetail();
                cropDetail.CropName = crop.CropName;
                cropDetail.QtyAvailable = crop.CropQtyAvailable;
                cropDetail.Location = crop.CropLocation;
                cropDetail.ExpectedPrice = crop.CropExpectedPrice;
                cropDetail.FarmerId = fid;

                cropDetail.CropTypeId = (int)Enum.Parse(typeof(CropId), crop.CropType);

                _context.CropDetails.Add(cropDetail);
                await _context.SaveChangesAsync();
                return cropDetail;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while adding crop");
            }
            return null;
        }

        public async Task<IEnumerable<CropDetail>> GetAllCropAsync()
        {
            var cropList = await _context.CropDetails.ToListAsync();
            if(cropList.Count > 0)
            {
                return cropList;
            }
            return null;
        }

        public async Task<ActionResult<CropDetail>> GetCropByIdAsync(int id)
        {
            var crop = await  _context.CropDetails.FirstOrDefaultAsync(x => x.CropId == id);
            if(crop != null)
            {
                return crop;
            }

            return null;
        }
    }
}
