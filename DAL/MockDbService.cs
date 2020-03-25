﻿using Cw4.DAL;
using Cw4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw4.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{IdStudent =1 ,FirstName="Jan",LastName="Kowalski"},
            new Student { IdStudent = 1 ,FirstName="Anna",LastName="Malewska"},
            new Student { IdStudent = 1 ,FirstName="Andrzej",LastName="Andrzejewicz"}

        };

        }


        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}