using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R3
{
	class Reta
	{
		#region Variaveis

		private Ponto _origem;
		public Ponto Origem
		{
			get
			{
				return _origem;
			}
		} 

		private Vetor _diretor;
		public Vetor Diretor
		{
			get
			{
				return _diretor;
			}
		}
		#endregion
		#region Construtores

		public Reta()
		{
			_origem = new Ponto();
			_diretor = new Vetor();
		}
		#endregion
	}
}
