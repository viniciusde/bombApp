using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bombApp
{
    class BombService
    {
        private WireService wireService;
        private const string DEFUSED = "Bomb defused!!!";
        private const string EXPLODE = "Bomb exploded!!!";

        public BombService(string[] wireNames) 
        {
            wireService = new WireService();
            wireService.createWires(wireNames);
        }

        public String defuse() 
        {
            return wireService.cutAll() ? DEFUSED: EXPLODE;
        }
    }
}
