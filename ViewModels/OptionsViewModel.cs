using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class OptionsViewModel<T>
	{
		public int OptionId { get; set; }
		public T OptionValue { get; set; }
	}
}
