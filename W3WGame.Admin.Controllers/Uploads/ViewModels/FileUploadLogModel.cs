using System;

namespace W3WGame.Admin.Controllers.Uploads.ViewModels
{
    public class FileUploadLogModel
    {
        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public string FileName { get; set; }
    }
}