using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtaribeiratkozas
{
	public class Olvaso
	{
		public string Nev { get; set; }
		public int Eletkor { get; set; }
		public string Mufaj { get; set; }
		public string Ertesitesek { get; set; }
		public string Tagsag { get; set; }

		public override string ToString()
		{
			return $"{Nev};{Eletkor};{Mufaj};{Ertesitesek};{Tagsag}";
		}
	}
}
