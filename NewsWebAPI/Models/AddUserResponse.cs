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

namespace NewsWebAPI.Models
{


    public class AddUserResponse
    {
        public string? statusCode { get; set; }
        public string? statusMessage { get; set; }
    }
}
