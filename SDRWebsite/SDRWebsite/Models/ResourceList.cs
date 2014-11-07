using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDRWebsite.Models
{
    public class ResourceList
    {
        public IEnumerable<FileDTO> TenantFiles { get; set; }
        public IEnumerable<FileDTO> OwnerFiles { get; set; }
    }
    public class FileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}