using System.Collections.Generic;

namespace SztfGraf
{
    public abstract class Graf<T>
    {
        public delegate void BejaroHandler(T tartalom);
        protected class El
        {
            public T hova;
            public double suly;
        }
        public abstract void UjCsucs(T tartalom);
        public abstract void UjEl(T honnan, T hova, double suly = 1, bool iranyitott = false);

        protected abstract List<El> Szomszedok(T csucs);

        public void SzelessegiBejaras(T honnan, BejaroHandler _metodus)
        {
            BejaroHandler metodus = _metodus;
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();
            
            S.Enqueue(honnan);
            F.Add(honnan);
            while (S.Count != 0)
            {
                T K = S.Dequeue();
                metodus?.Invoke(K);

                foreach (El x in Szomszedok(K))
                {
                    if (!F.Contains(x.hova))
                    {
                        S.Enqueue(x.hova);
                        F.Add(x.hova);
                    }
                }
            }

        }
    }

    class GrafSzomszedsagiLista<T> : Graf<T>
    {
        private List<T> _tartalmak;
        private List<List<El>> _szomszedok;

        public GrafSzomszedsagiLista()
        {
            _tartalmak = new List<T>();
            _szomszedok = new List<List<El>>();
        }
        
        public override void UjCsucs(T tartalom)
        {
            _tartalmak.Add(tartalom);
            _szomszedok.Add(new List<El>());
        }

        public override void UjEl(T honnan, T hova, double suly = 1, bool iranyitott = false)
        {
            int index = _tartalmak.IndexOf(honnan);
            _szomszedok[index].Add(new El()
            {
                hova = hova,
                suly = suly
            });

            if (!iranyitott)
            {
                index = _tartalmak.IndexOf(hova);
                _szomszedok[index].Add(new El()
                {
                    hova = honnan,
                    suly = suly
                });
            }
        }

        protected override List<El> Szomszedok(T csucs) => _szomszedok[_tartalmak.IndexOf(csucs)];
    }
}