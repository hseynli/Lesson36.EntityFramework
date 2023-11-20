using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public static class Config
    {
        public static string ConnectionString { get; set; } = "Data Source=.;Initial Catalog=EvoCodingEntity;Integrated Security=True;TrustServerCertificate=True";
    }
}
