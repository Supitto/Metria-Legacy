using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Metria
{
	public class Root : Node
	{
		public Node NodeD; // node adcional (Node down) / addictional node (Node down)

		//Construtores / Constructors
		public Root(TrianguloDelaunay valor)
		{
			Node(valor);
			NodeD = null;
		}
	}
	public class Node
	{	
		public TrianguloDelaunay Valor;
		
		//se for a raiz o valor é null / if its the root the value is null

		public Node NodeF;
		
		//Nó da direita / Right node

		public Node NodeR;
		
		//Nó da esquerda / Left node

		public Node NodeL;
		
		//Construtores / Constructors
		//Construtor de Node completo / Full Node constructor
		public Node(TrianguloDelaunay valor, Node nodeF, Node nodeR, Node nodeL)
		{
			this.Valor = valor;
			this.NodeR = nodeR;
			this.NodeL = nodeL;
			this.NodeF = nodeF;
		}
		//Construtor de Node com 1 Nodes / Node construcutor with 1 Nodes
		public Node(TrianguloDelaunay valor, Node nodeF, Node nodeR)
		{
			Node(valor, nodeF, nodeR, null);
		}
		//Construtor Raiz com 2 Nodes / Root constructor with 2 Nodes
		public Node(TrianguloDelaunay valor, Node nodeR, Node nodeL)
		{
			Node(valor, null, nodeR, nodeL);
		}
		//Construtor Raiz com 1 Node / Root contructor with 1 Node
		public Node(TriaguloDelaunay valor, NodeR)
		{
			Node(valor, null, nodeR);
		}
		//Construtor Raiz com 0 Node / Root contructor with 0 Node
		public Node(TriaguloDelaunay valor)
		{
			Node(valor, null, null);
		}
		//Construtor Folha / Leaf constructor
		public Node(TrianguloDelaunay valor, Node nodeF)
		{
			Node(valor, nodeF, null, null)
		}
		//Retorna um determinado codigo para cada caso
		public int WhatIs()
		{
			if(_nodeF == null)
				return 0; //Caso raiz
			else if(_nodeR != null)
				return 1; //Caso node
			else	return 2; //Caso Folha
		}
	}
}
