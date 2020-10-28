using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Ben.Demo.Models
{
    public class BlogModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
        public double NumberWord { get; set; }
    }
}
