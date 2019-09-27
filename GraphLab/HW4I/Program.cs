using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4I
{
    // Weighted undirected graph representado con Adjacency List
    public class WeightedUndirectedGraph
    {
        public class Vertex
        {
            public int id { get; private set; }
            public Vertex(int id)
            {
                this.id = id;
                this.adjacentEdges = new List<Edge>();
            }
            public List<Edge> adjacentEdges { get; private set; }
        }

        public class Edge
        {
            public int id { get; private set; }
            public Vertex u, v;
            public int weight { get; private set; }
            public Edge(int id, Vertex u, Vertex v, int weight)
            {
                this.id = id;
                this.u = u;
                this.v = v;
                this.weight = weight;
            }
            public int OppositeVertexId(int x)
            {
                if (x == u.id) return v.id;
                else return u.id;
            }
        }

        public List<Vertex> vertices { get; private set; }
        public List<Edge> edges { get; private set; }

        public WeightedUndirectedGraph(int numVertices)
        {
            vertices = new List<Vertex>();
            for (int i = 0; i < numVertices; i++)
                vertices.Add(new Vertex(i));
            edges = new List<Edge>();
        }


        public void AddEdge(int u, int v, int weight)
        {
            Vertex uu = vertices[u];
            Vertex vv = vertices[v];

            Edge e = new Edge(edges.Count, uu, vv, weight);
            edges.Add(e);

            uu.adjacentEdges.Add(e);
            vv.adjacentEdges.Add(e);
        }


        // Definicion de un path
        // NOTE: Esta definicion no concuerda exactamente con la definicion teorica
        //       de Walk dada en clase: v1 e1 v2 e2 ... ek-1 ... vk, porque esa
        //       definicion es dificil de representar en una estructura de datos
        //       por la alternacion de vertices y ejes en la secuencia
        public class Path
        {
            public Vertex start;      // vertice donde empieza el path
            public List<Edge> edges;  // secuencia de edges en el path
            public Vertex end;        // vertice donde termina el path
            public long weight;       // suma de los weights de los edges en el path
        }


        // Devuelve (un) Longest Simple Path del grafo que empieza desde nodo con
        // id 'src'
        public Path LongestSimplePath(int src)
        {
            // TODO: implementa el algoritmo del profesor Halfwit descrito arriba
            // Valor: 6 puntos
            // Complejidad esperada: O(V*log(E) + E)
            // Restriccion: tu DFS debe ser recursivo

            return null;
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var G = new WeightedUndirectedGraph(6);
            // TODO: provee un contraejemplo que demuestre que el algoritmo del
            //       profesor Halfwit no funciona
            // Valor: 1 punto

            var path = G.LongestSimplePath(0);
            if (path == null)
            {
                Console.WriteLine("WTF");
            }
            else
            {
                Console.WriteLine("Longest Simple Path weight sum: {0}", path.weight);
                Console.WriteLine("Longest Path:");
                Console.WriteLine("Start vertex: {0}", path.start.id);
                foreach (var e in path.edges)
                {
                    Console.WriteLine("Edge id: {0,2}   {1} -> {2}   weight:{3}",
                                      e.id, e.u.id, e.v.id, e.weight);
                }
                Console.WriteLine("End vertex: {0}", path.end.id);
            }
        }
    }
}
