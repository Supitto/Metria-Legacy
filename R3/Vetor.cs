using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metria.R3
{
	class Vetor : Ponto
	{
		#region Varivaveis
		protected float _norma;
		public float Norma
		{
			get
			{
				return _norma;
			}
		}
		#endregion
		#region Construtores
		public Vetor()
		{
			_z = 0;
			_norma = 0;
		}
		public Vetor(float x, float y, float z)
		{
			_x = x;
			_y = y;
			_z = z;
			_norma = 0;
		}
		public Vetor()
		{
			_z = 0;
			_norma = 0;
		}
		public Vetor()
		{
			_z=0;
			_norma = 0;
		}


		#endregion
		#region Metodos

		private float calculaNorma()
		{
			return (float)Math.Sqrt(Math.Pow(X,2)+Math.Pow(Y,2)+Math.Pow(Z,2));
		}

		public Vetor RetornaVersor()
		{
			return new Vetor(X/Norma,Y/Norma,Z/Norma);
		}
		
		[Obsolete("Metodo ainda nao abastraido")]
		public Vetor RetornaOrtogonal()
		{
			return null;
		} 

		public float ProdutoEscalar(Vetor V)
		{
			return X*V.X + Y*V.Y + Z*V.Z;
		}


		#endregion
	}
}
