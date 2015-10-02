using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R2
{
	public class Delaunay
	{
		private List<TrianguloDelaunay> _triangulos; // triangulação
		public List<TrianguloDelaunay> Triangulos
		{
			get 
			{
				return _triangulos;
			}
		}
		public void porFecho()
		{

		}
		private void porIncremental(ref List<Ponto> _pontos)
		{
			int qtd = 0;//
			_pontos = new FechoConvexo(_pontos).MontaFecho(ref qtd);
			//obs tratatr caso n haja ponto apos o fecho
			_triangulos.Add(new TrianguloDelaunay(_pontos[qtd], _pontos[0], _pontos[1]));
			for (int i = 1; i < qtd - 1; i++)
			{
				_triangulos.Add(new TrianguloDelaunay(null, null, _triangulos[i - 1], _pontos[qtd], _pontos[i], _pontos[i + 1]));
			}
			_triangulos.Add(new TrianguloDelaunay(null, _triangulos[0], _triangulos[_triangulos.Count - 1], _pontos[qtd], _pontos[0], _pontos[qtd - 1]));
			_triangulos[0].Vizinho2 = _triangulos[1];
			_triangulos[0].Vizinho3 = _triangulos[_triangulos.Count - 1];

			for (int i = 1; i < _triangulos.Count - 1; i++)
			{
				_triangulos[i].Vizinho2 = _triangulos[i + 1];
				_triangulos[i].Vizinho3 = _triangulos[i - 1];
			}
			/* 
			for (int i = 1; i < qtd; i++)
			{
				if (new SegmentoDeReta(_pontos[i], _pontos[i + 1]).PosicaoPonto(_pontos[qtd])!=2) 
					_triangulos.Add(new TrianguloDelaunay(null,_pontos[qtd], _pontos[i], _pontos[i + 1]));
			}

			_triangulos[0].Vizinho2 = _triangulos[1];
			_triangulos[0].Vizinho2 = _triangulos[_triangulos.Count-1];

			for (int i = 1; i < _triangulos.Count-1; i++)
			{
				_triangulos[i].Vizinho2 = _triangulos[i + 1];
				_triangulos[i].Vizinho2 = _triangulos[i - 1];
			}

			_triangulos[_triangulos.Count - 1].Vizinho2 = _triangulos[0];
			_triangulos[_triangulos.Count - 1].Vizinho2 = _triangulos[_triangulos.Count - 2];
			*/
			for (int i = qtd+1; i < _pontos.Count; i++)
			{
				adcionaPonto(_pontos[i]);
			}
		}
		public Delaunay(ref List<Ponto> pontos)
		{
			_triangulos = new List<TrianguloDelaunay>();
			porIncremental(ref pontos);
		}

		public void adcionaPonto(Ponto P)
		{
			List<ArestaDelaunay> arestas = new List<ArestaDelaunay>();
			List<TrianguloDelaunay> Morto = new List<TrianguloDelaunay>();			

			for(int i=0; i<_triangulos.Count; i++)
			{
				if(_triangulos[i].Circunscrito.PosicaoRelativa(P)!= 2)
					Morto.Add(_triangulos[i]);
			}
			
			arestas = encontraArestas(P,Morto);// erase later -> working fine
			arestas = ordenaAresta(arestas);// erase later -> working fine

			for (int i = 0; i < Morto.Count; i++)
				_triangulos.Remove(Morto[i]);

			for (int i = 0; i < arestas.Count; i++)
			{
				_triangulos.Add(new TrianguloDelaunay(arestas[i].vizinho, P, arestas[i].Origem, arestas[i].PontoB));
			}

		
			
						
		}
		private List<ArestaDelaunay> encontraArestas(Ponto P, List<TrianguloDelaunay> morto)
		{
			List<ArestaDelaunay> temp = new List<ArestaDelaunay>();// lista temporaria
			foreach (TrianguloDelaunay T in morto)
			{
				if (T.Vizinho1 == null || T.Vizinho1.Circunscrito.PosicaoRelativa(P) == 2)// se esta vivo
				{
					if (T.Vizinho1 == null)
						temp.Add(new ArestaDelaunay(T.PontoC, T.PontoB));
					else
						temp.Add(new ArestaDelaunay(T.Vizinho1.PontoC, T.PontoB, T.Vizinho1, T.Vizinho1.qualVizinho(T)));
				}
				if(T.Vizinho2 == null || T.Vizinho2.Circunscrito.PosicaoRelativa( P)==2)// se esta vivo
				{
					if (T.Vizinho2 == null)
						temp.Add(new ArestaDelaunay(T.PontoA,T.PontoC));
					else
						temp.Add(new ArestaDelaunay(T.Vizinho2.PontoA,T.PontoC,T.Vizinho2,T.Vizinho2.qualVizinho(T)));

				}
				if(T.Vizinho3 == null || T.Vizinho3.Circunscrito.PosicaoRelativa( P)==2)// se nao esta fora
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
		/*
			ArestaDelaunay temp;// temporario/ auxiliar
			for (int j = 1; j < arestas.Count-j; j++)
			{		
				for (int i = 1; i < arestas.Count-j; i++ )
				{
					if(arestas[0].PontoB == arestas[i].Origem || arestas[0].PontoB == arestas[i].PontoB)
					{
						temp = arestas[0];
						arestas.RemoveAt(0);
						arestas.Add(temp);
						temp = arestas[i];
						arestas.RemoveAt(i);
						arestas.Insert(1, temp);
					}
				}
			}
		 */
			ArestaDelaunay temp;// temporario/ auxiliar
			int i = 0;
			for (int j = 1; j < arestas.Count-i; j++)
			{
				if (arestas[0].PontoB == arestas[j].Origem || arestas[0].PontoB == arestas[j].PontoB)
				{
				temp = arestas[0];
				arestas.RemoveAt(0);
				arestas.Add(temp);
				temp = arestas[j];
				arestas.RemoveAt(j);
				arestas.Insert(0, temp);
				i++;
				}
			}
			return arestas;
		}
	}
}
