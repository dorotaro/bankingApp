﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Response
{
	public class UserResponseModel
	{
		public string Email { get; set; }

		public Guid Id { get; set; }
	}
}
