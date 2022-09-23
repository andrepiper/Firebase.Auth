using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.Auth.Common
{
    public class BackendResponse<T>
    {
        public T? Payload { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
