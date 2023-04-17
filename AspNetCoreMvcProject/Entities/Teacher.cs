﻿namespace AspNetCoreMvcSample.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
