﻿using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DapperDepartmentRepository(conn);


            var departments = departmentRepo.GetAllDepartments();

            foreach (var deparatment in departments)
            {
                Console.WriteLine(deparatment.DepartmentID);
                Console.WriteLine(deparatment.Name);
                Console.WriteLine("\n\n");

            }

        }//Main Method


    }//Class
}//namespace ORM_Dapper
