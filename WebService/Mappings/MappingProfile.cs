using AutoMapper;
using WebService.DTOs.Products;
using WebService.DTOs.Categories;
using WebService.DTOs.Brands;
using WebService.DTOs.ProductImages;
using WebService.DTOs.Users;
using WebService.Models;

namespace WebService.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductDTO>()
            .ForMember(dest => dest.HinhAnh, opt => opt.MapFrom(src => src.HinhAnh));
            CreateMap<Product, ProductResponseDTO>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();

            CreateMap<ProductImage, ProductImageInProductDTO>();
            CreateMap<ProductImage, WebService.DTOs.ProductImages.ProductImageDTO>();
            CreateMap<CreateProductImageDTO, ProductImage>();
            CreateMap<UpdateProductImageDTO, ProductImage>()
            .ForMember(dest => dest.MaSanPham, opt => opt.Ignore())
            .ForMember(dest => dest.DuongDan, opt => opt.Ignore());
            CreateMap<ProductImage, WebService.DTOs.Products.ProductImageDTO>();

            CreateMap<Brand, GetBrandDTO>();
            CreateMap<Brand, BrandResponseDTO>();
            CreateMap<CreateBrandDTO, Brand>();
            CreateMap<UpdateBrandDTO, Brand>()
            .ForMember(dest => dest.MaThuongHieu, opt => opt.Ignore());

            CreateMap<Category, GetCategoryDTO>();
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>()
            .ForMember(dest => dest.MaDanhMuc, opt => opt.Ignore());

            CreateMap<User, GetUserDTO>();
            CreateMap<User, UserResponseDTO>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.Ignore());
            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.NgayTao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.NgayCapNhat, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateUserDTO, User>()
                .ForMember(dest => dest.NgayCapNhat, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.TenDangNhap, opt => opt.Ignore())
                .ForMember(dest => dest.MatKhau, opt => opt.Ignore())
                .ForMember(dest => dest.NgayTao, opt => opt.Ignore());
        }
    }
}