using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisPersonalProject.Models.Request;

public class ApiResponse<T>
{
    public HttpResponseMessage HttpResponse { get; set; }
    public T? Data { get; set; }
    public List<T>? ListData { get; set; }
}
