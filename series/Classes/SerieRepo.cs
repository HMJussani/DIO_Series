using series.Interfaces;
using System.Collections.Generic;

namespace series
{
    public class SerieRepo : IRepo<Series>
    {
        private List<Series> ListaSerie = new List<Series>();

        public void Atualizar(Series objeto, int id)
        {
           ListaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Inserir(Series objeto)
        {
            ListaSerie.Add(objeto);
        }

        public List<Series> Lista()
        {
           return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Series RetornoPorID(int id)
        {
            return ListaSerie[id];
        }
    }
}