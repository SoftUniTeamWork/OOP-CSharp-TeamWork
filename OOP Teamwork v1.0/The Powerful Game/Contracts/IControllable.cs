using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Powerful_Game.CoreLogic;
using The_Powerful_Game.Entities;

namespace The_Powerful_Game.Contracts
{
    interface IControllable
    {
        void Move();

        void Flee(Enemy enemy);
    }
}
