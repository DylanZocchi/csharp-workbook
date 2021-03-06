﻿using System;
using System.Threading;
using SimpleHttp;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace WebServer
{
    class Program
    {
        static SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
        
        static void Main()
        {
            connectionStringBuilder.DataSource = "./database.db";

            Route.Add("/", (request, response, args) => {
                response.AsText("Hello, World!");
            }, "GET");


            //ITEMS
            Route.Add("/items", (request, response, args) => {
                response.AsText(getItems());
            }, "GET");

            Route.Add("/items", (request, response, args) => {
                request.ParseBody(args);
                RunQuery($@"
                    INSERT into items (name, price, container_id)
                    VALUES ('{args["name"]}', '{args["price"]}', {args["container_id"]});
                ");
                response.AsText(getItems());
            }, "POST");



            //CONTAINERS
            Route.Add("/containers", (request, response, args) => {
                response.AsText(getContainers());
            }, "GET");

            Route.Add("/containers", (request, response, args) => {
                request.ParseBody(args);
                RunQuery($@"
                    INSERT into containers (name, location)
                    VALUES ('{args["name"]}', '{args["location"]});
                ");
                response.AsText(getContainers());
            }, "POST");

            //WAREHOUSES
            Route.Add("/warehouses", (request, response, args) => {
                response.AsText(getWarehouses());
            }, "GET");

            Route.Add("/warehouses", (request, response, args) => {
                request.ParseBody(args);
                RunQuery($@"
                    INSERT into containers (name, location)
                    VALUES ('{args["name"]}', '{args["location"]});
                ");
                response.AsText(getWarehouses());
            }, "POST");

            //run the server
            int port = 8000;
            Console.WriteLine($"Running Server On http://127.0.0.1:{port}");
            HttpServer.ListenAsync(port, CancellationToken.None, Route.OnHttpRequestAsync).Wait();
        }

        static string getItems()
        {
            var results = RunQuery($@"  
                SELECT *
                FROM items;
            ");
            string html = PrintResults(results);
            html += @"
                <br/><br/>
                <form method='POST' action='/items'>
                    <label>Name
                    <input name='name' />
                    </label>
                    <label>Price
                    <input name='price' />
                    </label>
                    <label>Container
                    <select name='container_id'>
                        <option value='1'>Austin-1</option>
                        <option value='2'>San Antonio-1</option>
                        <option value='3'>Houston-1</option>
                        <option value='4'>Dallas-1</option>
                    </select>
                    </label>
                    <input type='submit' value='Submit' />
                </form>
            ";
            return html;
        }

        static string getContainers()
        {
            var results = RunQuery($@"  
                SELECT *
                FROM containers;
            ");
            string html = PrintResults(results);
            html += @"
                <br/><br/>
                <form method='POST' action='/items'>
                    <label>Name
                    <input name='name' />
                    </label>
                    <label>ID
                    <input name='ID' />
                    </label>
                    <label>Container
                    <select name='Warehouse'>
                        <option value='1'>Austin-1</option>
                        <option value='2'>San Antonio-1</option>
                        <option value='3'>Houston-1</option>
                        <option value='4'>Dallas-1</option>
                    </select>
                    </label>
                    <input type='submit' value='Submit' />
                </form>
            ";
            return html;
        }

        static string getWarehouses()
        {
            var results = RunQuery($@"  
                SELECT *
                FROM warehouses;
            ");
            string html = PrintResults(results);
            html += @"
                <br/><br/>
                <form method='POST' action='/items'>
                    <label>Name
                    <input name='name' />
                    </label>
                    <label>ID
                    <input name='ID' />
                    </label>
                    <label>Company
                    <select name='Company'>
                        <option value='1'>Rainforest</option>
                        
                    </select>
                    </label>
                    <input type='submit' value='Submit' />
                </form>
            ";
            return html;
        }



        static List<Dictionary<string, string>> RunQuery(string query)
        {
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = query;
                SqliteDataReader reader = selectCmd.ExecuteReader();
                List<Dictionary<string, string>> results = getResults(reader);
                reader.Close();
                connection.Close();
                return results;
            }
        }

        static List<Dictionary<string, string>> getResults(SqliteDataReader reader)
        {
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            int row = 0;
            while (reader.Read()){
                results.Add(new Dictionary<string, string>());
                for (var column = 0; column < reader.FieldCount; column++)
                {
                    results[row].Add(reader.GetName(column), reader.GetString(column));
                }
                row++;
            }
            return results;
        }

        static string PrintResults(List<Dictionary<string, string>> results)
        {
            string resultsString = "";
            foreach (var result in results)
            {
                System.Collections.Generic.IEnumerable<string> lines = result.Select(kvp => kvp.Key + ": " + kvp.Value);
                resultsString += String.Join(Environment.NewLine, lines);
            }
            return resultsString;
        }
    }
}
//toggle between ports when error message 8000/8001
//watch vid to add html
//reference video at 73:30 to insert items
