using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R3
{
	class Plano
	{
		#region Variaveis

		private Vetor _v1;
		public Vetor V1
		{
			get
			{
				return _v1;
			}
		}
		private Vetor _v2;
		public Vetor V2
		{
			get
			{
				return _v2;
			}
		}
		#endregion
		#region Construtores
		public Plano()
		{
			_v1 = new Vetor(1,0,0);
			_v2 = new Vetor(0,1,0);
		}

		public Plano(Vetor v1, Vetor v2)
		{
			_v1 = v1;
			_v2 = v2;
		}
		#endregion
		#region Metodos
		
		public bool PontoNoPlano(Ponto P)
		{
			return false;
		} 



		#endregion
	}
}
