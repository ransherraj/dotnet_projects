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
    public class Response
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        
            
       
    }
}
