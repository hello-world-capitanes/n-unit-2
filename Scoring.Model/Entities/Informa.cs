using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Model.Entities
{
    public class Informa
    {
        public Informa() {
            this.CIFs = new List<string>();
            this.CIFs.Add("2457802");
            this.CIFs.Add("3466536");
        }    
        public List<string> CIFs { get; set; }
    }
}
