using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria
{
	public class Plano
	{
		public List<Ponto> Pontos = new List<Ponto>();
		List<Ponto> FechoConvexo = new List<Ponto>(); // convex hull

		public Plano(Ponto Dimensao)
		{
			
		}
	}
}
