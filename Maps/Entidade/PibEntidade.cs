using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.Entidade
{
    public class PibEntidade
    {
        public int idPib { get; set; }
        public int posicao { get; set; }
        public string cidade { get; set; }
        public double valor { get; set; }
        public double percentualRelativo { get; set; }
        public double percentualTotal { get; set; }
        public double coordenadaX { get; set; }
        public double coordenadaY { get; set; }
    }
}