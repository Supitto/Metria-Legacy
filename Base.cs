using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria
{
	class Base
	{
		#region Variaveis
		private Vetor _vetor1, _vetor2;
		#endregion

		#region Construtores
		public Base (Vetor vetor1, Vetor vetor2)
		{
			if(validaBase(vetor1,vetor2))
			{
				_vetor1 = vetor1;
				_vetor2 = vetor2;
			}
			else
			{
				throw new Exception("O sistema tentou criar uma base invalida");
			}
		}
		#endregion

		#region Metodos

		private bool validaBase(Vetor vetor1, Vetor vetor2)
		{
			if(vetor1.X / vetor2.X != vetor1.Y / vetor2.Y)
				return true;
			return false;
		}

		#endregion
	}
}
