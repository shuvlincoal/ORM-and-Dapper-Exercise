﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


//Class  <==> table
//Colums <==> properties

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {

        private readonly IDbConnection _conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments");
        }

        public void InsertDepartment(string name)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@name)", new { name = name } );
            //Parameterized Statement, Anonymouns Type (place holders) <==> Temporary Object to safely pass in parameters
        }

    }//class
}//namespace
