using AutoMapper;
using WebService.DTOs.Brands;
using WebService.Interfaces.Brands;
using WebService.Models;

namespace WebService.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBrandDTO>> GetAllAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetBrandDTO>>(brands);
        }

        public async Task<BrandResponseDTO?> GetByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            return _mapper.Map<BrandResponseDTO>(brand);
        }

        public async Task<BrandResponseDTO?> GetByCodeAsync(string maThuongHieu)
        {
            var brand = await _brandRepository.GetByCodeAsync(maThuongHieu);
            return _mapper.Map<BrandResponseDTO>(brand);
        }

        public async Task<BrandResponseDTO> CreateAsync(CreateBrandDTO brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            brand.NgayTao = DateTime.Now;
            brand.NgayCapNhat = DateTime.Now;

            brand = await _brandRepository.CreateAsync(brand);
            return _mapper.Map<BrandResponseDTO>(brand);
        }

        public async Task UpdateAsync(int id, UpdateBrandDTO brandDto)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                throw new KeyNotFoundException($"Brand with ID {id} not found");

            _mapper.Map(brandDto, brand);
            brand.NgayCapNhat = DateTime.Now;

            await _brandRepository.UpdateAsync(brand);
        }

        public async Task DeleteAsync(int id)
        {
            await _brandRepository.DeleteAsync(id);
        }
    }
}