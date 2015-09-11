using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria
{
	public class Delaunay
	{
		private List<Ponto> _pontos;
		private List<Ponto> _fecho;
		private List<TrianguloDelaunay> _triangulos;
		public List<TrianguloDelaunay> Triangulos
		{
			get 
			{
				return _triangulos;
			}

		}

		public Delaunay(List<Ponto> pontos)
		{
			_pontos = pontos;
			int qtd = 0;
			_triangulos = new List<TrianguloDelaunay>();
			_fecho = new FechoConvexo(pontos).MontaFecho(ref qtd);
			_triangulos.Add(new TrianguloDelaunay (pontos[qtd],pontos[0], pontos[1]));
			for (int i = 1; i < qtd-1; i++)
			{
				_triangulos.Add(new TrianguloDelaunay(null,null,_triangulos[i - 1], pontos[qtd], pontos[i], pontos[i + 1]));
			}
			_triangulos.Add(new TrianguloDelaunay(null,_triangulos[0], _triangulos[_triangulos.Count - 1], pontos[qtd], pontos[0], pontos[qtd - 1]));
			_triangulos[0].Vizinho2=_triangulos[1];
			_triangulos[0].Vizinho3=_triangulos[_triangulos.Count-1];

			for (int i = 1; i < _triangulos.Count-1; i++)
			{
				_triangulos[i].Vizinho2 = _triangulos[i+1];
				_triangulos[i].Vizinho3 = _triangulos[i - 1];
			}

			for (int i = qtd+1; i < pontos.Count; i++)
			{
				adcionaPonto(pontos[i]);
			}
	
		}

		private void adcionaPonto(Ponto P)
		{
			List<ArestaDelaunay> arestas = new List<ArestaDelaunay>();
			List<TrianguloDelaunay> Morto = new List<TrianguloDelaunay>();			

			for(int i=0;i<_triangulos.Count;i++)
			{
				if(_triangulos[i].Circunscrito.PosicaoRelativa(P)!=2)
					Morto.Add(_triangulos[i]);
			}
			
			arestas = encontraArestas(P,Morto);
			arestas = ordenaAresta(arestas);

			for (int i = 0; i < Morto.Count; i++)
				_triangulos.Remove(Morto[i]);

			{
				List<TrianguloDelaunay> T = new List<TrianguloDelaunay>();
				if (arestas[0].vizinho != null)
					T.Add(new TrianguloDelaunay(null, arestas[0].vizinho, null, arestas[0].Origem, arestas[0].PontoB, P));
				else
					T.Add(new TrianguloDelaunay(null, null, null, arestas[0].Origem, arestas[0].PontoB, P));
				for (int i = 1; i < arestas.Count; i++)
				{ 
					if(arestas[i].vizinho!= null)
						T.Add(new TrianguloDelaunay(null,arestas[0].vizinho,T[i-1],arestas[0].Origem,arestas[0].PontoB,P));
					else
						T.Add(new TrianguloDelaunay(null, null, T[i - 1], arestas[0].Origem, arestas[0].PontoB, P));
				}
				for (int i = 0; i < T.Count-1; i++)
					T[i].Vizinho3 = T[i+1];
				T[T.Count-1].Vizinho3 = T[0];
				_triangulos.AddRange(T);
			}
						
		}
		private List<ArestaDelaunay> encontraArestas(Ponto P, List<TrianguloDelaunay> morto)
		{
			List<ArestaDelaunay> temp = new List<ArestaDelaunay>();
			foreach (TrianguloDelaunay T in morto)
			{
				if (T.Vizinho1 == null || T.Vizinho1.Circunscrito.PosicaoRelativa(P) != 2)
				{
					if (T.Vizinho1 == null)
						temp.Add(new ArestaDelaunay(T.PontoC, T.PontoB));
					else
						temp.Add(new ArestaDelaunay(T.Vizinho1.PontoC, T.PontoB, T.Vizinho1, T.Vizinho1.qualVizinho(T)));
				}
				if(T.Vizinho2 == null || T.Vizinho2.Circunscrito.PosicaoRelativa( P)!=2)
				{
					if (T.Vizinho2 == null)
						temp.Add(new ArestaDelaunay(T.PontoA,T.PontoC));
					else
						temp.Add(new ArestaDelaunay(T.Vizinho2.PontoA,T.PontoC,T.Vizinho2,T.Vizinho2.qualVizinho(T)));

				}
				if(T.Vizinho3 == null || T.Vizinho3.Circunscrito.PosicaoRelativa( P)!=2)
				{
					if (T.Vizinho3 == null)
						temp.Add(new ArestaDelaunay(T.PontoB, T.PontoA));
					else
						temp.Add(new ArestaDelaunay(T.Vizinho3.PontoB, T.PontoA, T.Vizinho3, T.Vizinho2.qualVizinho(T)));
				}	
			}	
			return temp.Distinct().ToList();
		}	
		private List<ArestaDelaunay> ordenaAresta(List<ArestaDelaunay> arestas)
		{
			for(int i = 0; i < arestas.Count; i++)
				for(int j = 0; i<arestas.Count; i++)
					if(arestas[i].PontoB == arestas[j].Origem && i!=j)
					{ 
						ArestaDelaunay a = arestas[j];
						arestas.RemoveAt(j);
						arestas.Insert(i+1,a);
					}
			return arestas;
		}
	}
}
