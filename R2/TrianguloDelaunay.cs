using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R2
{
	public class TrianguloDelaunay : Triangulo
	{
		#region Variaveis

		private TrianguloDelaunay _vizinho1, _vizinho2, _vizinho3;
		public TrianguloDelaunay Vizinho1
		{
			get
			{
				return _vizinho1;
			}
			set
			{
				_vizinho1 = value;
			}
		}
		public TrianguloDelaunay Vizinho2
		{
			get
			{
				return _vizinho2;
			}
			set
			{
				_vizinho2 = value;
			}
		}
		public TrianguloDelaunay Vizinho3
		{
			get
			{
				return _vizinho3;
			}
			set
			{
				_vizinho3 = value;
			}
		}

		#endregion
		#region Construtores

		public TrianguloDelaunay(TrianguloDelaunay vizinho1, TrianguloDelaunay vizinho2, TrianguloDelaunay vizinho3, Ponto A, Ponto B, Ponto C)
		{
			_pontoA = A;
			_pontoB = B;
			_pontoC = C;
			_vizinho1 = vizinho1;
			_vizinho2 = vizinho2;
			_vizinho3 = vizinho3;
			_circuncentro = new SegmentoDeReta(A, B).Intersecta(new Reta(A, C));
			_circunscrito = new Circulo(Circuncentro, A.RetornaDistancia(Circuncentro));

		}

		public TrianguloDelaunay(TrianguloDelaunay vizinho1, TrianguloDelaunay vizinho2, Ponto A, Ponto B, Ponto C)
		{
			_pontoA = A;
			_pontoB = B;
			_pontoC = C;
			_vizinho1 = vizinho1;
			_vizinho2 = vizinho2;
			_vizinho3 = null;
			_circuncentro = new SegmentoDeReta(A, B).Intersecta(new Reta(A, B));
			_circunscrito = new Circulo(Circuncentro, A.RetornaDistancia(Circuncentro));
		}

		public TrianguloDelaunay(TrianguloDelaunay vizinho1, Ponto A, Ponto B, Ponto C)
		{
			_pontoA = A;
			_pontoB = B;
			_pontoC = C;
			_vizinho1 = vizinho1;
			_vizinho2 = null;
			_vizinho3 = null;
			_circuncentro = new SegmentoDeReta(A, B).Intersecta(new Reta(A, B));
			_circunscrito = new Circulo(Circuncentro, A.RetornaDistancia(Circuncentro));
		}

		public TrianguloDelaunay(Ponto A, Ponto B, Ponto C)
		{
			_pontoA = A;
			_pontoB = B;
			_pontoC = C;
			_vizinho1 = null;
			_vizinho2 = null;
			_vizinho3 = null;
			_circuncentro = new SegmentoDeReta(A, B).Intersecta(new Reta(A, B));
			_circunscrito = new Circulo(Circuncentro, A.RetornaDistancia(Circuncentro));
		}

		#endregion
		#region Metodos

		public int qualVizinho(TrianguloDelaunay T)
		{
			if(Vizinho1 == T)
				return 1;
			if(Vizinho2 == T)
				return 2;
			if(Vizinho3 == T)
				return 3;
			return 0;
		}
		#endregion
	}
}
