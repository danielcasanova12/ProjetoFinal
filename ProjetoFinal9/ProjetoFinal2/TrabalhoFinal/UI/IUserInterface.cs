using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificação_01___Final.UI
{
    public interface IUserInterface
    {

        void Menu();
        void Cadastrar();
        void Listar();
        void Alterar();
        void Excluir();
    }
}
