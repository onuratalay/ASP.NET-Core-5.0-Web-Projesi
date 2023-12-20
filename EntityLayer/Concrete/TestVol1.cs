using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TestVol1
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
    }
}
