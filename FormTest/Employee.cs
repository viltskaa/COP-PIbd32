using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTest
{
    internal class Employee
    {
		public int Id { get; set; }

		public string State { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int Age { get; set; }

		public string Post { get; set; }

		public string Department { get; set; }

		public int Experience { get; set; }

		public string Childrens { get; set; }

		public string Car { get; set; }

		public double Prize { get; set; }

		public override string ToString() => $"{Id} - {LastName} {FirstName} ({Experience})";

	}
}
