using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.Common
{
  public  class AddressDetails : BaseEntity
    {
        public int CandidateAddressId { get; set; }
        public string ResidentAddress { get; set; }
        public string PermenentAddress { get; set; }
        public string CanctactNo1 { get; set; }

        public string CanctactNo2 { get; set; }
        public string EmailId { get; set; }

    }
}
