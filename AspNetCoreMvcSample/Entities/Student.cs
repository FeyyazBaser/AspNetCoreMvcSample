using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCoreMvcSample.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }    
        public string? LastName { get; set; }
      
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }        
        public string? Phone { get; set; }
        public Teacher Teacher { get; set; }


    }
}
