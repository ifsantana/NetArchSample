using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSampleArch.Application.UseCases
{
    public class BaseUseCaseModel
    {
		public string ExecutionUser { get; }

		protected BaseUseCaseModel(
			string executionUser
		)
		{
			ExecutionUser = executionUser;
		}
	}
}
