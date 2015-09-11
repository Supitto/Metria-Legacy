using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria
{
	public class ArestaDelaunay : SegmentoDeReta
	{
		public TrianguloDelaunay vizinho;
		public int referente;
		public ArestaDelaunay(Ponto A, Ponto B) 
		{
			this._origem = A;
			this._pontoB = B;
			referente = 0;
			vizinho = null; 
		}
		public ArestaDelaunay(Ponto A, Ponto B, TrianguloDelaunay T, int r)
		{
			vizinho = T;
			referente = r;
			this._origem = A;
			this._pontoB = B;
			this.Diretor = new Vetor(A,B);
		} 

	}
}
