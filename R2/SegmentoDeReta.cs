using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R2
{
	public class SegmentoDeReta : Reta
	{
	#region Variaveis

	protected Ponto _pontoB;
	public Ponto PontoB
	{
		get
		{
			return _pontoB;
		}
		set
		{
			_pontoB = value;
			calculaCoeficiente();
		}
	}

	#endregion
	#region Construtores

		public SegmentoDeReta()
		{
			_origem = null;
			_pontoB = null;
		}
		public SegmentoDeReta(Ponto A, Ponto B)
		{
			_origem = A;
			_pontoB = B;
			Diretor = new Vetor(_origem,PontoB);
		}

		public SegmentoDeReta(Ponto Origem, Vetor Diretor)
		{
			_origem = Origem;
			_pontoB = Origem.Transladado(Diretor);
		}

	#endregion
	#region metodos

		private new void calculaCoeficiente()
		{
			_a = -Diretor.Y;
			_b = Diretor.X;
			_c = Diretor.X * (Origem.X - Origem.Y);
		}
		/*
		/// <summary>
		/// Posição relativa de um ponto P a reta
		/// </summary>
		/// <param name="P">Ponto O</param>
		/// <returns>0 se estiver "acima da reta", 2 se estiver contido na reta, 1 se estiver "abaixo da reta" ou 3 caso esteja fora do segmento</returns>
		new public int PosicaoPonto(Ponto P)
		{
			if(P.X < PontoB.X && P.X > Origem.X)
			{ 
				Reta r = new Reta(Origem, Diretor.RetornaOrtogonal());
				float y = r.PontoNaReta((P.X-Origem.X)/Diretor.X).Y;
				if (P.Y - y > 0)
					return 0;
				if (P.Y - y < 0)
					return 1;
				if (P.Y - y == 0)
					return 2;
			}
			else
				return 3;
			return 4;
		}
		*/
	#endregion
	}
}
