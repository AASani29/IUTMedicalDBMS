using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUTMedical_DBMS
{
    public class ReferRequest
    {
        public int RequestId { get; set; }
        public int AppointmentID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public string ReferredBy { get; set; }
        public string Reason { get; set; }

        public ReferRequest(int requestId, int appointmentId, int userId, decimal amount, string referredBy, string reason)
        {
            RequestId = requestId;
            AppointmentID = appointmentId;
            UserID = userId;
            Amount = amount;
            ReferredBy = referredBy;
            Reason = reason;
        }
    }
}
