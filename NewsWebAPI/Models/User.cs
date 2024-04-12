using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FirstAPI.Models;
using Newtonsoft.Json;

namespace FirstAPI.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string? Name { get; set; }

        internal static void add(User news)
        {
            throw new NotImplementedException();
        }
    }
}
