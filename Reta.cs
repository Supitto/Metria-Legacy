using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria
{
	public class Reta
	{
		#region Variaveis
		
		protected Ponto _origem;
		public Ponto Origem
		{
			get
			{
				return _origem;
			}
			set
			{
				_origem = value;
				calculaCoeficiente();
			}
		}

		protected Vetor _diretor;
		public Vetor Diretor
		{
			get
			{
				return _diretor;
			}
			set
			{
				_diretor = value;
				calculaCoeficiente();
			}
		}

		protected float _a,_b,_c;
		/// <summary>
		/// Coeficiente A da reta
		/// </summary>
		public float A
		{
			get
			{
				return _a;
			}
		}
		/// <summary>
		/// Coeficiente B da reta
		/// </summary>
		public float B
		{
			get
			{
				return _b;
			}
		}
		/// <summary>
		/// Coeficiente C da reta
		/// </summary>
		public float C
		{
			get
			{
				return _c;
			}
		}


		#endregion
		#region Construtores
		protected Reta()
		{

		}
		/// <summary>
		/// Reta que parte de um ponto origem O e tem como direção o vetor diretor D
		/// </summary>
		/// <param name="Origem">Ponto origem O</param>
		/// <param name="Diretor">Vetor diretor D</param>
		public Reta(Ponto Origem, Vetor Diretor)
		{
			if(Diretor.X !=0 || Diretor.Y !=0)
			{ 
				_origem = Origem;
				_diretor = Diretor;
				calculaCoeficiente();
			}
			else 
			throw new Exception("Não é possivel criar uma reta com um vetor diretor nulo");
		}

		/// <summary>
		/// Reta que parte de um ponto A e tem como direção o vetor formado pelos pontos A e B
		/// </summary>
		/// <param name="A">Ponto A</param>
		/// <param name="B">Ponto B</param>
		public Reta(Ponto A, Ponto B)
		{
			if(A!=B)
			{ 
				_origem = A;
				_diretor = new Vetor(A,B);
				calculaCoeficiente();
			}
			else
			throw new Exception("Não é possivel criar uma reta com um vetor diretor nulo");
		}
		#endregion
		#region Metodos

		/// <summary>
		/// Ponto na reta com o lambida informado
		/// </summary>
		/// <param name="Lambida">Lambida</param>
		/// <returns>Ponto na reta</returns>
		public Ponto PontoNaReta(float Lambida)
		{
			return new Ponto(Lambida*Diretor.X+Origem.X,Lambida*Diretor.Y+Origem.Y);
		}

		/// <summary>
		/// Posição relativa de um ponto P a reta
		/// </summary>
		/// <param name="P">Ponto O</param>
		/// <returns>0 se estiver "acima da reta", 2 se estiver contido na reta, 1 se estiver "abaixo da reta"</returns>
		public int PosicaoPonto(Ponto P)
		{
			float escalar = Diretor.RetornaOrtogonal().ProdutoEscalar(new Vetor(Origem,P));
			if(escalar>0)
				return 0;
			if(escalar<0)
				return 1;
			if(escalar==0)
				return 2;
			return 3;
		}

		public List<Ponto> PosicaoPonto(List<Ponto> P,int cod)
		{
			List<Ponto> Temp = new List<Ponto>();
			
			if (cod == 0)
			{
				for (int i = 0; i < P.Count; i++)
				{
					if (Diretor.RetornaOrtogonal().ProdutoEscalar(new Vetor(Origem, P[i])) > 0)
					{
						Temp.Add(P[i]);
					}
				}
			} 
			if (cod == 1)
			{
				for (int i = 0; i < P.Count; i++)
				{
					if (Diretor.RetornaOrtogonal().ProdutoEscalar(new Vetor(Origem, P[i])) < 0)
					{
						Temp.Add(P[i]);
					}
				}
			} 
			if (cod == 2)
			{
				for (int i = 0; i < P.Count; i++)
				{
					if (Diretor.RetornaOrtogonal().ProdutoEscalar(new Vetor(Origem, P[i])) == 0)
					{
						Temp.Add(P[i]);
					}
				}
			}
			return Temp;
		}

		protected void calculaCoeficiente()
		{
			Vetor orto = Diretor.RetornaOrtogonal();
			_a = orto.X;
			_b = orto.Y;
			_c = -(A*Origem.X+B*Origem.Y);
		}

		public Ponto Intersecta(Reta R)
		{
			float X = (this.B*R.C-R.B*this.C)/(R.B-this.B);
			float dX = X/Diretor.X;
			return this.PontoNaReta(dX);	
		}

		public float RetornaDistancia(Ponto P)
		{
			float numerador, denominador;
			numerador = A*P.X+B*P.Y+C;
			if (numerador<0)
				numerador = - numerador;
			denominador = (float)Math.Sqrt(A*A+B*B);
			return numerador/denominador;
		}

		public Ponto RetornaMaisDistante(List<Ponto> P)
		{
			Vetor orto = Diretor.RetornaOrtogonal();
			Ponto maisDistante = P[0];
			float distancia = orto.ProdutoEscalar(new Vetor(Origem,P[0]));
			for (int i = 1; i < P.Count; i++)
			{
				float d = orto.ProdutoEscalar(new Vetor(Origem, P[i]));
				if(d>distancia)
				{
					distancia = d;
					maisDistante = P[i];
				}
						
			}
			return maisDistante;
		}

		#endregion
	}
}
