using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Response
{
	public class LoginResponseModel
	{

    public string Email { get; set; }

    public string IdToken { get; set; }
  }
}
