using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R2
{
	public class Triangulo
	{
	/*
	 *         a
	 *        /\
	 *     C /  \ B
	 *      /    \
	 *   b /______\ c
	 *        A
	 */
		#region Variaveis

		protected Ponto _pontoA, _pontoB, _pontoC;
		public Ponto PontoA
		{
			get
			{
				return _pontoA;
			}
			set
			{
				_pontoA = value;
				//_circuncentro = RetornaCircuncentro();

			}
		}
		public Ponto PontoB
		{
			get
			{
				return _pontoB;
			}
			set
			{
				_pontoB = value;
				//_circuncentro = RetornaCircuncentro();
			}
		}
		public Ponto PontoC
		{
			get
			{
				return _pontoC;
			}
			set
			{
				_pontoC = value;
				//_circuncentro = RetornaCircuncentro();

			}
		}
		
		protected Ponto _circuncentro;
		public Ponto Circuncentro
		{
			get	
			{
				return _circuncentro;
			}
		}

		protected Circulo _circunscrito;

		public Circulo  Circunscrito
		{
			get
			{
				return _circunscrito;
			}
		}
		#endregion
		#region Construtoreslic
		protected Triangulo() { }

		/// <summary>
		/// Um triangulo composto por um ponto e uma reta (reescrever de uma maneira melhor)
		/// </summary>
		/// <param name="P">Ponto P</param>
		/// <param name="R">Reta R</param>
		public Triangulo (Ponto P, Reta R)
		{
			_pontoA = P;
			_pontoB = R.Origem;
			_pontoC = R.Origem.Transladado(R.Diretor);
			_circuncentro = retornaCircuncentro();
			_circunscrito = new Circulo(Circuncentro,PontoA.RetornaDistancia(Circuncentro));
		}

		/// <summary>
		/// Um triangulo composto por dois pontos
		/// </summary>
		/// <param name="A">Ponto A</param>
		/// <param name="B">Ponto B</param>
		/// <param name="C">Ponto C</param>
		public Triangulo (Ponto A, Ponto B, Ponto C)
		{
			_pontoA = A;
			_pontoB = B;
			_pontoC = C;
			_circuncentro = retornaCircuncentro();

		}

		#endregion
		#region Metodos
		/// <summary>
		/// Retorna o circuncentro do triangulo
		/// </summary>
		/// <returns>Circuncentro</returns>
		private Ponto retornaCircuncentro()
		{
			return new Reta(PontoA,PontoB).Intersecta(new Reta(PontoB,PontoC));
		}
		/// <summary>
		/// Retorna a posição relativa de um ponto P em relação ao triangulo
		/// O algoritimo foi retirado do site http://www.blackpawn.com/texts/pointinpoly/default.html (perguntar ao paiva a expliação correta)
		/// </summary>
		/// <param name="P">O ponto P</param>
		/// <returns>Retorna verdadeiro se o ponto estiver dentro do triangulo, e falso se estiver fora</returns>
		public bool PosicaoRelativa(Ponto P)
		{
			Vetor vet1 = new Vetor(PontoA,PontoB)
			, vet2 = new Vetor(PontoA,PontoC)
			, vet3 = new Vetor(PontoA,P);
			float produto11 = vet1.ProdutoEscalar(vet1)
			, produto12 = vet1.ProdutoEscalar(vet2)
			, produto13 = vet1.ProdutoEscalar(vet3)
			, produto22 = vet2.ProdutoEscalar(vet2)
			, produto23 = vet2.ProdutoEscalar(vet3);
			float invDenom = 1 / (produto11 * produto22 - produto12 * produto12);
			float u = (produto22 * produto13 - produto13 * produto23) * invDenom,
			v = (produto11 * produto23 - produto12 * produto13) * invDenom;
			return (u >= 0) && (v >= 0) && (u + v < 1)
;
		}
		#endregion
	}
}