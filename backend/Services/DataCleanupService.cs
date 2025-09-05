using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class DataCleanupService
    {
        private readonly ApplicationDbContext _context;

        public DataCleanupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CleanupInvalidProductReferencesAsync()
        {
            // Remove CampaignEligibleProducts with invalid CampaignProductIds
            var invalidEligibleProducts = await _context.CampaignEligibleProducts
                .Where(cep => !_context.Products.Any(p => p.Id == cep.CampaignProductId))
                .ToListAsync();

            if (invalidEligibleProducts.Any())
            {
                Console.WriteLine($"Removing {invalidEligibleProducts.Count} CampaignEligibleProducts with invalid CampaignProductIds");
                _context.CampaignEligibleProducts.RemoveRange(invalidEligibleProducts);
            }

            // Remove CampaignVoucherProducts with invalid ProductIds
            var invalidVoucherProducts = await _context.CampaignVoucherProducts
                .Where(cvp => !_context.Products.Any(p => p.Id == cvp.ProductId))
                .ToListAsync();

            if (invalidVoucherProducts.Any())
            {
                Console.WriteLine($"Removing {invalidVoucherProducts.Count} CampaignVoucherProducts with invalid ProductIds");
                _context.CampaignVoucherProducts.RemoveRange(invalidVoucherProducts);
            }

            // Remove CampaignFreeProductRewards with invalid ProductIds
            var invalidFreeProductRewards = await _context.CampaignFreeProductRewards
                .Where(cfr => !_context.Products.Any(p => p.Id == cfr.ProductId))
                .ToListAsync();

            if (invalidFreeProductRewards.Any())
            {
                Console.WriteLine($"Removing {invalidFreeProductRewards.Count} CampaignFreeProductRewards with invalid ProductIds");
                _context.CampaignFreeProductRewards.RemoveRange(invalidFreeProductRewards);
            }

            // Remove TempOrderPointsItems with invalid ProductIds
            var invalidOrderItems = await _context.TempOrderPointsItems
                .Where(topi => !_context.Products.Any(p => p.Id == topi.ProductId))
                .ToListAsync();

            if (invalidOrderItems.Any())
            {
                Console.WriteLine($"Removing {invalidOrderItems.Count} TempOrderPointsItems with invalid ProductIds");
                _context.TempOrderPointsItems.RemoveRange(invalidOrderItems);
            }

            await _context.SaveChangesAsync();
            Console.WriteLine("Data cleanup completed successfully");
        }
    }
}