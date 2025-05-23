﻿using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
