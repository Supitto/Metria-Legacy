using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Metria.R2
{
	/// <summary>
	/// Um ponto em R²
	/// </summary>
	[Serializable()]
	public class Ponto : ISerializable
    {
		#region Variaveis
		protected float _x;
		/// <summary>
		/// Cordenada X
		/// </summary>
		public float X 
		{
			get
			{
			return _x;
			}
			set
			{
				_x = value;
			}
		}

		protected float _y;
		/// <summary>
		/// Cordenada Y
		/// </summary>
		public float Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}
		#endregion
		#region Construtores

		/// <summary>
		/// Cria um ponto nas cordenadas especificadas
		/// </summary>
		/// <param name="X">Posição do ponto no eixo X</param>
		/// <param name="Y">Posição do ponto no eixo Y</param>
		public Ponto(float X,float Y)
		{
			this._x = X;
			this._y = Y;
		}

		/// <summary>
		/// Cria um ponto na origem
		/// </summary>
		public Ponto()
		{
			this._x = 0;
			this._y = 0;
		}
		#endregion
		#region Serialização
		public Ponto(SerializationInfo info, StreamingContext ctxt)
		{
			this._x = (float)info.GetValue("_x", typeof(float));
			this._y = (float)info.GetValue("_y",typeof(float));
			
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("_x", this._x);
			info.AddValue("_y", this._y);
			info.AddValue("Version", "1.0.0.0");
			info.AddValue("Culture","neutral");
			info.AddValue("PublicKeyToken",null);
		}
		#endregion
		#region Metodos
		/// <summary>
		/// Translado o ponto
		/// </summary>
		/// <param name="X">Cordenada X da translação</param>
		/// <param name="Y">Cordenada Y da translação</param>
		public void Translada(float X,float Y)
		{
			this._x += X;
			this._y += Y;
		}

		/// <summary>
		/// Translado o ponto
		/// </summary>
		/// <param name="P">Ponto P da translação</param>
		public void Translada(Ponto P)
		{
			this._x += P.X;
			this._y += P.Y;
		}

		/// <summary>
		/// Translado o ponto
		/// </summary>
		/// <param name="V">Vetor V da translação</param>
		public void Translada(Vetor V)
		{
			this._x += V.X;
			this._y += V.Y;
		}

		public Ponto Transladado(float X, float Y)
		{
			return new Ponto(this._x += X,this._y += Y);
		}

		public Ponto Transladado(Ponto P)
		{
			return new Ponto(this.X + P.X, this.Y + P.Y);
		}

		public Ponto Transladado(Vetor V)
		{
			return new Ponto(this._x + V.X,this._y + V.Y); 
		}
		/// <summary>
		/// Retorna o ponto oposto
		/// </summary>
		/// <returns>Ponto oposto</returns>
		private Ponto  RetornaOposto()
		{
			return new Ponto(-this.X, -this.Y);
		}

		/// <summary>
		/// Retorna distancia do ponto ao ponto P
		/// </summary>
		/// <param name="P">Ponto P</param>
		/// <returns>Distancia</returns>
		public float RetornaDistancia(Ponto P)
		{
			return (float)Math.Sqrt(Math.Pow(this.X-P.X,2) + Math.Pow(this.Y-P.Y,2));
		}

		/// <summary>
		/// Retorna distancia do ponto ao ponto (X,Y)
		/// </summary>
		/// <param name="X">Cordenada X</param>
		/// <param name="Y">Cordenada Y</param>
		/// <returns>Distancia</returns>
		public float RetornaDistancia(float X, float Y)
		{
			return (float)Math.Sqrt(Math.Pow(this.X - X, 2) + Math.Pow(this.Y - Y, 2));
		}

		#endregion

		

    }
}
