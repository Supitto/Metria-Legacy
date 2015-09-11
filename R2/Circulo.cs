using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R2
{
	public class Circulo
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
		private float _raio;
		public float Raio
		{
			get
			{
				return _raio;
			}
		}
		#endregion
		#region Construtores
		/// <summary>
		/// Um circulo com centro em P e de raio R
		/// </summary>
		/// <param name="origem">O centro P</param>
		/// <param name="raio">O raio R</param>
		public Circulo (Ponto origem, float raio)
		{
			this._origem = origem;
			this._raio = raio;
		}

		public Circulo (float raio)
		{
			this._origem = new Ponto();
			this._raio = raio;
		}
		#endregion
		#region Metodos
		/// <summary>
		/// Retorna a posição relativa de um ponto P quanto ao circulo
		/// </summary>
		/// <param name="P">O ponto P</param>
		/// <returns>Retorna 0 caso P esteja contido no circulo, 1 caso P esteja contido no bordo do circulo, e 2 caso P esteja fora do circulo</returns>
		public int PosicaoRelativa(Ponto P)
		{
			if(Origem.RetornaDistancia(P)<Raio)
				return 0;
			if (Origem.RetornaDistancia(P) > Raio)
				return 2;
			return 1;
		}

		#endregion
	}
}
