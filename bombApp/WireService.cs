using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bombApp
{
    class WireService
    {
        private List<string> defaultWires;
        private List<Wire> wires;

        public WireService()
        {
            defaultWires = new List<string>();
            defaultWires.Add(Color.White);
            defaultWires.Add(Color.Black);
            defaultWires.Add(Color.Red);
            defaultWires.Add(Color.Orange);
            defaultWires.Add(Color.Green);
            defaultWires.Add(Color.Purple);
        }

        public bool cutAll()
        {
            List<Wire> cutWires = new List<Wire>();
            cut(cutWires, wires[0]);

            for (int i = 1; i < wires.Count; i++)
            {
                Wire last = wires[i - 1];
                Wire current = wires[i];
                switch (last.Color)
                {
                    case Color.White:
                        if (!Color.White.Equals(current.Color) && !Color.Black.Equals(current.Color))
                        {
                            cut(cutWires, current);
                        }
                        break;
                    case Color.Red:
                        if(Color.Green.Equals(current.Color))
                        {
                            cut(cutWires, current);
                        }
                        break;
                    case Color.Black:
                        if (!Color.White.Equals(current.Color) && !Color.Green.Equals(current.Color) && !Color.Orange.Equals(current.Color))
                        {
                            cut(cutWires, current);
                        }
                        break;
                    case Color.Orange:
                        if (Color.Red.Equals(current.Color) || Color.Black.Equals(current.Color))
                        {
                            cut(cutWires, current);
                        }
                        break;
                    case Color.Green:
                        if (Color.Orange.Equals(current.Color) || Color.White.Equals(current.Color))
                        {
                            cut(cutWires, current);
                        }
                        break;
                    case Color.Purple:
                        if (!Color.Purple.Equals(current.Color) && !Color.Green.Equals(current.Color) && !Color.Orange.Equals(current.Color) && !Color.White.Equals(current.Color))
                        {
                            cut(cutWires, current);
                        }
                        break;
                }
            }

            if (cutWires != null && cutWires.Count == wires.Count)
            {
                return true;
            }
            return false;
        }

        private void cut(List<Wire> cutWires, Wire wire)
        {
                wire.Cut = true;
                cutWires.Add(wire);
        }

        private bool isValid(string wireName)
        {
            if (wireName.Trim() != "" && defaultWires.Contains(wireName.Trim().ToUpper())) 
            {
                return true;
            }
            return false;
        }

        public void createWires(string[] wireNames)
        {
            wires = new List<Wire>();
            if (wireNames != null)
            {
                foreach (string wireName in wireNames)
                {
                    if (isValid(wireName))
                    {
                        Wire wire = new Wire();
                        wire.Color = wireName.Trim().ToUpper();
                        wire.Cut = false;
                        wires.Add(wire);
                    }
                }
            }
        }
    }
}
