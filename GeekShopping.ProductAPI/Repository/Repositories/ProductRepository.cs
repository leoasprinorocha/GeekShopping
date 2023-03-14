using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Models;
using GeekShopping.ProductAPI.Models.Context;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;


        public ProductRepository(IMapper mapper, MySqlContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = _mapper.Map<Product>(await FindById(id));
                if (product is null)
                    return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.AsNoTracking().ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product product = await _context.Products.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
