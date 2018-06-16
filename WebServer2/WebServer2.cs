using System;
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
        static string style = @"
            <style>
                .items {
                    display: flex;
                    flex-wrap: wrap;
                }
                .item {
                    min-width: 200px;
                    padding: 10px;
                    background-color: aliceblue;
                    margin: 10px;
                }
            </style>
        ";
        
        static void Main()
        {
            connectionStringBuilder.DataSource = "./database.db";


            //MAIN
            Route.Add("/", (request, response, args) => {
                response.AsText("Hello, World!");
            }, "GET");




            //ITEMS
            Route.Add("/items", (request, response, args) => {
                response.AsText($"{style}{getItems()}");
            }, "GET");

            Route.Add("/items", (request, response, args) => {
                request.ParseBody(args);
                RunQuery($@"
                    INSERT into items (name, price, container_id)
                    VALUES ('{args["name"]}', '{args["price"]}', {args["container_id"]});
                ");
                response.AsText($"{style}{getItems()}");
            }, "POST");


            //CONTAINERS
            Route.Add("/containers", (request, response, args) => {
                response.AsText($"{style}{getContainers()}");
            }, "GET");

            Route.Add("/containers", (request, response, args) => {
                request.ParseBody(args);
                RunQuery($@"
                    INSERT into containers (name, warehouse_id)
                    VALUES ('{args["name"]}', {args["warehouse_id"]});
                ");
                response.AsText($"{style}{getContainers()}");
            }, "POST");

            //WAREHOUSES
            Route.Add("/warehouses", (request, response, args) => {
                response.AsText($"{style}{getWarehouses()}");
            }, "GET");

            Route.Add("/warehouses", (request, response, args) => {
                request.ParseBody(args);
                RunQuery($@"
                    INSERT into warehouses (company_id, location)
                    VALUES ('{args["company_id"]}', '{args["location"]}');
                ");
                response.AsText($"{style}{getWarehouses()}");
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
            string html = $@"
                <div class='items'>
                    <div class='item'>{String.Join("</div><br /><div class='item'>", PrintResults(results).Split('\n'))}</div>
                </div>
            ";
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
        string html = $@"
                <div class='items'>
                    <div class='item'>{String.Join("</div><br /><div class='item'>", PrintResults(results).Split('\n'))}</div>
                </div>
            ";
            html += @"
                <br/><br/>
                <form method='POST' action='/containers'>
                    <label>Name
                    <input name='name' />
                    </label>
                    <label>Warehouse
                    <select name='warehouse_id'>
                        <option value='1'>1</option>
                        <option value='2'>2</option>
                        <option value='3'>3</option>
                        <option value='4'>4</option>
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
            string html = $@"
            <div class='items'>
            <div class='item'>{String.Join("</div><br /><div class='item'>", PrintResults(results).Split('\n'))}</div>
            </div>
            ";
            html += @"
                <br/><br/>
                <form method='POST' action='/warehouses'>
                    <label>ID
                    <input name='company_id' />
                    </label>
 
                    <label>Location
                    <select name='location'>
                        <option value='1'>Austin</option>
                        <option value='2'>San Antonio</option>
                        <option value='3'>Houston</option>
                        <option value='4'>Dallas</option>
                        
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
                resultsString += $"{String.Join("<br/>", lines)}\n";
            }
            return resultsString;
        }
    }
}