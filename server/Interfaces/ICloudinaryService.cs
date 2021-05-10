using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using CloudinaryDotNet.Actions;

namespace server.Interfaces
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> AddImageAsync(IFormFile file);

        Task<DeletionResult> DeleteImageAsync(string piblicId);
    }
}