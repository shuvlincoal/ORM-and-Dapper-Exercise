using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Collections;
using System.Collections.Generic;
using System.Text;


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

            //Class  <==> table
            //Colums <==> properties


            //---------------------------------------------
            //EXERCISE #1
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("A Dive into Object Relational Mapper (ORM) using NuGet Pkg: DAPPER Exercise #1> ");
            Console.WriteLine("Press return to begin ORM-DAPPER Exercise #1");
            Console.ReadLine();
            var departmentRepo = new DapperDepartmentRepository(conn);
            var departments = departmentRepo.GetAllDepartments();


            Console.WriteLine("Display all \"Departments\" from the \"departments\" table \"bestbuy\" schema from MySql DB> ");
            foreach (var department in departments)
            {
                Console.WriteLine($"Dept: {department.DepartmentID}, Name: {department.Name} " );
                //Console.WriteLine("\n");
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Press return to continue for Exercise #2> ");
            Console.WriteLine("Display all products from the \"product\" table in \"bestbuy\" schema from MySql DB> ");

            Console.ReadLine();


            //Do NOT comment this line
            var productRepository = new DapperProductRepository(conn);



            //---------Vid 12:10------------------------------
            //BONUS
            var productToUpdate = productRepository.GetProduct(946);
            productToUpdate.Name       = "UPDATED!!!";
            productToUpdate.Price      = 1000;
            productToUpdate.CategoryID = 1;
            productToUpdate.OnSale     = false;
            productToUpdate.StockLevel = 2;

            productRepository.UpdateProduct(productToUpdate);



            //------------------------------str.Substring(indx,5)
            //EXERCISE #2
            var products = productRepository.GetAllProducts();
            int i = 0;
            Console.WriteLine("\n\n\n\n\n");
            foreach (var product in products)
            {
                Console.WriteLine($"ProductID: {product.ProductID}, \tName:{product.Name}, \t\t\tPrice:{product.Price}, \tCategoryID:{product.CategoryID}, \tOnSale:{product.OnSale}, \tStockLevel{product.StockLevel}");
                //Console.WriteLine($"ProductID: {product.ProductID}, \tName:{(product.Name).Substring(0, 5)}, \t\t\tPrice:{product.Price}, \tCategoryID:{product.CategoryID}, \tOnSale:{product.OnSale}, \tStockLevel{product.StockLevel}");                
                //Console.WriteLine(product.Name);
                //Console.WriteLine(product.Price);
                //Console.WriteLine(product.CategoryID);
                //Console.WriteLine(product.OnSale);
                //Console.WriteLine(product.StockLevel);
                i++;
                if (i >20)
                { 
                    i = 0;
                    Console.WriteLine("Press return to continue> ");
                    Console.ReadLine();
                }
            }



        }//Main Method


    }//Class
}//namespace ORM_Dapper
