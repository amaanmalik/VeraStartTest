using VeraStartTest.Data.Entities;

namespace VeraStartTest.Services
{
    public interface IFileUploadService
    {
        void UploadCustomerFile(IFormFile file);

        void UploadOrderFile(IFormFile file);

        void UploadOrderItemFile(IFormFile file);
    }
}
