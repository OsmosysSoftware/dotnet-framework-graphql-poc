using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http;
using Dapper;
using MySqlConnector;

namespace DAL.GraphQL
{
    public class TaskRepository : Interface.ITaskRepository
    {
        public TaskRepository()
        {

        }
        public IEnumerable<TaskDetails> GetAll()
        {
            var connectionString = "Server=xxx;database=xxx;Uid=xxx;Pwd=xxx;Port=3306;SslMode=none";

            using (var db = new MySqlConnection(connectionString))
            {
                var result = db.Query<TaskDetails>("SELECT * FROM task_details limit 1000").ToList();
                return result;
            }
        }
        /* 
        public IEnumerable<TaskDetails> GetAll()
        {
          string baseURL = "http://14.99.203.50:9010/api/";
            HttpClient client = new HttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "UserName", "chandana.k@osmosys.co" },
                { "Password", "LuvPineStem" }
            };
            HttpContent content = new FormUrlEncodedContent(parameters);
            HttpResponseMessage res = client.PostAsync(new Uri(baseURL + "Users/AuthenticateUser"), content).Result;
            string jsonRes = res.Content.ReadAsStringAsync().Result;
            AuthResponse authDetails = JsonConvert.DeserializeObject<AuthResponse>(jsonRes);

            client.DefaultRequestHeaders.Add("AuthenticationToken", authDetails.MultipleResults[0].TokenId);
            client.DefaultRequestHeaders.Add("CompanyID", authDetails.MultipleResults[0].CompanyID);
            HttpResponseMessage response = client.GetAsync(baseURL + "Tasks/Filter?ExcludeInformTo=true&PageLimit=10&PageNumber=1&Pagination=true&ProjectCode=INR&SearchTerm=&SortingColumn=TaskName&SortingOrder=asc&TaskStatusID=1824").Result;
            if (response.IsSuccessStatusCode)
            {
                // Read the content as a string
                string jsonString = response.Content.ReadAsStringAsync().Result;

                // Deserialize the JSON content to your model
                ApiResponse taskDetailsList = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
                return taskDetailsList.MultipleResults;
            }
            else
            {
                // Handle the error, e.g., log it or throw an exception
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }*/

        public TaskDetails GetById(int id)
        {
            return new TaskDetails
            {
                TaskID = 1,
                TaskName = "1101",
                ProjectCode = "Stenhagen"
            };
        }
    }
}
