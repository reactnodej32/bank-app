
using System.Collections.Generic;

using bankapp.Models;

using Microsoft.AspNetCore.Mvc;


namespace bankapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //api/bankaccount
    public class BankAccountController : ControllerBase
    {
        private readonly BankDb bank_db;
        public BankAccountController(BankDb bank_db)
        {
            this.bank_db = bank_db;
        }

        [HttpGet]
        public IEnumerable<BankAccount> Get()
        {

            return bank_db.BankAccounts;
        }
        [HttpPost]
        public IActionResult Post([FromBody] BankAccount bankAccount)
        {
            bank_db.Add(bankAccount);

            bank_db.SaveChanges();

            return Ok(bankAccount);

        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using bankapp.Models;
// using Dapper;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;
// using MySql.Data.MySqlClient;


// namespace bankapp.Controllers
// {   
//     [ApiController]
//     public class UsersController : ControllerBase
//     {
//         private readonly IConfiguration _configuration;
//         private readonly string connString;
//         private readonly ILogger<UsersController> _logger;



//         public UsersController(IConfiguration configuration, ILogger<UsersController> logger)
//         {
//             _configuration = configuration;
//             _logger = logger;
//             //database
//             var host = _configuration["DATABASE_HOST"] ?? "localhost";
//             var password = _configuration["MYSQL_ROOT_PASSWORD"] ?? "dbuserpassword";
//             var userid = _configuration["MYSQL_USER"] ?? "dbuser";
//             connString = $"server={host};port=3306;userid={userid};password={password};database=users_prod;";

//         }

//         [HttpGet]
//         [Route("api/users")]
//         public async Task<IActionResult> Index()
//         {

//             string sql = "SELECT * from owner";
//             try
//             {
//                 using (var connection = new MySqlConnection(connString))
//                 {
//                     var owner = await connection.QueryAsync<Owner>(sql);
//                     return Ok(owner);
//                 }
//             }
//             catch (Exception)
//             {
//                 return Ok(connString);
//             }


//         }


//     }
// }
