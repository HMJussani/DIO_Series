using System.Collections.Generic;

namespace series.Interfaces
{
    public interface IRepo<T>
    {
         List<T> Lista();
        T RetornoPorID(int id);
        void Inserir(T objeto);
        void Excluir( int id);
        void Atualizar(T objeto, int id);
        int ProximoId();


    }
}