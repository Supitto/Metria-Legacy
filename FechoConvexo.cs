using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria
{
	public class FechoConvexo
	{
		private List<Ponto> _pontos;
		private int IndexAtual;

		public FechoConvexo(List<Ponto> ponto)
		{
			_pontos = ponto; // define o set atual dos pontos -> Sera usada como a lista principal de pontos 
		}
		public List<Ponto> MontaFecho(ref int quantidade)
		{
			

			defineExtremos();// localiza os pontos mais extremados segundo o eixo X
			
			IndexAtual = 1; // Define Indice como 1

			List<Ponto> Acima = new List<Ponto>(), Abaixo = new List<Ponto>();

			Acima.Add(_pontos[0]);
			Acima.Add(_pontos[1]);

			SegmentoDeReta s = new SegmentoDeReta(_pontos[0],_pontos[1]);
			
			for(int i = 2; i < _pontos.Count; i++)
			{
				int posicao = s.PosicaoPonto(_pontos[i]);
				if(posicao==0)
					Acima.Add(_pontos[i]);
				else if(posicao==1)
					Abaixo.Add(_pontos[i]);
			}
			if(Acima.Count>0)
			{ 
				recursiva(true);
				IndexAtual++;
			}
			if (Abaixo.Count > 0)
			{
				IndexAtual++;
				recursiva(false);
			}
			quantidade = IndexAtual+1;
			return _pontos;
		}

		private void defineExtremos()
		{
			Ponto extremo1 = _pontos[0], extremo2 = _pontos[0];
			for (int i = 1; i < _pontos.Count; i++)
			{
				if (_pontos[i].X < extremo1.X)
					extremo1 = _pontos[i];
				else if (_pontos[i].X > extremo2.X)
					extremo2 = _pontos[i];
			}
			_pontos.Remove(extremo1);
			_pontos.Remove(extremo2);
			_pontos.Insert(0,extremo2);
			_pontos.Insert(0,extremo1);
		}
		//renomear essa função
		private void recursiva(bool acima)
		{
			List<Ponto> Auxiliar = new List<Ponto>();
			SegmentoDeReta segmento;
			Ponto maisDistante;
			recursivo:
			Auxiliar.Clear();
			if(acima)
			{
				segmento = new SegmentoDeReta(_pontos[IndexAtual-1],_pontos[IndexAtual]);
				Auxiliar = segmento.PosicaoPonto(_pontos,0);
				if(Auxiliar != null && Auxiliar.Count>0)
				{
					maisDistante = segmento.RetornaMaisDistante(Auxiliar);
					if (maisDistante != null)
					{
						_pontos.Remove(maisDistante);
						_pontos.Insert(IndexAtual, maisDistante);
						goto recursivo;
					}
				}
				else
				{
					segmento = new SegmentoDeReta(_pontos[IndexAtual], _pontos[IndexAtual + 1]);
					Auxiliar = segmento.PosicaoPonto(_pontos,0);
					if (Auxiliar.Count > 0 && Auxiliar != null)
					{
						IndexAtual++;
						goto recursivo;
					}
				}
			}
			else
			{
				segmento = new SegmentoDeReta(_pontos[IndexAtual],_pontos[0]);
				Auxiliar = segmento.PosicaoPonto(_pontos, 0);
				if(Auxiliar!=null && Auxiliar.Count>0)
				{ 
					maisDistante = segmento.RetornaMaisDistante(Auxiliar);
					if(maisDistante!= null)
					{ 
						_pontos.Remove(maisDistante);
						_pontos.Insert(IndexAtual,maisDistante);
						goto recursivo;
					}
				}
				else
				{
					segmento = new SegmentoDeReta(_pontos[IndexAtual],_pontos[IndexAtual-1]);
					Auxiliar = segmento.PosicaoPonto(_pontos, 1);
					if (Auxiliar.Count > 0 && Auxiliar != null)
					{
						IndexAtual++;
						goto recursivo;
					}	
				}
			}
		}
	}
}
