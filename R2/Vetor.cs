using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R2
{
	
	public class Vetor : Ponto
	{
		#region Variaveis
		private float _norma;
		public float Norma
		{
			get
			{
				return _norma;
			}
		}
		#endregion
		#region Construtores

		/// <summary>
		/// Vetor que parte da origem e vai a um ponto em (X,Y)
		/// </summary>
		/// <param name="X">Posição do ponto _diretor no eixo X</param>
		/// <param name="Y">Posição do ponto _diretor no eixo X</param>
		public Vetor(float X,float Y)
		{
			_x = X;
			_y = Y;
			calculaNorma();

		}

		/// <summary>
		/// Vetor que parte da origem e vai a um ponto diretor
		/// </summary>
		/// <param name="Diretor">Ponto diretor</param>
		public Vetor(Ponto Diretor)
		{
			_x = Diretor.X;
			_y = Diretor.Y;
			calculaNorma();
		}

		/// <summary>
		/// Vetor que parte de um ponto A e vai a um ponto B
		/// </summary>
		/// <param name="A">Ponto A</param>
		/// <param name="B">Ponto B</param>
		public Vetor(Ponto A, Ponto B)
		{
			_x = B.X - A.X;
			_y = B.Y - A.Y;
			calculaNorma();
		}

		/// <summary>
		/// Cria um vetor nulo centrado na origem
		/// </summary>
		public Vetor()
		{
			_x = 0;
			_y = 0;
			_norma = 0;
		}
		#endregion
		#region Metodos

		/// <summary>
		/// Retorna o versor do vetor
		/// </summary>
		/// <returns>Vesor</returns>
		public Vetor Vesor()
		{
			if(Norma!=0)
				return new Vetor(_x/Norma,_y/Norma);
			return null;
		}

		/// <summary>
		/// Retorna o modulo do vetor
		/// </summary>
		/// <returns>Modulo</returns>
		private void calculaNorma()
		{
			_norma = (float)(Math.Sqrt(_x*_x + _y*_y));
		}

		/// <summary>
		/// Retorna se V é LI
		/// </summary>
		/// <param name="V">Vetor V</param>
		/// <returns>Retorna verdadeiro se V for LI</returns>
		public bool LI(Vetor V)
		{
			if(_x/V.X == _y/V.Y)
				return true;
			return false;
		}

		public Vetor RetornaOrtogonal()
		{
			return new Vetor(-Y,X);
		}


		public float ProdutoEscalar(Vetor v)
		{
			return X*v.X+Y*v.Y;
		}

		#endregion

	}
}


