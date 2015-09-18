using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Metria.R3
{
	//[Serializable()]
	class Ponto //: ISerializable
	{
		#region Variaveis

		protected float _x;
		public float X
		{
			get
			{
				return _x;
			}
		}

		protected float _y;
		public float Y
		{
			get
			{
				return _y;
			}
		}

		protected float _z;
		public float Z
		{
			get
			{
				return _z;
			}
		}

		#endregion
		#region Construtores

		public Ponto()
		{
			_x = 0;
			_y = 0;
			_z = 0;
		}

		public Ponto(float x,float y, float z)
		{
			_x = x;
			_y = y;
			_z = z;
		}
		

		#endregion
		#region Metodos

		/// <summary>
		/// Translada o ponto
		/// </summary>
		/// <param name="x">Coordenada X</param>
		/// <param name="y">Coordenada Y</param>
		/// <param name="z">Coordenada Z</param>
		public void Transalada(float x,float y, float z)
		{
			this._x += x;
			this._y += y;
			this._z += z;
		}

		/// <summary>
		/// Translada o ponto
		/// </summary>
		/// <param name="P">Ponto de referencia da translação</param>
		public void Translada(Ponto P)
		{
			this._x += P.X;
			this._y += P.Y;
			this._z += P.Z;
		}

		/// <summary>
		/// Translada o ponto
		/// </summary>
		/// <param name="V">Vetor de translação</param>
		public void Transalada(Vetor V)
		{
			this._x += V.X;
			this._y += V.Y;
			this._z += V.Z;
		}

		/// <summary>
		/// Retorna um ponto transladado
		/// </summary>
		/// <param name="x">Coordenada X</param>
		/// <param name="y">Coordenada Y</param>
		/// <param name="z">Coordenada Z</param>
		/// <returns>Ponto transladado</returns>
		public Ponto Transladado(float x, float y, float z)
		{
			return new Ponto(X + x, Y + y, Z + z);
		}

		/// <summary>
		/// Retorna um ponto transladado
		/// </summary>
		/// <param name="P">Ponto de referencia para a tranlação</param>
		/// <returns>Ponto Transladado</returns>
		public Ponto Transladado(Ponto P)
		{
			return new Ponto(X + P.X, Y + P.Y, Z  + P.Z );
		}

		/// <summary>
		/// Retorna um ponto transladado
		/// </summary>
		/// <param name="V">Vetor de translação</param>
		/// <returns>Ponto transladado</returns>
		public Ponto Transladado(Vetor V)
		{
			return new Ponto(X + V.X, Y + V.Y, Z + V.Z);
		}
		/// <summary>
		/// Retorna o ponto oposto
		/// </summary>
		/// <returns>Ponto oposto</returns>
		public Ponto RetornaOposto()
		{
			return new Ponto(-X,-Y,-Z);
		}

		/// <summary>
		/// Retorna a distacia
		/// </summary>
		/// <param name="x">Cordenada X</param>
		/// <param name="y">Cordenada Y</param>
		/// <param name="z">Cordenada Z</param>
		/// <returns>Distancia</returns>
		public float RetornaDistancia(float x, float y, float z)
		{
			return (float)Math.Sqrt(Math.Pow(X-x,2)+Math.Pow(Y-y,2)+Math.Pow(Z-z,2));
		}

		/// <summary>
		/// Retorna a distacia
		/// </summary>
		/// <param name="P"></param>
		/// <returns></returns>
		public float RetornaDistancia(Ponto P)
		{
			return (float)Math.Sqrt(Math.Pow(X - P.X,2)+ Math.Pow(Y-P.Y,2) + Math.Pow(Z-P.Z,2));
		}
		#endregion
	}
}
