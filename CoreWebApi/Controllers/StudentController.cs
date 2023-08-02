﻿using CoreWebApi.Models;
using CoreWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/Student
        [HttpGet]
        public IActionResult Get()
        {
            var students = _studentRepository.GetAllStudents();
            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody] StudentModel student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            // Calculate age based on DateOfBirth
            student.Age = CalculateAge(student.DateOfBirth);

            _studentRepository.AddStudent(student);

            return CreatedAtAction(nameof(Get), new { id = student.StudentID }, student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentModel student)
        {
            if (student == null || id != student.StudentID)
            {
                return BadRequest();
            }

            var existingStudent = _studentRepository.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            // Update the existing student properties
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.ContactPerson = student.ContactPerson;
            existingStudent.ContactNo = student.ContactNo;
            existingStudent.EmailAddress = student.EmailAddress;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Age = CalculateAge(student.DateOfBirth);

            _studentRepository.UpdateStudent(existingStudent);

            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentRepository.DeleteStudent(id);

            return NoContent();
        }

        // Helper method to calculate age based on DateOfBirth
        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}